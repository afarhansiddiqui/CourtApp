using BusinessLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SmartBreadcrumbs.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using WebRazor.Models;

namespace WebRazor.Pages
{
    [Authorize]
    [Breadcrumb("ViewData.Result", FromPage = typeof(CreateModel))]
    public class ResultModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public List<CourtsModel> Courts { get; set; } = new List<CourtsModel>();
        [BindProperty]
        public string? modelUuid { get; set; }
        [BindProperty]
        public string? nodeUuid { get; set; }

        [BindProperty]
        public string? emailAddress { get; set; }

        [BindProperty]
        public string? txtCOURT { get; set; }
        [BindProperty]
        public DateTime? dtFROM { get; set; } = DateTime.Now;
        [BindProperty]
        public DateTime? dtTO { get; set; } = DateTime.Now;
        [BindProperty]
        public string? intREPORTINGYEAR { get; set; }
        [BindProperty]
        public int? txtFIELD1_1_1 { get; set; }
        [BindProperty]
        public int? txtFIELD1_1_2 { get; set; }
        [BindProperty]
        public int? txtFIELD1_1_3 { get; set; }
        [BindProperty]
        public int? txtFIELD1_1_4 { get; set; }
        [BindProperty]
        public int? txtFIELD1_1_5 { get; set; }
        [BindProperty]
        public int? txtFIELD1_1_6 { get; set; }
        [BindProperty]
        public int? txtFIELD1_1_7 { get; set; }
        [BindProperty]
        public int? txtFIELD1_2_1 { get; set; }
        [BindProperty]
        public int? txtFIELD1_2_2 { get; set; }
        [BindProperty]
        public int? txtFIELD1_2_3 { get; set; }
        [BindProperty]
        public int? txtFIELD1_2_4 { get; set; }
        [BindProperty]
        public int? txtFIELD1_2_5 { get; set; }

        [BindProperty]
        public string? txtFIELD_1_Comments { get; set; }


        [BindProperty]
        public int? txtFIELD2_1_1 { get; set; }
        [BindProperty]
        public int? txtFIELD2_1_2 { get; set; }
        [BindProperty]
        public int? txtFIELD2_2_1 { get; set; }
        [BindProperty]
        public int? txtFIELD2_2_1_1 { get; set; }
        [BindProperty]
        public int? txtFIELD2_2_1_2 { get; set; }
        [BindProperty]
        public int? txtFIELD2_2_1_3 { get; set; }
        [BindProperty]
        public int? txtFIELD2_2_2 { get; set; }
        [BindProperty]
        public int? txtFIELD2_2_2_1 { get; set; }
        [BindProperty]
        public int? txtFIELD2_2_2_2 { get; set; }
        [BindProperty]
        public int? txtFIELD2_2_2_3 { get; set; }
        [BindProperty]
        public string? txtFIELD_2_Comments { get; set; }

        [BindProperty]
        public int? txtFIELD3_1 { get; set; }
        [BindProperty]
        public int? txtFIELD3_2 { get; set; }
        [BindProperty]
        public string? txtFIELD_3_Comments { get; set; }

        [BindProperty]
        public int? txtFIELD4_1_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_4_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_4_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_4_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_5_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_5_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_5_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_6_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_6_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_1_6_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_4_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_4_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_4_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_5_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_5_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_5_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_6_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_6_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_2_6_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_4_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_4_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_4_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_5_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_5_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_5_3 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_6_1 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_6_2 { get; set; }
        [BindProperty]
        public int? txtFIELD4_3_6_3 { get; set; }
        [BindProperty]
        public string? txtFIELD_4_Comments { get; set; }

        [BindProperty]
        public int? txtFIELD5_1 { get; set; }
        [BindProperty]
        public int? txtFIELD5_2 { get; set; }
        [BindProperty]
        public int? txtFIELD5_3 { get; set; }
        [BindProperty]
        public int? txtFIELD5_4 { get; set; }
        [BindProperty]
        public string? txtFIELD_5_Comments { get; set; }

        [BindProperty]
        public int? txtFIELD6_1_1 { get; set; }
        [BindProperty]
        public int? txtFIELD6_1_2 { get; set; }
        [BindProperty]
        public int? txtFIELD6_1_3 { get; set; }
        [BindProperty]
        public int? txtFIELD6_2_1 { get; set; }
        [BindProperty]
        public int? txtFIELD6_2_2 { get; set; }
        [BindProperty]
        public int? txtFIELD6_2_3 { get; set; }
        [BindProperty]
        public int? txtFIELD6_3_1 { get; set; }
        [BindProperty]
        public int? txtFIELD6_3_2 { get; set; }
        [BindProperty]
        public int? txtFIELD6_3_3 { get; set; }
        [BindProperty]
        public string? txtFIELD_6_Comments { get; set; }

        [BindProperty]
        public int? txtFIELD7_1_1 { get; set; }
        [BindProperty]
        public int? txtFIELD7_1_2 { get; set; }
        [BindProperty]
        public int? txtFIELD7_1_3 { get; set; }
        [BindProperty]
        public string? txtFIELD_7_Comments { get; set; }

        [BindProperty]
        public int? txtFIELD8_1 { get; set; }
        [BindProperty]
        public int? txtFIELD8_2 { get; set; }
        [BindProperty]
        public int? txtFIELD8_3 { get; set; }
        [BindProperty]
        public string? txtFIELD_8_Comments { get; set; }

        [BindProperty]
        public int? txtFIELD9_1 { get; set; }
        [BindProperty]
        public int? txtFIELD9_2 { get; set; }
        [BindProperty]
        public string? txtFIELD_9_Comments { get; set; }

        [BindProperty]
        public int? txtFIELD10_1 { get; set; }
        [BindProperty]
        public string? txtFIELD_10_Comments { get; set; }

        [BindProperty]
        public int? txtFIELD11_1 { get; set; }
        [BindProperty]
        public int? txtFIELD11_2 { get; set; }
        [BindProperty]
        public string? txtFIELD_11_Comments { get; set; }

        [BindProperty]
        public string? txtFIELD_12_Comments { get; set; }

        public string? reqJson { get; set; }
        public string? resJson { get; set; }
        public string? responseStatusCode { get; set; }

        [BindProperty]
        public string apiUrlSave { get; set; }

        [BindProperty]
        public string apiUrlRetrieve { get; set; }

