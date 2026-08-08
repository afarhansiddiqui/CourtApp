using BusinessLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SmartBreadcrumbs.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebRazor.Models;

namespace WebRazor.Pages
{
    [Breadcrumb("ViewData.Final", FromPage = typeof(CreateModel))]
   
    public class FinalMessageModel : PageModel
    {
        private readonly IConfiguration _configuration;

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

        public List<CourtsModel> Courts { get; set; } = new List<CourtsModel>();

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

        //[BindProperty]
        //public string? reqJson { get; set; }
        //[BindProperty]
        //public string? resJson { get; set; }

        public string? responseStatusCode { get; set; }

        [BindProperty]
        public string apiUrlSave { get; set; }

        [BindProperty]
        public string apiUrlRetrieve { get; set; }

        [BindProperty]
        public string apiUrlPickCourt { get; set; }

        public FinalMessageModel(
                IConfiguration configuration
            )
        {
            this._configuration = configuration;
            apiUrlSave = _configuration.GetValue<string>("SaveURL1");
            apiUrlRetrieve = _configuration.GetValue<string>("RetrieveURL1");
            apiUrlPickCourt = _configuration.GetValue<string>("PickCourtURL1");
        }

        public void OnGet()
        {
            //var courts = new
            //{
            //    appId = "CAACS",
            //    region = "NEWRECORD",
            //    table = "CCM_MASTER",
            //    field = "COURT"
            //};

            //var json = JsonConvert.SerializeObject(courts);

            //var apiEndpoint = _configuration.GetValue<string>("PickCourtURL1");

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
            //            //resJson = apiResponse;
            //            Courts = JsonConvert.DeserializeObject<List<CourtsModel>>(apiResponse);
            //        }

            //    }
            //}

            List<CourtsModel> courtsModel = new();
            courtsModel.Add(new CourtsModel()
            {
                Code = "AAA",
                Desc_en_CA = "Alberta Court",
                Desc_fr_CA = "Alberta Court"
            });
            courtsModel.Add(new CourtsModel()
            {
                Code = "BBB",
                Desc_en_CA = "Ontario Court",
                Desc_fr_CA = "Ontario Court"
            });
            Courts = courtsModel;

            //reqJson = (string?)TempData["reqJson"];
            //resJson = (string?)TempData["resJson"];

            txtCOURT = (string?)TempData["txtCOURT"];
                dtFROM = (DateTime?)TempData["dtFROM"];
                dtTO = (DateTime?)TempData["dtTO"];
                intREPORTINGYEAR = (string?)TempData["intREPORTINGYEAR"];

                txtFIELD1_1_1 = (int?)TempData["txtFIELD1_1_1"];
                txtFIELD1_1_2 = (int?)TempData["txtFIELD1_1_2"];
                txtFIELD1_1_3 = (int?)TempData["txtFIELD1_1_3"];
                txtFIELD1_1_4 = (int?)TempData["txtFIELD1_1_4"];
                txtFIELD1_1_5 = (int?)TempData["txtFIELD1_1_5"];
                txtFIELD1_1_6 = (int?)TempData["txtFIELD1_1_6"];
                txtFIELD1_1_7 = (int?)TempData["txtFIELD1_1_7"];
                txtFIELD1_2_1 = (int?)TempData["txtFIELD1_2_1"];
                txtFIELD1_2_2 = (int?)TempData["txtFIELD1_2_2"];
                txtFIELD1_2_3 = (int?)TempData["txtFIELD1_2_3"];
                txtFIELD1_2_4 = (int?)TempData["txtFIELD1_2_4"];
                txtFIELD1_2_5 = (int?)TempData["txtFIELD1_2_5"];
                txtFIELD_1_Comments = (string?)TempData["txtFIELD_1_Comments"];

                txtFIELD2_1_1 = (int?)TempData["txtFIELD2_1_1"];
                txtFIELD2_1_2 = (int?)TempData["txtFIELD2_1_2"];
                txtFIELD2_2_1 = (int?)TempData["txtFIELD2_2_1"];
                txtFIELD2_2_1_1 = (int?)TempData["txtFIELD2_2_1_1"];
                txtFIELD2_2_1_2 = (int?)TempData["txtFIELD2_2_1_2"];
                txtFIELD2_2_1_3 = (int?)TempData["txtFIELD2_2_1_3"];
                txtFIELD2_2_2 = (int?)TempData["txtFIELD2_2_2"];
                txtFIELD2_2_2_1 = (int?)TempData["txtFIELD2_2_2_1"];
                txtFIELD2_2_2_2 = (int?)TempData["txtFIELD2_2_2_2"];
                txtFIELD2_2_2_3 = (int?)TempData["txtFIELD2_2_2_3"];
                txtFIELD_2_Comments = (string?)TempData["txtFIELD_2_Comments"];

                txtFIELD3_1 = (int?)TempData["txtFIELD3_1"];
                txtFIELD3_2 = (int?)TempData["txtFIELD3_2"];
                txtFIELD_3_Comments = (string?)TempData["txtFIELD_3_Comments"];

                txtFIELD4_1_1 = (int?)TempData["txtFIELD4_1_1"];
                txtFIELD4_1_2 = (int?)TempData["txtFIELD4_1_2"];
                txtFIELD4_1_3 = (int?)TempData["txtFIELD4_1_3"];
                txtFIELD4_1_4_1 = (int?)TempData["txtFIELD4_1_4_1"];
                txtFIELD4_1_4_2 = (int?)TempData["txtFIELD4_1_4_2"];
                txtFIELD4_1_4_3 = (int?)TempData["txtFIELD4_1_4_3"];
                txtFIELD4_1_5_1 = (int?)TempData["txtFIELD4_1_5_1"];
                txtFIELD4_1_5_2 = (int?)TempData["txtFIELD4_1_5_2"];
                txtFIELD4_1_5_3 = (int?)TempData["txtFIELD4_1_5_3"];
                txtFIELD4_1_6_1 = (int?)TempData["txtFIELD4_1_6_1"];
                txtFIELD4_1_6_2 = (int?)TempData["txtFIELD4_1_6_2"];
                txtFIELD4_1_6_3 = (int?)TempData["txtFIELD4_1_6_3"];
                txtFIELD4_2_1 = (int?)TempData["txtFIELD4_2_1"];
                txtFIELD4_2_2 = (int?)TempData["txtFIELD4_2_2"];
                txtFIELD4_2_3 = (int?)TempData["txtFIELD4_2_3"];
                txtFIELD4_2_4_1 = (int?)TempData["txtFIELD4_2_4_1"];
                txtFIELD4_2_4_2 = (int?)TempData["txtFIELD4_2_4_2"];
                txtFIELD4_2_4_3 = (int?)TempData["txtFIELD4_2_4_3"];
                txtFIELD4_2_5_1 = (int?)TempData["txtFIELD4_2_5_1"];
                txtFIELD4_2_5_2 = (int?)TempData["txtFIELD4_2_5_2"];
                txtFIELD4_2_5_3 = (int?)TempData["txtFIELD4_2_5_3"];
                txtFIELD4_2_6_1 = (int?)TempData["txtFIELD4_2_6_1"];
                txtFIELD4_2_6_2 = (int?)TempData["txtFIELD4_2_6_2"];
                txtFIELD4_2_6_3 = (int?)TempData["txtFIELD4_2_6_3"];
                txtFIELD4_3_1 = (int?)TempData["txtFIELD4_3_1"];
                txtFIELD4_3_2 = (int?)TempData["txtFIELD4_3_2"];
                txtFIELD4_3_3 = (int?)TempData["txtFIELD4_3_3"];
                txtFIELD4_3_4_1 = (int?)TempData["txtFIELD4_3_4_1"];
                txtFIELD4_3_4_2 = (int?)TempData["txtFIELD4_3_4_2"];
                txtFIELD4_3_4_3 = (int?)TempData["txtFIELD4_3_4_3"];
                txtFIELD4_3_5_1 = (int?)TempData["txtFIELD4_3_5_1"];
                txtFIELD4_3_5_2 = (int?)TempData["txtFIELD4_3_5_2"];
                txtFIELD4_3_5_3 = (int?)TempData["txtFIELD4_3_5_3"];
                txtFIELD4_3_6_1 = (int?)TempData["txtFIELD4_3_6_1"];
                txtFIELD4_3_6_2 = (int?)TempData["txtFIELD4_3_6_2"];
                txtFIELD4_3_6_3 = (int?)TempData["txtFIELD4_3_6_3"];
                txtFIELD_4_Comments = (string?)TempData["txtFIELD_4_Comments"];

                txtFIELD5_1 = (int?)TempData["txtFIELD5_1"];
                txtFIELD5_2 = (int?)TempData["txtFIELD5_2"];
                txtFIELD5_3 = (int?)TempData["txtFIELD5_3"];
                txtFIELD5_4 = (int?)TempData["txtFIELD5_4"];
                txtFIELD_5_Comments = (string?)TempData["txtFIELD_5_Comments"];

                txtFIELD6_1_1 = (int?)TempData["txtFIELD6_1_1"];
                txtFIELD6_1_2 = (int?)TempData["txtFIELD6_1_2"];
                txtFIELD6_1_3 = (int?)TempData["txtFIELD6_1_3"];
                txtFIELD6_2_1 = (int?)TempData["txtFIELD6_2_1"];
                txtFIELD6_2_2 = (int?)TempData["txtFIELD6_2_2"];
                txtFIELD6_2_3 = (int?)TempData["txtFIELD6_2_3"];
                txtFIELD6_3_1 = (int?)TempData["txtFIELD6_3_1"];
                txtFIELD6_3_2 = (int?)TempData["txtFIELD6_3_2"];
                txtFIELD6_3_3 = (int?)TempData["txtFIELD6_3_3"];
                txtFIELD_6_Comments = (string?)TempData["txtFIELD_6_Comments"];

                txtFIELD7_1_1 = (int?)TempData["txtFIELD7_1_1"];
                txtFIELD7_1_2 = (int?)TempData["txtFIELD7_1_2"];
                txtFIELD7_1_3 = (int?)TempData["txtFIELD7_1_3"];
                txtFIELD_7_Comments = (string?)TempData["txtFIELD_7_Comments"];

                txtFIELD8_1 = (int?)TempData["txtFIELD8_1"];
                txtFIELD8_2 = (int?)TempData["txtFIELD8_2"];
                txtFIELD8_3 = (int?)TempData["txtFIELD8_3"];
                txtFIELD_8_Comments = (string?)TempData["txtFIELD_8_Comments"];

                txtFIELD9_1 = (int?)TempData["txtFIELD9_1"];
                txtFIELD9_2 = (int?)TempData["txtFIELD9_2"];
                txtFIELD_9_Comments = (string?)TempData["txtFIELD_9_Comments"];

                txtFIELD10_1 = (int?)TempData["txtFIELD10_1"];
                txtFIELD_10_Comments = (string?)TempData["txtFIELD_10_Comments"];

                txtFIELD11_1 = (int?)TempData["txtFIELD11_1"];
                txtFIELD11_2 = (int?)TempData["txtFIELD11_2"];
                txtFIELD_11_Comments = (string?)TempData["txtFIELD_11_Comments"];

                txtFIELD_12_Comments = (string?)TempData["txtFIELD_12_Comments"];

        }

