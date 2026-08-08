using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using Microsoft.Identity.Client;
using System.Globalization;

namespace WebRazor.Pages
{
    public class ReportModel : PageModel
    {
        public IConfiguration _configuration;
        private readonly ILogger<ReportModel> _logger;

        public string EmbedUrl { get; set; }
        public string EmbedToken { get; set; }
        public string ReportId { get; set; }

        public ReportModel(IConfiguration configuration, ILogger<ReportModel> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        private bool IsFrench =>
            CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "fr";

        private (Guid reportGuid, Guid groupId) GetReportIds()
        {
            var reportSection = IsFrench
                ? _configuration.GetSection("Report1Fr")
                : _configuration.GetSection("Report1En");

            var reportIdStr = reportSection["ReportId"];
            if (string.IsNullOrEmpty(reportIdStr))
                throw new Exception("ReportId is missing in configuration.");

            var groupIdStr = _configuration["PowerBI:GroupId"];
            if (string.IsNullOrEmpty(groupIdStr))
                throw new Exception("PowerBI:GroupId is missing in configuration.");

            return (Guid.Parse(reportIdStr), Guid.Parse(groupIdStr));
        }

        private async Task<PowerBIClient> BuildPowerBIClientAsync()
        {
            var accessToken = await GetAccessToken();
            return new PowerBIClient(accessToken, new Uri("https://api.powerbi.com/"));
        }

        public async Task OnGet()
        {
            try
            {
                var (reportGuid, groupId) = GetReportIds();
                ReportId = reportGuid.ToString();

                var client = await BuildPowerBIClientAsync();

                var report = await client.Reports.GetReportInGroupAsync(groupId, reportGuid);
                if (report == null)
                    throw new Exception($"Report {ReportId} not found in workspace {groupId}.");

                EmbedUrl = report.Value.EmbedUrl;

                var tokenRequest = new GenerateTokenRequest
                {
                    AccessLevel = TokenAccessLevel.View
                };

                var embedTokenResponse = await client.Reports.GenerateTokenInGroupAsync(
                    groupId, reportGuid, tokenRequest);

                if (embedTokenResponse == null || string.IsNullOrEmpty(embedTokenResponse.Value.Token))
                    throw new Exception("Failed to generate embed token.");

                EmbedToken = embedTokenResponse.Value.Token;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Power BI embed error: {Message}", ex.Message);
                throw;
            }
        }

        public async Task<IActionResult> OnGetExportPdfAsync()
        {
            try
            {
                _logger.LogInformation("Starting PDF export for print...");

                var (reportGuid, groupId) = GetReportIds();
                var client = await BuildPowerBIClientAsync();

                // Export ALL pages to PDF
                var exportRequest = new ExportReportRequest(FileFormat.PDF)
                {
                    PowerBIReportConfiguration = new PowerBIReportExportConfiguration
                    {
                        Settings = new ExportReportSettings
                        {
                            Locale = IsFrench ? "fr-CA" : "en-CA"
                        }
                    }
                };

                var exportResponse = await client.Reports.ExportToFileInGroupAsync(
                    groupId, reportGuid, exportRequest);
                var exportId = exportResponse.Value.Id;
                _logger.LogInformation("Export initiated with ID: {ExportId}", exportId);

                // Poll for completion (max 5 minutes)
                Export exportStatus = null;
                const int maxAttempts = 60;

                for (int attempt = 1; attempt <= maxAttempts; attempt++)
                {
                    await Task.Delay(5000);

                    var statusResponse = await client.Reports.GetExportToFileStatusInGroupAsync(
                        groupId, reportGuid, exportId);
                    exportStatus = statusResponse.Value;

                    _logger.LogInformation(
                        "Poll {Attempt}/{Max}: Status={Status}, Percent={Percent}%",
                        attempt, maxAttempts, exportStatus.Status, exportStatus.PercentComplete);

                    if (exportStatus.Status == ExportState.Succeeded)
                        break;

                    if (exportStatus.Status == ExportState.Failed)
                        throw new Exception($"Export failed: {exportStatus.Status}");
                }

                if (exportStatus?.Status != ExportState.Succeeded)
                    throw new Exception("Export timed out. Please try again.");

                // Download the PDF
                var fileResponse = await client.Reports.GetFileOfExportToFileInGroupAsync(
                    groupId, reportGuid, exportId);

                var memoryStream = new MemoryStream();
                await fileResponse.Value.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                _logger.LogInformation("PDF ready, size: {Size} bytes", memoryStream.Length);

                // Return as inline PDF (opens in browser, not as download)
                return File(memoryStream, "application/pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PDF export error: {Message}", ex.Message);
                return Content($"Export failed: {ex.Message}");
            }
        }

        private async Task<string> GetAccessToken()
        {
            var tenantId = _configuration["AzureAd:TenantId"];
            var clientId = _configuration["AzureAd:ClientId"];
            var clientSecret = _configuration["AzureAd:ClientSecret"];
            var authority = $"{_configuration["AzureAd:Instance"]}{tenantId}";

            var app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri(authority))
                .Build();

            var scopes = new[] { "https://analysis.windows.net/powerbi/api/.default" };
            var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();

            return result.AccessToken;
        }
    }
}