        [BindProperty]
        public string apiUrlPickCourt { get; set; }

        public ResultModel(
                IConfiguration configuration
            )
        {
            this._configuration = configuration;
            apiUrlSave = _configuration.GetValue<string>("SaveURL1");
            apiUrlRetrieve = _configuration.GetValue<string>("RetrieveURL1");
            apiUrlPickCourt = _configuration.GetValue<string>("PickCourtURL1");
        }

       
   


        public IActionResult OnGet()
        {
            var courts = new
            {
                appId = "CAACS",
                region = "NEWRECORD",
                table = "CCM_MASTER",
                field = "COURT"
            };

            var json = JsonConvert.SerializeObject(courts);

            var apiEndpoint = _configuration.GetValue<string>("PickCourtURL1");

            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            HttpClient httpClient = new HttpClient(httpClientHandler) { BaseAddress = new Uri(apiEndpoint) };

            using (httpClient)
            {

                using (HttpResponseMessage response = httpClient.PostAsync(apiEndpoint, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(apiResponse);
                        //resJson = apiResponse;
                        Courts = JsonConvert.DeserializeObject<List<CourtsModel>>(apiResponse);
                    }

                }
            }

            var crt = Request.Query["court"].FirstOrDefault();
            var yr = Request.Query["year"].FirstOrDefault();

            try
            {
                RetrieveData("COMPLETED", crt, yr);
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }

            return Page();

            //txtFIELD1_1_1 = (int?)TempData["txtFIELD1_1_1"];
            //    txtFIELD1_1_2 = (int?)TempData["txtFIELD1_1_2"];
            //    txtFIELD1_1_3 = (int?)TempData["txtFIELD1_1_3"];
            //    txtFIELD1_1_4 = (int?)TempData["txtFIELD1_1_4"];
            //    txtFIELD1_1_5 = (int?)TempData["txtFIELD1_1_5"];
            //    txtFIELD1_1_6 = (int?)TempData["txtFIELD1_1_6"];
            //    txtFIELD1_1_7 = (int?)TempData["txtFIELD1_1_7"];
            //    txtFIELD1_2_1 = (int?)TempData["txtFIELD1_2_1"];
            //    txtFIELD1_2_2 = (int?)TempData["txtFIELD1_2_2"];
            //    txtFIELD1_2_3 = (int?)TempData["txtFIELD1_2_3"];
            //    txtFIELD1_2_4 = (int?)TempData["txtFIELD1_2_4"];
            //    txtFIELD1_2_5 = (int?)TempData["txtFIELD1_2_5"];
            //    txtFIELD_1_Comments = (string?)TempData["txtFIELD_1_Comments"];

            //    txtFIELD2_1_1 = (int?)TempData["txtFIELD2_1_1"];
            //    txtFIELD2_1_2 = (int?)TempData["txtFIELD2_1_2"];
            //    txtFIELD2_2_1 = (int?)TempData["txtFIELD2_2_1"];
            //    txtFIELD2_2_1_1 = (int?)TempData["txtFIELD2_2_1_1"];
            //    txtFIELD2_2_1_2 = (int?)TempData["txtFIELD2_2_1_2"];
            //    txtFIELD2_2_1_3 = (int?)TempData["txtFIELD2_2_1_3"];
            //    txtFIELD2_2_2 = (int?)TempData["txtFIELD2_2_2"];
            //    txtFIELD2_2_2_1 = (int?)TempData["txtFIELD2_2_2_1"];
            //    txtFIELD2_2_2_2 = (int?)TempData["txtFIELD2_2_2_2"];
            //    txtFIELD2_2_2_3 = (int?)TempData["txtFIELD2_2_2_3"];
            //    txtFIELD_2_Comments = (string?)TempData["txtFIELD_2_Comments"];

            //    txtFIELD3_1 = (int?)TempData["txtFIELD3_1"];
            //    txtFIELD3_2 = (int?)TempData["txtFIELD3_2"];
            //    txtFIELD_3_Comments = (string?)TempData["txtFIELD_3_Comments"];

            //    txtFIELD4_1_1 = (int?)TempData["txtFIELD4_1_1"];
            //    txtFIELD4_1_2 = (int?)TempData["txtFIELD4_1_2"];
            //    txtFIELD4_1_3 = (int?)TempData["txtFIELD4_1_3"];
            //    txtFIELD4_1_4_1 = (int?)TempData["txtFIELD4_1_4_1"];
            //    txtFIELD4_1_4_2 = (int?)TempData["txtFIELD4_1_4_2"];
            //    txtFIELD4_1_4_3 = (int?)TempData["txtFIELD4_1_4_3"];
            //    txtFIELD4_1_5_1 = (int?)TempData["txtFIELD4_1_5_1"];
            //    txtFIELD4_1_5_2 = (int?)TempData["txtFIELD4_1_5_2"];
            //    txtFIELD4_1_5_3 = (int?)TempData["txtFIELD4_1_5_3"];
            //    txtFIELD4_1_6_1 = (int?)TempData["txtFIELD4_1_6_1"];
            //    txtFIELD4_1_6_2 = (int?)TempData["txtFIELD4_1_6_2"];
            //    txtFIELD4_1_6_3 = (int?)TempData["txtFIELD4_1_6_3"];
            //    txtFIELD4_2_1 = (int?)TempData["txtFIELD4_2_1"];
            //    txtFIELD4_2_2 = (int?)TempData["txtFIELD4_2_2"];
            //    txtFIELD4_2_3 = (int?)TempData["txtFIELD4_2_3"];
            //    txtFIELD4_2_4_1 = (int?)TempData["txtFIELD4_2_4_1"];
            //    txtFIELD4_2_4_2 = (int?)TempData["txtFIELD4_2_4_2"];
            //    txtFIELD4_2_4_3 = (int?)TempData["txtFIELD4_2_4_3"];
            //    txtFIELD4_2_5_1 = (int?)TempData["txtFIELD4_2_5_1"];
            //    txtFIELD4_2_5_2 = (int?)TempData["txtFIELD4_2_5_2"];
            //    txtFIELD4_2_5_3 = (int?)TempData["txtFIELD4_2_5_3"];
            //    txtFIELD4_2_6_1 = (int?)TempData["txtFIELD4_2_6_1"];
            //    txtFIELD4_2_6_2 = (int?)TempData["txtFIELD4_2_6_2"];
            //    txtFIELD4_2_6_3 = (int?)TempData["txtFIELD4_2_6_3"];
            //    txtFIELD4_3_1 = (int?)TempData["txtFIELD4_3_1"];
            //    txtFIELD4_3_2 = (int?)TempData["txtFIELD4_3_2"];
            //    txtFIELD4_3_3 = (int?)TempData["txtFIELD4_3_3"];
            //    txtFIELD4_3_4_1 = (int?)TempData["txtFIELD4_3_4_1"];
            //    txtFIELD4_3_4_2 = (int?)TempData["txtFIELD4_3_4_2"];
            //    txtFIELD4_3_4_3 = (int?)TempData["txtFIELD4_3_4_3"];
            //    txtFIELD4_3_5_1 = (int?)TempData["txtFIELD4_3_5_1"];
            //    txtFIELD4_3_5_2 = (int?)TempData["txtFIELD4_3_5_2"];
            //    txtFIELD4_3_5_3 = (int?)TempData["txtFIELD4_3_5_3"];
            //    txtFIELD4_3_6_1 = (int?)TempData["txtFIELD4_3_6_1"];
            //    txtFIELD4_3_6_2 = (int?)TempData["txtFIELD4_3_6_2"];
            //    txtFIELD4_3_6_3 = (int?)TempData["txtFIELD4_3_6_3"];
            //    txtFIELD_4_Comments = (string?)TempData["txtFIELD_4_Comments"];

            //    txtFIELD5_1 = (int?)TempData["txtFIELD5_1"];
            //    txtFIELD5_2 = (int?)TempData["txtFIELD5_2"];
            //    txtFIELD5_3 = (int?)TempData["txtFIELD5_3"];
            //    txtFIELD5_4 = (int?)TempData["txtFIELD5_4"];
            //    txtFIELD_5_Comments = (string?)TempData["txtFIELD_5_Comments"];

            //    txtFIELD6_1_1 = (int?)TempData["txtFIELD6_1_1"];
            //    txtFIELD6_1_2 = (int?)TempData["txtFIELD6_1_2"];
            //    txtFIELD6_1_3 = (int?)TempData["txtFIELD6_1_3"];
            //    txtFIELD6_2_1 = (int?)TempData["txtFIELD6_2_1"];
            //    txtFIELD6_2_2 = (int?)TempData["txtFIELD6_2_2"];
            //    txtFIELD6_2_3 = (int?)TempData["txtFIELD6_2_3"];
            //    txtFIELD6_3_1 = (int?)TempData["txtFIELD6_3_1"];
            //    txtFIELD6_3_2 = (int?)TempData["txtFIELD6_3_2"];
            //    txtFIELD6_3_3 = (int?)TempData["txtFIELD6_3_3"];
            //    txtFIELD_6_Comments = (string?)TempData["txtFIELD_6_Comments"];

            //    txtFIELD7_1_1 = (int?)TempData["txtFIELD7_1_1"];
            //    txtFIELD7_1_2 = (int?)TempData["txtFIELD7_1_2"];
            //    txtFIELD7_1_3 = (int?)TempData["txtFIELD7_1_3"];
            //    txtFIELD_7_Comments = (string?)TempData["txtFIELD_7_Comments"];

            //    txtFIELD8_1 = (int?)TempData["txtFIELD8_1"];
            //    txtFIELD8_2 = (int?)TempData["txtFIELD8_2"];
            //    txtFIELD8_3 = (int?)TempData["txtFIELD8_3"];
            //    txtFIELD_8_Comments = (string?)TempData["txtFIELD_8_Comments"];

            //    txtFIELD9_1 = (int?)TempData["txtFIELD9_1"];
            //    txtFIELD9_2 = (int?)TempData["txtFIELD9_2"];
            //    txtFIELD_9_Comments = (string?)TempData["txtFIELD_9_Comments"];

            //    txtFIELD10_1 = (int?)TempData["txtFIELD10_1"];
            //    txtFIELD_10_Comments = (string?)TempData["txtFIELD_10_Comments"];

            //    txtFIELD11_1 = (int?)TempData["txtFIELD11_1"];
            //    txtFIELD11_2 = (int?)TempData["txtFIELD11_2"];
            //    txtFIELD_11_Comments = (string?)TempData["txtFIELD_11_Comments"];

            //    txtFIELD_12_Comments = (string?)TempData["txtFIELD_12_Comments"];
      
        }