        public IActionResult OnPost(CASEntityCreate createItem)
        {
            //var courts = new
            //{
            //    appId = "CAACS",
            //    region = "NEWRECORD",
            //    table = "CCM_MASTER",
            //    field = "COURT"
            //};

            //var json = JsonConvert.SerializeObject(courts);

            //var apiEndpoint = _configuration.GetValue<string>("PickCourtURL1");

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
            //            //resJson = apiResponse;
            //            Courts = JsonConvert.DeserializeObject<List<CourtsModel>>(apiResponse);
            //        }

            //    }
            //}

            List<CourtsModel> courtsModel = new();
            courtsModel.Add(new CourtsModel()
            {
                Code = "AAA",
                Desc_en_CA = "Alberta Court",
                Desc_fr_CA = "Alberta Court"
            });
            courtsModel.Add(new CourtsModel()
            {
                Code = "BBB",
                Desc_en_CA = "Ontario Court",
                Desc_fr_CA = "Ontario Court"
            });
            Courts = courtsModel;

            
            bool success = HandleSubmit(createItem);
            if (success)
            {
                //TempData["reqJson"] = reqJson;
                //TempData["resJson"] = resJson;
                //TempData["responseStatusCode"] = responseStatusCode;
                return Page();
            }

            return RedirectToPage("Result");
            
        }

