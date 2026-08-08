using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebRazor.Models;

namespace WebRazor.Pages
{
    [BindProperties]
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public string firstName { get; set; }
        [BindProperty]
        public string lastName { get; set; }
        [BindProperty]
        public DateTime dob { get; set; }
        [BindProperty]
        public int id { get; set; }

        public DetailsModel()
        {

        }

        public void OnGet([FromQuery] int id)
        {
            var EndPoint = "http://localhost:5282/api";
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            HttpClient httpClient = new HttpClient(httpClientHandler) { BaseAddress = new Uri(EndPoint) };

            using (httpClient)
            {
                using (HttpResponseMessage response = httpClient.GetAsync("http://localhost:5282/api/cas/get?Id="+id).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        var casModel = JsonConvert.DeserializeObject<CasModel>(apiResponse);
                    }
                }
            }
        }
    }
}