        //public IActionResult OnPost(CASEntityCreate createItem)
        //{
        //    return Page();

        //    var finalSubmit = Request.Query["finalSubmit"].FirstOrDefault();
        //    if (!String.IsNullOrEmpty(finalSubmit))
        //    {
        //        bool success = HandleSubmit(createItem);
        //        if (success)
        //        {
        //            TempData["reqJson"] = reqJson;
        //            TempData["resJson"] = resJson;
        //            TempData["responseStatusCode"] = responseStatusCode;
        //            return RedirectToPage("FinalMessage");
        //        }
        //    }

        //    TempData["txtCOURT"] = createItem.txtCOURT;
        //    TempData["dtFROM"] = createItem.dtFROM;
        //    TempData["dtTO"] = createItem.dtTO;
        //    TempData["intREPORTINGYEAR"] = createItem.intREPORTINGYEAR;

        //    TempData["txtFIELD1_1_1"] = createItem.txtFIELD1_1_1;
        //    TempData["txtFIELD1_1_2"] = createItem.txtFIELD1_1_2;
        //    TempData["txtFIELD1_1_3"] = createItem.txtFIELD1_1_3;
        //    TempData["txtFIELD1_1_4"] = createItem.txtFIELD1_1_4;
        //    TempData["txtFIELD1_1_5"] = createItem.txtFIELD1_1_5;
        //    TempData["txtFIELD1_1_6"] = createItem.txtFIELD1_1_6;
        //    TempData["txtFIELD1_1_7"] = createItem.txtFIELD1_1_7;
        //    TempData["txtFIELD1_2_1"] = createItem.txtFIELD1_2_1;
        //    TempData["txtFIELD1_2_2"] = createItem.txtFIELD1_2_2;
        //    TempData["txtFIELD1_2_3"] = createItem.txtFIELD1_2_3;
        //    TempData["txtFIELD1_2_4"] = createItem.txtFIELD1_2_4;
        //    TempData["txtFIELD1_2_5"] = createItem.txtFIELD1_2_5;
        //    TempData["txtFIELD_1_Comments"] = createItem.txtFIELD_1_Comments;

