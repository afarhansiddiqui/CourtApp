using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebRazor.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebRazor.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public string firstName { get; set; }
        [BindProperty]
        public string lastName { get; set; }
        [BindProperty]
        public DateTime dob { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public EditModel()
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

        public IActionResult OnPost([FromForm] CasModel editObject)
        {
            //var client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:5282");
            //var content = new FormUrlEncodedContent(new[]
            //{
            //    new KeyValuePair<string, string>("firstName", editObject.FirstName),
            //    new KeyValuePair<string, string>("lastName", editObject.LastName),
            //    new KeyValuePair<string, string>("dateOfBirth", editObject.DateOfBirth.ToString()),
            //    new KeyValuePair<string, string>("id",editObject.Id.ToString())
            //});

            var json = JsonConvert.SerializeObject(editObject);

            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var EndPoint = "http://localhost:5282/api";
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            HttpClient httpClient = new HttpClient(httpClientHandler) { BaseAddress = new Uri(EndPoint) };

            using (httpClient) {

                using (HttpResponseMessage response = httpClient.PutAsync("http://localhost:5282/api/cas/update", content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        var casModel = JsonConvert.DeserializeObject<CasModel>(apiResponse);
                    }
                }

                //var result = httpClient.PutAsync("http://localhost:5282/api/cas/update", content).Result;
                //string resultContent = result.Content.ReadAsStringAsync().Result;   
                //Console.WriteLine(resultContent);
            }

            return Redirect("./Index");
        }
    }
}
