using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using Microsoft.Identity.Client;
using System.Globalization;

namespace WebRazor.Pages
{
    public class Report2Model : PageModel
    {
        public IConfiguration _configuration;

        public string EmbedUrl { get; set; }
        public string EmbedToken { get; set; }
        public string ReportId { get; set; }

        public Report2Model(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task OnGet()
        {
            try
            {
                // 🌍 Select French or English report
                var isFrench = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "fr";
                var reportSection = isFrench
                    ? _configuration.GetSection("Report2Fr")
                    : _configuration.GetSection("Report2En");

                ReportId = reportSection["ReportId"];
                if (string.IsNullOrEmpty(ReportId))
                    throw new Exception("ReportId is missing in configuration.");

                // 📌 Workspace ID (GroupId)
                var groupIdString = _configuration["PowerBI:GroupId"];
                if (string.IsNullOrEmpty(groupIdString))
                    throw new Exception("PowerBI:GroupId is missing in configuration.");

                //var groupId = Guid.Parse(groupIdString);
                var reportGuid = Guid.Parse(ReportId);
                var groupId = Guid.Parse(_configuration["PowerBI:GroupId"]);

                // 🔑 Get Azure AD token via MSAL
                var accessToken = await GetAccessToken();

                // ⚡ Create Power BI client
                var client = new PowerBIClient(accessToken,
                    new Uri("https://api.powerbi.com/")
                );

                // 📊 Get report info
                var report = await client.Reports.GetReportInGroupAsync(groupId, reportGuid);
                if (report == null)
                    throw new Exception($"Report {ReportId} not found in workspace {groupId}.");

                EmbedUrl = report.Value.EmbedUrl;
                //EmbedUrl = reportSection["EmbedUrl"];

                // 🎟 Generate embed token
                var tokenRequest = new GenerateTokenRequest
                {
                    AccessLevel = TokenAccessLevel.View
                };

                var embedTokenResponse = await client.Reports.GenerateTokenInGroupAsync(groupId, reportGuid, tokenRequest);

                if (embedTokenResponse == null || string.IsNullOrEmpty(embedTokenResponse.Value.Token))
                    throw new Exception("Failed to generate embed token.");

                EmbedToken = embedTokenResponse.Value.Token;
                //EmbedToken = accessToken;
            }
            catch (Exception ex)
            {
                // Friendly logging
                // In production, use ILogger instead of Console
                Console.WriteLine("Power BI embed error: " + ex.Message);
                throw; // Re-throw to see the error in developer page
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