        //    TempData["txtFIELD2_1_1"] = createItem.txtFIELD2_1_1;
        //    TempData["txtFIELD2_1_2"] = createItem.txtFIELD2_1_2;
        //    TempData["txtFIELD2_2_1"] = createItem.txtFIELD2_2_1;
        //    TempData["txtFIELD2_2_1_1"] = createItem.txtFIELD2_2_1_1;
        //    TempData["txtFIELD2_2_1_2"] = createItem.txtFIELD2_2_1_2;
        //    TempData["txtFIELD2_2_1_3"] = createItem.txtFIELD2_2_1_3;
        //    TempData["txtFIELD2_2_2"] = createItem.txtFIELD2_2_2;
        //    TempData["txtFIELD2_2_2_1"] = createItem.txtFIELD2_2_2_1;
        //    TempData["txtFIELD2_2_2_2"] = createItem.txtFIELD2_2_2_2;
        //    TempData["txtFIELD2_2_2_3"] = createItem.txtFIELD2_2_2_3;
        //    TempData["txtFIELD_2_Comments"] = createItem.txtFIELD_2_Comments;

        //    TempData["txtFIELD3_1"] = createItem.txtFIELD3_1;
        //    TempData["txtFIELD3_2"] = createItem.txtFIELD3_2;
        //    TempData["txtFIELD_3_Comments"] = createItem.txtFIELD_3_Comments;

        //    TempData["txtFIELD4_1_1"] = createItem.txtFIELD4_1_1;
        //    TempData["txtFIELD4_1_2"] = createItem.txtFIELD4_1_2;
        //    TempData["txtFIELD4_1_3"] = createItem.txtFIELD4_1_3;
        //    TempData["txtFIELD4_1_4_1"] = createItem.txtFIELD4_1_4_1;
        //    TempData["txtFIELD4_1_4_2"] = createItem.txtFIELD4_1_4_2;
        //    TempData["txtFIELD4_1_4_3"] = createItem.txtFIELD4_1_4_3;
        //    TempData["txtFIELD4_1_5_1"] = createItem.txtFIELD4_1_5_1;
        //    TempData["txtFIELD4_1_5_2"] = createItem.txtFIELD4_1_5_2;
        //    TempData["txtFIELD4_1_5_3"] = createItem.txtFIELD4_1_5_3;
        //    TempData["txtFIELD4_1_6_1"] = createItem.txtFIELD4_1_6_1;
        //    TempData["txtFIELD4_1_6_2"] = createItem.txtFIELD4_1_6_2;
        //    TempData["txtFIELD4_1_6_3"] = createItem.txtFIELD4_1_6_3;
        //    TempData["txtFIELD4_2_1"] = createItem.txtFIELD4_2_1;
        //    TempData["txtFIELD4_2_2"] = createItem.txtFIELD4_2_2;
        //    TempData["txtFIELD4_2_3"] = createItem.txtFIELD4_2_3;
        //    TempData["txtFIELD4_2_4_1"] = createItem.txtFIELD4_2_4_1;
        //    TempData["txtFIELD4_2_4_2"] = createItem.txtFIELD4_2_4_2;
        //    TempData["txtFIELD4_2_4_3"] = createItem.txtFIELD4_2_4_3;
        //    TempData["txtFIELD4_2_5_1"] = createItem.txtFIELD4_2_5_1;
        //    TempData["txtFIELD4_2_5_2"] = createItem.txtFIELD4_2_5_2;
        //    TempData["txtFIELD4_2_5_3"] = createItem.txtFIELD4_2_5_3;
        //    TempData["txtFIELD4_2_6_1"] = createItem.txtFIELD4_2_6_1;
        //    TempData["txtFIELD4_2_6_2"] = createItem.txtFIELD4_2_6_2;
        //    TempData["txtFIELD4_2_6_3"] = createItem.txtFIELD4_2_6_3;
        //    TempData["txtFIELD4_3_1"] = createItem.txtFIELD4_3_1;
        //    TempData["txtFIELD4_3_2"] = createItem.txtFIELD4_3_2;
        //    TempData["txtFIELD4_3_3"] = createItem.txtFIELD4_3_3;
        //    TempData["txtFIELD4_3_4_1"] = createItem.txtFIELD4_3_4_1;
        //    TempData["txtFIELD4_3_4_2"] = createItem.txtFIELD4_3_4_2;
        //    TempData["txtFIELD4_3_4_3"] = createItem.txtFIELD4_3_4_3;
        //    TempData["txtFIELD4_3_5_1"] = createItem.txtFIELD4_3_5_1;
        //    TempData["txtFIELD4_3_5_2"] = createItem.txtFIELD4_3_5_2;
        //    TempData["txtFIELD4_3_5_3"] = createItem.txtFIELD4_3_5_3;
        //    TempData["txtFIELD4_3_6_1"] = createItem.txtFIELD4_3_6_1;
        //    TempData["txtFIELD4_3_6_2"] = createItem.txtFIELD4_3_6_2;
        //    TempData["txtFIELD4_3_6_3"] = createItem.txtFIELD4_3_6_3;
        //    TempData["txtFIELD_4_Comments"] = createItem.txtFIELD_4_Comments;

        //    TempData["txtFIELD5_1"] = createItem.txtFIELD5_1;
        //    TempData["txtFIELD5_2"] = createItem.txtFIELD5_2;
        //    TempData["txtFIELD5_3"] = createItem.txtFIELD5_3;
        //    TempData["txtFIELD5_4"] = createItem.txtFIELD5_4;
        //    TempData["txtFIELD_5_Comments"] = createItem.txtFIELD_5_Comments;

        //    TempData["txtFIELD6_1_1"] = createItem.txtFIELD6_1_1;
        //    TempData["txtFIELD6_1_2"] = createItem.txtFIELD6_1_2;
        //    TempData["txtFIELD6_1_3"] = createItem.txtFIELD6_1_3;
        //    TempData["txtFIELD6_2_1"] = createItem.txtFIELD6_2_1;
        //    TempData["txtFIELD6_2_2"] = createItem.txtFIELD6_2_2;
        //    TempData["txtFIELD6_2_3"] = createItem.txtFIELD6_2_3;
        //    TempData["txtFIELD6_3_1"] = createItem.txtFIELD6_3_1;
        //    TempData["txtFIELD6_3_2"] = createItem.txtFIELD6_3_2;
        //    TempData["txtFIELD6_3_3"] = createItem.txtFIELD6_3_3;
        //    TempData["txtFIELD_6_Comments"] = createItem.txtFIELD_6_Comments;