        public bool HandleSubmit(CASEntityCreate createItem)
        {
            CasModel casModel = new CasModel();
            List<Node> nodes = new List<Node>();
            List<Field> fields = new List<Field>();

            Node node = new Node();

            DateTime today = DateTime.Now;
            string todayString = today.ToString("yyyy-MM-dd");

            casModel.uuid = modelUuid;
            node.uuid = nodeUuid;

            fields.Add(new Field()
            {
                name = "EXTERNALUSERID",
                value = emailAddress,
            });

            fields.Add(new Field()
            {
                name = "STATUS",
                value = "COMPLETED",
            });

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
                name = "FIELD2_2_1",
                value = createItem.txtFIELD2_2_1 != null ? createItem.txtFIELD2_2_1.Value.ToString() : "0",
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
                name = "FIELD2_2_2",
                value = createItem.txtFIELD2_2_2 != null ? createItem.txtFIELD2_2_2.Value.ToString() : "0",
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
            //reqJson = json;
            //resJson = "";
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
            //            //resJson = apiResponse;
            //            var casResponseModel = JsonConvert.DeserializeObject<CasModel>(apiResponse);
            //            //TempData["RootUuidReturned"] = casResponseModel.nodes[0].uuid;
            //        }
            //        responseStatusCode = response.StatusCode.ToString();
            //    }
            //}

            return true;
        }

    }
}