        //    TempData["txtFIELD7_1_1"] = createItem.txtFIELD7_1_1;
        //    TempData["txtFIELD7_1_2"] = createItem.txtFIELD7_1_2;
        //    TempData["txtFIELD7_1_3"] = createItem.txtFIELD7_1_3;
        //    TempData["txtFIELD_7_Comments"] = createItem.txtFIELD_7_Comments;

        //    TempData["txtFIELD8_1"] = createItem.txtFIELD8_1;
        //    TempData["txtFIELD8_2"] = createItem.txtFIELD8_2;
        //    TempData["txtFIELD8_3"] = createItem.txtFIELD8_3;
        //    TempData["txtFIELD_8_Comments"] = createItem.txtFIELD_8_Comments;

        //    TempData["txtFIELD9_1"] = createItem.txtFIELD9_1;
        //    TempData["txtFIELD9_2"] = createItem.txtFIELD9_2;
        //    TempData["txtFIELD_9_Comments"] = createItem.txtFIELD_9_Comments;

        //    TempData["txtFIELD10_1"] = createItem.txtFIELD10_1;
        //    TempData["txtFIELD_10_Comments"] = createItem.txtFIELD_10_Comments;

        //    TempData["txtFIELD11_1"] = createItem.txtFIELD11_1;
        //    TempData["txtFIELD11_2"] = createItem.txtFIELD11_2;
        //    TempData["txtFIELD_11_Comments"] = createItem.txtFIELD_11_Comments;

        //    TempData["txtFIELD_12_Comments"] = createItem.txtFIELD_12_Comments;

        //    TempData["sectionId"] = Request.Query["sectionId"].FirstOrDefault();
        //    return RedirectToPage("Create", "Load");
        //}

        public IActionResult RetrieveData(string completedOrDraft, string? crt, string? yr)
        {

           
            var courtName = crt;
            var reportingYear = yr;
            var retrieveObj = new CasRetrievalModel();
            retrieveObj.searchParams = new List<SearchParam>();
            retrieveObj.searchParams.Add(
                new SearchParam()
                {
                    fieldName = "STATUS",
                    oper = "EQUAL",
                    values = [
                    completedOrDraft
                ]
                });
            retrieveObj.searchParams.Add(
                new SearchParam()
                {
                    fieldName = "COURT",
                    oper = "EQUAL",
                    values = [
                    courtName
                ]
                });
            retrieveObj.searchParams.Add(
                 new SearchParam()
                 {
                     fieldName = "REPORTINGYEAR",
                     oper = "EQUAL",
                     values = [
                        reportingYear
                        ]
                 });

            var json = JsonConvert.SerializeObject(retrieveObj);

            Console.Write(json);

            var apiEndpoint = _configuration.GetValue<string>("RetrieveURL1");

            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            HttpClient httpClient = new HttpClient(httpClientHandler) { BaseAddress = new Uri(apiEndpoint) };

            using (httpClient)
            {

                using (HttpResponseMessage response = httpClient.PostAsync(apiEndpoint, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(apiResponse);
                        //resJson = apiResponse;
                        var casResponseModel = JsonConvert.DeserializeObject<RootObject>(apiResponse);
                        //TempData["RootUuidReturned"] = casResponseModel.nodes[0].uuid;
                        loadFoundValue(casResponseModel.FirstOrDefault().Value.FirstOrDefault().Value.FirstOrDefault());
                    }
                    //responseStatusCode = response.StatusCode.ToString();
                }
            }

            return Page();
        }

        public void loadFoundValue(Record casItem)
        {
            var data = casItem;

            //var rootKey = data;
            //var childKey = data[rootKey][0];

            //var guid = data[rootKey][childKey][0].guid;

            var modelUuid = data.Guid;
            var nodeUuid = data.Guid;

            var fields = data.Fields;

            //fields.forEach(f => {
            foreach (NodeField f in fields)
            {
                //float floatValue = 0;
                //int? intValue = 0;
                switch (f.Name)
                {
                    case "EXTERNALUSERID": emailAddress = f.Value; break;
                    case "COURT": txtCOURT = f.Value; break;
                    case "REPORTINGYEAR":
                        var floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        int? intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        intREPORTINGYEAR = intValue!.ToString(); break;
                    case "DATEFROM": dtFROM = DateTime.Parse(f.Value); break;
                    case "DATETO": dtTO = DateTime.Parse(f.Value); break;
                    case "FIELD1_1_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_1_1 = intValue; break;
                    case "FIELD1_1_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_1_2 = intValue; break;
                    case "FIELD1_1_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_1_3 = intValue; break;
                    case "FIELD1_1_4":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_1_4 = intValue; break;
                    case "FIELD1_1_5":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_1_5 = intValue; break;
                    case "FIELD1_1_6":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_1_6 = intValue; break;
                    case "FIELD1_1_7":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_1_7 = intValue; break;
                    case "COMMENTSECTION1": txtFIELD_1_Comments = f.Value; break;
                    case "FIELD1_2_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_2_1 = intValue; break;
                    case "FIELD1_2_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_2_2 = intValue; break;
                    case "FIELD1_2_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_2_3 = intValue; break;
                    case "FIELD1_2_4":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_2_4 = intValue; break;
                    case "FIELD1_2_5":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD1_2_5 = intValue; break;
                    case "FIELD2_1_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD2_1_1 = intValue; break;
                    case "FIELD2_1_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD2_1_2 = intValue; break;
                    case "FIELD2_2_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD2_2_1 = intValue; break;
                    case "FIELD2_2_1_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD2_2_1_1 = intValue; break;
                    case "FIELD2_2_1_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD2_2_1_2 = intValue; break;
                    case "FIELD2_2_1_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD2_2_1_3 = intValue; break;
                    case "FIELD2_2_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD2_2_2 = intValue; break;
                    case "FIELD2_2_2_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD2_2_2_1 = intValue; break;
                    case "FIELD2_2_2_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD2_2_2_2 = intValue; break;
                    case "FIELD2_2_2_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD2_2_2_3 = intValue; break;
                    case "COMMENTSECTION2": txtFIELD_2_Comments = f.Value; break;
                    case "FIELD3_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD3_1 = intValue; break;
                    case "FIELD3_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD3_2 = intValue; break;
                    case "COMMENTSECTION3": txtFIELD_3_Comments = f.Value; break;
                    case "FIELD4_1_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_1 = intValue; break;
                    case "FIELD4_1_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_2 = intValue; break;
                    case "FIELD4_1_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_3 = intValue; break;
                    case "FIELD4_1_4_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_4_1 = intValue; break;
                    case "FIELD4_1_4_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_4_2 = intValue; break;
                    case "FIELD4_1_4_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_4_3 = intValue; break;
                    case "FIELD4_1_5_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_5_1 = intValue; break;
                    case "FIELD4_1_5_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_5_2 = intValue; break;
                    case "FIELD4_1_5_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_5_3 = intValue; break;
                    case "FIELD4_1_6_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_6_1 = intValue; break;
                    case "FIELD4_1_6_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_6_2 = intValue; break;
                    case "FIELD4_1_6_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_1_6_3 = intValue; break;
                    case "FIELD4_2_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_1 = intValue; break;
                    case "FIELD4_2_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_2 = intValue; break;
                    case "FIELD4_2_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_3 = intValue; break;
                    case "FIELD4_2_4_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_4_1 = intValue; break;
                    case "FIELD4_2_4_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_4_2 = intValue; break;
                    case "FIELD4_2_4_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_4_3 = intValue; break;
                    case "FIELD4_2_5_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_5_1 = intValue; break;
                    case "FIELD4_2_5_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_5_2 = intValue; break;
                    case "FIELD4_2_5_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_5_3 = intValue; break;
                    case "FIELD4_2_6_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_6_1 = intValue; break;
                    case "FIELD4_2_6_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_6_2 = intValue; break;
                    case "FIELD4_2_6_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_2_6_3 = intValue; break;
                    case "FIELD4_3_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_1 = intValue; break;
                    case "FIELD4_3_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_2 = intValue; break;
                    case "FIELD4_3_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_3 = intValue; break;
                    case "FIELD4_3_4_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_4_1 = intValue; break;
                    case "FIELD4_3_4_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_4_2 = intValue; break;
                    case "FIELD4_3_4_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_4_3 = intValue; break;
                    case "FIELD4_3_5_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_5_1 = intValue; break;
                    case "FIELD4_3_5_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_5_2 = intValue; break;
                    case "FIELD4_3_5_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_5_3 = intValue; break;
                    case "FIELD4_3_6_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_6_1 = intValue; break;
                    case "FIELD4_3_6_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_6_2 = intValue; break;
                    case "FIELD4_3_6_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD4_3_6_3 = intValue; break;
                    case "COMMENTSECTION4": txtFIELD_4_Comments = f.Value; break;
                    case "FIELD5_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD5_1 = intValue; break;
                    case "FIELD5_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD5_2 = intValue; break;
                    case "FIELD5_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD5_3 = intValue; break;
                    case "FIELD5_4":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD5_4 = intValue; break;
                    case "COMMENTSECTION5": txtFIELD_5_Comments = f.Value; break;
                    case "FIELD6_1_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD6_1_1 = intValue; break;
                    case "FIELD6_1_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD6_1_2 = intValue; break;
                    case "FIELD6_1_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD6_1_3 = intValue; break;
                    case "FIELD6_2_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD6_2_1 = intValue; break;
                    case "FIELD6_2_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD6_2_2 = intValue; break;
                    case "FIELD6_2_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD6_2_3 = intValue; break;
                    case "FIELD6_3_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD6_3_1 = intValue; break;
                    case "FIELD6_3_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD6_3_2 = intValue; break;
                    case "FIELD6_3_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD6_3_3 = intValue; break;
                    case "COMMENTSECTION6": txtFIELD_6_Comments = f.Value; break;
                    case "FIELD7_1_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD7_1_1 = intValue; break;
                    case "FIELD7_1_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD7_1_2 = intValue; break;
                    case "FIELD7_1_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD7_1_3 = intValue; break;
                    case "COMMENTSECTION7": txtFIELD_7_Comments = f.Value; break;
                    case "FIELD8_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD8_1 = intValue; break;
                    case "FIELD8_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD8_2 = intValue; break;
                    case "FIELD8_3":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD8_3 = intValue; break;
                    case "COMMENTSECTION8": txtFIELD_8_Comments = f.Value; break;
                    case "FIELD9_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD9_1 = intValue; break;
                    case "FIELD9_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD9_2 = intValue; break;
                    case "COMMENTSECTION9": txtFIELD_9_Comments = f.Value; break;
                    case "FIELD10_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD10_1 = intValue; break;
                    case "COMMENTSECTION10": txtFIELD_10_Comments = f.Value; break;
                    case "FIELD11_1":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD11_1 = intValue; break;
                    case "FIELD11_2":
                        floatValue = float.Parse(f.Value, CultureInfo.InvariantCulture);
                        intValue = (int)Math.Floor(floatValue) != 0 ? (int)Math.Floor(floatValue) : null;
                        txtFIELD11_2 = intValue; break;
                    case "COMMENTSECTION11": txtFIELD_11_Comments = f.Value; break;
                }
            }
        }


        public bool HandleSubmit(CASEntityCreate createItem)
        {
            CasModel casModel = new CasModel();
            List<Node> nodes = new List<Node>();
            List<Field> fields = new List<Field>();

            Node node = new Node();

            DateTime today = DateTime.Now;
            string todayString = today.ToString("yyyy-MM-dd");

            fields.Add(new Field()
            {
                name = "INPUT",
                value = todayString,
            });

            // reporting year and court name
            fields.Add(new Field()
            {
                name = "COURT",
                value = createItem.txtCOURT != null ? createItem.txtCOURT : "0",
            });

            fields.Add(new Field()
            {
                name = "REPORTINGYEAR",
                value = createItem.intREPORTINGYEAR != null ? createItem.intREPORTINGYEAR.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "DATEFROM",
                value = createItem.dtFROM != null ? createItem.dtFROM.Value.ToString("yyyy-MM-dd") : "0",
            });

            fields.Add(new Field()
            {
                name = "DATETO",
                value = createItem.dtTO != null ? createItem.dtTO.Value.ToString("yyyy-MM-dd") : "0",
            });

            // section 1
            fields.Add(new Field()
            {
                name = "FIELD1_1_1",
                value = createItem.txtFIELD1_1_1 != null ? createItem.txtFIELD1_1_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_1_2",
                value = createItem.txtFIELD1_1_2 != null ? createItem.txtFIELD1_1_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_1_3",
                value = createItem.txtFIELD1_1_3 != null ? createItem.txtFIELD1_1_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_1_4",
                value = createItem.txtFIELD1_1_4 != null ? createItem.txtFIELD1_1_4.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_1_5",
                value = createItem.txtFIELD1_1_5 != null ? createItem.txtFIELD1_1_5.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_1_6",
                value = createItem.txtFIELD1_1_6 != null ? createItem.txtFIELD1_1_6.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_1_7",
                value = createItem.txtFIELD1_1_7 != null ? createItem.txtFIELD1_1_7.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION1",
                value = createItem.txtFIELD_1_Comments != null ? createItem.txtFIELD_1_Comments : "",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_2_1",
                value = createItem.txtFIELD1_2_1 != null ? createItem.txtFIELD1_2_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_2_2",
                value = createItem.txtFIELD1_2_2 != null ? createItem.txtFIELD1_2_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_2_3",
                value = createItem.txtFIELD1_2_3 != null ? createItem.txtFIELD1_2_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_2_4",
                value = createItem.txtFIELD1_2_4 != null ? createItem.txtFIELD1_2_4.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD1_2_5",
                value = createItem.txtFIELD1_2_5 != null ? createItem.txtFIELD1_2_5.Value.ToString() : "0",
            });

            // section 2
            fields.Add(new Field()
            {
                name = "FIELD2_1_1",
                value = createItem.txtFIELD2_1_1 != null ? createItem.txtFIELD2_1_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD2_1_2",
                value = createItem.txtFIELD2_1_2 != null ? createItem.txtFIELD2_1_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD2_2_1_1",
                value = createItem.txtFIELD2_2_1_1 != null ? createItem.txtFIELD2_2_1_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD2_2_1_2",
                value = createItem.txtFIELD2_2_1_2 != null ? createItem.txtFIELD2_2_1_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD2_2_1_3",
                value = createItem.txtFIELD2_2_1_3 != null ? createItem.txtFIELD2_2_1_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD2_2_2_1",
                value = createItem.txtFIELD2_2_2_1 != null ? createItem.txtFIELD2_2_2_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD2_2_2_2",
                value = createItem.txtFIELD2_2_2_2 != null ? createItem.txtFIELD2_2_2_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD2_2_2_3",
                value = createItem.txtFIELD2_2_2_3 != null ? createItem.txtFIELD2_2_2_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION2",
                value = createItem.txtFIELD_2_Comments != null ? createItem.txtFIELD_2_Comments : "",
            });

            // section 3
            fields.Add(new Field()
            {
                name = "FIELD3_1",
                value = createItem.txtFIELD3_1 != null ? createItem.txtFIELD3_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD3_2",
                value = createItem.txtFIELD3_2 != null ? createItem.txtFIELD3_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION3",
                value = createItem.txtFIELD_3_Comments != null ? createItem.txtFIELD_3_Comments : "",
            });

            // section 4
            fields.Add(new Field()
            {
                name = "FIELD4_1_1",
                value = createItem.txtFIELD4_1_1 != null ? createItem.txtFIELD4_1_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_2",
                value = createItem.txtFIELD4_1_2 != null ? createItem.txtFIELD4_1_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_3",
                value = createItem.txtFIELD4_1_3 != null ? createItem.txtFIELD4_1_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_4_1",
                value = createItem.txtFIELD4_1_4_1 != null ? createItem.txtFIELD4_1_4_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_4_2",
                value = createItem.txtFIELD4_1_4_2 != null ? createItem.txtFIELD4_1_4_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_4_3",
                value = createItem.txtFIELD4_1_4_3 != null ? createItem.txtFIELD4_1_4_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_5_1",
                value = createItem.txtFIELD4_1_5_1 != null ? createItem.txtFIELD4_1_5_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_5_2",
                value = createItem.txtFIELD4_1_5_2 != null ? createItem.txtFIELD4_1_5_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_5_3",
                value = createItem.txtFIELD4_1_5_3 != null ? createItem.txtFIELD4_1_5_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_6_1",
                value = createItem.txtFIELD4_1_6_1 != null ? createItem.txtFIELD4_1_6_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_6_2",
                value = createItem.txtFIELD4_1_6_2 != null ? createItem.txtFIELD4_1_6_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_1_6_3",
                value = createItem.txtFIELD4_1_6_3 != null ? createItem.txtFIELD4_1_6_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_1",
                value = createItem.txtFIELD4_2_1 != null ? createItem.txtFIELD4_2_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_2",
                value = createItem.txtFIELD4_2_2 != null ? createItem.txtFIELD4_2_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_3",
                value = createItem.txtFIELD4_2_3 != null ? createItem.txtFIELD4_2_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_4_1",
                value = createItem.txtFIELD4_2_4_1 != null ? createItem.txtFIELD4_2_4_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_4_2",
                value = createItem.txtFIELD4_2_4_2 != null ? createItem.txtFIELD4_2_4_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_4_3",
                value = createItem.txtFIELD4_2_4_3 != null ? createItem.txtFIELD4_2_4_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_5_1",
                value = createItem.txtFIELD4_2_5_1 != null ? createItem.txtFIELD4_2_5_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_5_2",
                value = createItem.txtFIELD4_2_5_2 != null ? createItem.txtFIELD4_2_5_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_5_3",
                value = createItem.txtFIELD4_2_5_3 != null ? createItem.txtFIELD4_2_5_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_6_1",
                value = createItem.txtFIELD4_2_6_1 != null ? createItem.txtFIELD4_2_6_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_6_2",
                value = createItem.txtFIELD4_2_6_2 != null ? createItem.txtFIELD4_2_6_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_2_6_3",
                value = createItem.txtFIELD4_2_6_3 != null ? createItem.txtFIELD4_2_6_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_1",
                value = createItem.txtFIELD4_3_1 != null ? createItem.txtFIELD4_3_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_2",
                value = createItem.txtFIELD4_3_2 != null ? createItem.txtFIELD4_3_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_3",
                value = createItem.txtFIELD4_3_3 != null ? createItem.txtFIELD4_3_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_4_1",
                value = createItem.txtFIELD4_3_4_1 != null ? createItem.txtFIELD4_3_4_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_4_2",
                value = createItem.txtFIELD4_3_4_2 != null ? createItem.txtFIELD4_3_4_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_4_3",
                value = createItem.txtFIELD4_3_4_3 != null ? createItem.txtFIELD4_3_4_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_5_1",
                value = createItem.txtFIELD4_3_5_1 != null ? createItem.txtFIELD4_3_5_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_5_2",
                value = createItem.txtFIELD4_3_5_2 != null ? createItem.txtFIELD4_3_5_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_5_3",
                value = createItem.txtFIELD4_3_5_3 != null ? createItem.txtFIELD4_3_5_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_6_1",
                value = createItem.txtFIELD4_3_6_1 != null ? createItem.txtFIELD4_3_6_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_6_2",
                value = createItem.txtFIELD4_3_6_2 != null ? createItem.txtFIELD4_3_6_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD4_3_6_3",
                value = createItem.txtFIELD4_3_6_3 != null ? createItem.txtFIELD4_3_6_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION4",
                value = createItem.txtFIELD_4_Comments != null ? createItem.txtFIELD_4_Comments : "",
            });

            // section 5
            fields.Add(new Field()
            {
                name = "FIELD5_1",
                value = createItem.txtFIELD5_1 != null ? createItem.txtFIELD5_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD5_2",
                value = createItem.txtFIELD5_2 != null ? createItem.txtFIELD5_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD5_3",
                value = createItem.txtFIELD5_3 != null ? createItem.txtFIELD5_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD5_4",
                value = createItem.txtFIELD5_4 != null ? createItem.txtFIELD5_4.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION5",
                value = createItem.txtFIELD_5_Comments != null ? createItem.txtFIELD_5_Comments : "",
            });

            // section 6
            fields.Add(new Field()
            {
                name = "FIELD6_1_1",
                value = createItem.txtFIELD6_1_1 != null ? createItem.txtFIELD6_1_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD6_1_2",
                value = createItem.txtFIELD6_1_2 != null ? createItem.txtFIELD6_1_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD6_1_3",
                value = createItem.txtFIELD6_1_3 != null ? createItem.txtFIELD6_1_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD6_2_1",
                value = createItem.txtFIELD6_2_1 != null ? createItem.txtFIELD6_2_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD6_2_2",
                value = createItem.txtFIELD6_2_2 != null ? createItem.txtFIELD6_2_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD6_2_3",
                value = createItem.txtFIELD6_2_3 != null ? createItem.txtFIELD6_2_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD6_3_1",
                value = createItem.txtFIELD6_3_1 != null ? createItem.txtFIELD6_3_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD6_3_2",
                value = createItem.txtFIELD6_3_2 != null ? createItem.txtFIELD6_3_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD6_3_3",
                value = createItem.txtFIELD6_3_3 != null ? createItem.txtFIELD6_3_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION6",
                value = createItem.txtFIELD_6_Comments != null ? createItem.txtFIELD_6_Comments : "",
            });

            // section 7
            fields.Add(new Field()
            {
                name = "FIELD7_1_1",
                value = createItem.txtFIELD7_1_1 != null ? createItem.txtFIELD7_1_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD7_1_2",
                value = createItem.txtFIELD7_1_2 != null ? createItem.txtFIELD7_1_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD7_1_3",
                value = createItem.txtFIELD7_1_3 != null ? createItem.txtFIELD7_1_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION7",
                value = createItem.txtFIELD_7_Comments != null ? createItem.txtFIELD_7_Comments : "",
            });

            // section 8
            fields.Add(new Field()
            {
                name = "FIELD8_1",
                value = createItem.txtFIELD8_1 != null ? createItem.txtFIELD8_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD8_2",
                value = createItem.txtFIELD8_2 != null ? createItem.txtFIELD8_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD8_3",
                value = createItem.txtFIELD8_3 != null ? createItem.txtFIELD8_3.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION8",
                value = createItem.txtFIELD_8_Comments != null ? createItem.txtFIELD_8_Comments : "",
            });

            // section 9
            fields.Add(new Field()
            {
                name = "FIELD9_1",
                value = createItem.txtFIELD9_1 != null ? createItem.txtFIELD9_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD9_2",
                value = createItem.txtFIELD9_2 != null ? createItem.txtFIELD9_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION9",
                value = createItem.txtFIELD_9_Comments != null ? createItem.txtFIELD_9_Comments : "",
            });

            // section 10
            fields.Add(new Field()
            {
                name = "FIELD10_1",
                value = createItem.txtFIELD10_1 != null ? createItem.txtFIELD10_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION10",
                value = createItem.txtFIELD_10_Comments != null ? createItem.txtFIELD_10_Comments : "",
            });

            // section 11
            fields.Add(new Field()
            {
                name = "FIELD11_1",
                value = createItem.txtFIELD11_1 != null ? createItem.txtFIELD11_1.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "FIELD11_2",
                value = createItem.txtFIELD11_2 != null ? createItem.txtFIELD11_2.Value.ToString() : "0",
            });

            fields.Add(new Field()
            {
                name = "COMMENTSECTION11",
                value = createItem.txtFIELD_11_Comments != null ? createItem.txtFIELD_11_Comments : "",
            });

            node.fields = fields;
            nodes.Add(node);
            casModel.nodes = nodes;

            var json = JsonConvert.SerializeObject(casModel);

            Console.Write(json);
            reqJson = json;
            resJson = "";
            responseStatusCode = "200";

            //var apiEndpoint = _configuration.GetValue<string>("SaveURL1");

            //var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //var httpClientHandler = new HttpClientHandler();
            //httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            //{
            //    return true;
            //};
            //HttpClient httpClient = new HttpClient(httpClientHandler) { BaseAddress = new Uri(apiEndpoint) };

            //using (httpClient)
            //{

            //    using (HttpResponseMessage response = httpClient.PostAsync(apiEndpoint, content).Result)
            //    {
            //        if (response.IsSuccessStatusCode)
            //        {
            //            string apiResponse = response.Content.ReadAsStringAsync().Result;
            //            Console.WriteLine(apiResponse);
            //            resJson = apiResponse;
            //            //var casModel = JsonConvert.DeserializeObject<CasModel>(apiResponse);
            //        }
            //        responseStatusCode = response.StatusCode.ToString();
            //    }
            //}

            return true;
        }
    }
}
