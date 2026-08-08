using BusinessLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartBreadcrumbs.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Versioning;
using System.Security.AccessControl;
using System.Text;
using WebRazor.Models;


namespace WebRazor.Pages
{
    [Authorize]
    [Breadcrumb("ViewData.Create", FromPage = typeof(SelectModel))]
    public class IndexModel1 : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public string? modelUuid { get; set; }
        [BindProperty]
        public string? nodeUuid { get; set; }

        [BindProperty]
        public string? emailAddress { get; set; }

        [BindProperty]
        [Required(ErrorMessageResourceType = typeof(Resources.Pages.CreateModel), ErrorMessageResourceName = "CourtRequired")]
        public string txtCOURT { get; set; }
        [BindProperty]
        [Required(ErrorMessageResourceType = typeof(Resources.Pages.CreateModel), ErrorMessageResourceName = "FromDateRequired")]
        public DateTime? dtFROM { get; set; } = DateTime.Now;
        [BindProperty]
        [Required(ErrorMessageResourceType = typeof(Resources.Pages.CreateModel), ErrorMessageResourceName = "ToDateRequired")]
        public DateTime? dtTO { get; set; } = DateTime.Now;
        [BindProperty]
        [Required(ErrorMessageResourceType = typeof(Resources.Pages.CreateModel), ErrorMessageResourceName = "ReportingYearRequired")]
        public string intREPORTINGYEAR { get; set; }
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

        [BindProperty]
        public string? sectId { get; set; }

        private long maxFileSize = 1024;// * 10;
        [BindProperty]
        public IFormFile? Upload { get; set; }

        [BindProperty]
        public string apiUrlSave { get; set; }

        [BindProperty]
        public string apiUrlRetrieve { get; set; }

        [BindProperty]
        public string apiUrlPickCourt { get; set; }


        public CreateModel(
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
            dtFROM = new DateTime(2025, 01, 01);
            dtTO = new DateTime(2025, 12, 31);
            if (TempData["emailAddress"] != null)
            {
                emailAddress = (string)TempData["emailAddress"];
            }
            //if (TempData["modelUuid"] != null)
            //{
            //    modelUuid = (string)TempData["modelUuid"];
            //}
            //if (TempData["nodeUuid"] != null)
            //{
            //    nodeUuid = (string)TempData["nodeUuid"];
            //}
        }

        public IActionResult OnPost()
        {
            //if (Upload != null) { 
            //    if(Upload.Length > maxFileSize)
            //    {
            //        ModelState.Clear();
            //        ModelState.AddModelError("FileUpload", "File size should be less than 10 MB");
            //        return Page();
            //    }
            //}

            //if (!ModelState.IsValid)
            //return Page();

            var createItem = new CASEntityCreate()
            {
                txtCOURT = txtCOURT,
                dtFROM = dtFROM,
                dtTO = dtTO,
                intREPORTINGYEAR = intREPORTINGYEAR,
                txtFIELD1_1_1 = txtFIELD1_1_1,
                txtFIELD1_1_2 = txtFIELD1_1_2,
                txtFIELD1_1_3 = txtFIELD1_1_3,
                txtFIELD1_1_4 = txtFIELD1_1_4,
                txtFIELD1_1_5 = txtFIELD1_1_5,
                txtFIELD1_1_6 = txtFIELD1_1_6,
                txtFIELD1_1_7 = txtFIELD1_1_7,
                txtFIELD1_2_1 = txtFIELD1_2_1,
                txtFIELD1_2_2 = txtFIELD1_2_2,
                txtFIELD1_2_3 = txtFIELD1_2_3,
                txtFIELD1_2_4 = txtFIELD1_2_4,
                txtFIELD1_2_5 = txtFIELD1_2_5,
                txtFIELD_1_Comments = txtFIELD_1_Comments,

                txtFIELD2_1_1 = txtFIELD2_1_1,
                txtFIELD2_1_2 = txtFIELD2_1_2,
                txtFIELD2_2_1 = txtFIELD2_2_1,
                txtFIELD2_2_1_1 = txtFIELD2_2_1_1,
                txtFIELD2_2_1_2 = txtFIELD2_2_1_2,
                txtFIELD2_2_1_3 = txtFIELD2_2_1_3,
                txtFIELD2_2_2 = txtFIELD2_2_2,
                txtFIELD2_2_2_1 = txtFIELD2_2_2_1,
                txtFIELD2_2_2_2 = txtFIELD2_2_2_2,
                txtFIELD2_2_2_3 = txtFIELD2_2_2_3,
                txtFIELD_2_Comments = txtFIELD_2_Comments,

                txtFIELD3_1 = txtFIELD3_1,
                txtFIELD3_2 = txtFIELD3_2,
                txtFIELD_3_Comments = txtFIELD_3_Comments,

                txtFIELD4_1_1 = txtFIELD4_1_1,
                txtFIELD4_1_2 = txtFIELD4_1_2,
                txtFIELD4_1_3 = txtFIELD4_1_3,
                txtFIELD4_1_4_1 = txtFIELD4_1_4_1,
                txtFIELD4_1_4_2 = txtFIELD4_1_4_2,
                txtFIELD4_1_4_3 = txtFIELD4_1_4_3,
                txtFIELD4_1_5_1 = txtFIELD4_1_5_1,
                txtFIELD4_1_5_2 = txtFIELD4_1_5_2,
                txtFIELD4_1_5_3 = txtFIELD4_1_5_3,
                txtFIELD4_1_6_1 = txtFIELD4_1_6_1,
                txtFIELD4_1_6_2 = txtFIELD4_1_6_2,
                txtFIELD4_1_6_3 = txtFIELD4_1_6_3,
                txtFIELD4_2_1 = txtFIELD4_2_1,
                txtFIELD4_2_2 = txtFIELD4_2_2,
                txtFIELD4_2_3 = txtFIELD4_2_3,
                txtFIELD4_2_4_1 = txtFIELD4_2_4_1,
                txtFIELD4_2_4_2 = txtFIELD4_2_4_2,
                txtFIELD4_2_4_3 = txtFIELD4_2_4_3,
                txtFIELD4_2_5_1 = txtFIELD4_2_5_1,
                txtFIELD4_2_5_2 = txtFIELD4_2_5_2,
                txtFIELD4_2_5_3 = txtFIELD4_2_5_3,
                txtFIELD4_2_6_1 = txtFIELD4_2_6_1,
                txtFIELD4_2_6_2 = txtFIELD4_2_6_2,
                txtFIELD4_2_6_3 = txtFIELD4_2_6_3,
                txtFIELD4_3_1 = txtFIELD4_3_1,
                txtFIELD4_3_2 = txtFIELD4_3_2,
                txtFIELD4_3_3 = txtFIELD4_3_3,
                txtFIELD4_3_4_1 = txtFIELD4_3_4_1,
                txtFIELD4_3_4_2 = txtFIELD4_3_4_2,
                txtFIELD4_3_4_3 = txtFIELD4_3_4_3,
                txtFIELD4_3_5_1 = txtFIELD4_3_5_1,
                txtFIELD4_3_5_2 = txtFIELD4_3_5_2,
                txtFIELD4_3_5_3 = txtFIELD4_3_5_3,
                txtFIELD4_3_6_1 = txtFIELD4_3_6_1,
                txtFIELD4_3_6_2 = txtFIELD4_3_6_2,
                txtFIELD4_3_6_3 = txtFIELD4_3_6_3,
                txtFIELD_4_Comments = txtFIELD_4_Comments,

                txtFIELD5_1 = txtFIELD5_1,
                txtFIELD5_2 = txtFIELD5_2,
                txtFIELD5_3 = txtFIELD5_3,
                txtFIELD5_4 = txtFIELD5_4,
                txtFIELD_5_Comments = txtFIELD_5_Comments,

                txtFIELD6_1_1 = txtFIELD6_1_1,
                txtFIELD6_1_2 = txtFIELD6_1_2,
                txtFIELD6_1_3 = txtFIELD6_1_3,
                txtFIELD6_2_1 = txtFIELD6_2_1,
                txtFIELD6_2_2 = txtFIELD6_2_2,
                txtFIELD6_2_3 = txtFIELD6_2_3,
                txtFIELD6_3_1 = txtFIELD6_3_1,
                txtFIELD6_3_2 = txtFIELD6_3_2,
                txtFIELD6_3_3 = txtFIELD6_3_3,
                txtFIELD_6_Comments = txtFIELD_6_Comments,

                txtFIELD7_1_1 = txtFIELD7_1_1,
                txtFIELD7_1_2 = txtFIELD7_1_2,
                txtFIELD7_1_3 = txtFIELD7_1_3,
                txtFIELD_7_Comments = txtFIELD_7_Comments,

                txtFIELD8_1 = txtFIELD8_1,
                txtFIELD8_2 = txtFIELD8_2,
                txtFIELD8_3 = txtFIELD8_3,
                txtFIELD_8_Comments = txtFIELD_8_Comments,

                txtFIELD9_1 = txtFIELD9_1,
                txtFIELD9_2 = txtFIELD9_2,
                txtFIELD_9_Comments = txtFIELD_9_Comments,

                txtFIELD10_1 = txtFIELD10_1,
                txtFIELD_10_Comments = txtFIELD_10_Comments,

                txtFIELD11_1 = txtFIELD11_1,
                txtFIELD11_2 = txtFIELD11_2,
                txtFIELD_11_Comments = txtFIELD_11_Comments,

                txtFIELD_12_Comments = txtFIELD_12_Comments,
            };

            TempData["txtCOURT"] = createItem.txtCOURT;
            TempData["dtFROM"] = createItem.dtFROM;
            TempData["dtTO"] = createItem.dtTO;
            TempData["intREPORTINGYEAR"] = createItem.intREPORTINGYEAR;

            TempData["txtFIELD1_1_1"] = createItem.txtFIELD1_1_1;
            TempData["txtFIELD1_1_2"] = createItem.txtFIELD1_1_2;
            TempData["txtFIELD1_1_3"] = createItem.txtFIELD1_1_3;
            TempData["txtFIELD1_1_4"] = createItem.txtFIELD1_1_4;
            TempData["txtFIELD1_1_5"] = createItem.txtFIELD1_1_5;
            TempData["txtFIELD1_1_6"] = createItem.txtFIELD1_1_6;
            TempData["txtFIELD1_1_7"] = createItem.txtFIELD1_1_7;
            TempData["txtFIELD1_2_1"] = createItem.txtFIELD1_2_1;
            TempData["txtFIELD1_2_2"] = createItem.txtFIELD1_2_2;
            TempData["txtFIELD1_2_3"] = createItem.txtFIELD1_2_3;
            TempData["txtFIELD1_2_4"] = createItem.txtFIELD1_2_4;
            TempData["txtFIELD1_2_5"] = createItem.txtFIELD1_2_5;
            TempData["txtFIELD_1_Comments"] = createItem.txtFIELD_1_Comments;

            TempData["txtFIELD2_1_1"] = createItem.txtFIELD2_1_1;
            TempData["txtFIELD2_1_2"] = createItem.txtFIELD2_1_2;
            TempData["txtFIELD2_2_1"] = createItem.txtFIELD2_2_1;
            TempData["txtFIELD2_2_1_1"] = createItem.txtFIELD2_2_1_1;
            TempData["txtFIELD2_2_1_2"] = createItem.txtFIELD2_2_1_2;
            TempData["txtFIELD2_2_1_3"] = createItem.txtFIELD2_2_1_3;
            TempData["txtFIELD2_2_2"] = createItem.txtFIELD2_2_2;
            TempData["txtFIELD2_2_2_1"] = createItem.txtFIELD2_2_2_1;
            TempData["txtFIELD2_2_2_2"] = createItem.txtFIELD2_2_2_2;
            TempData["txtFIELD2_2_2_3"] = createItem.txtFIELD2_2_2_3;
            TempData["txtFIELD_2_Comments"] = createItem.txtFIELD_2_Comments;

            TempData["txtFIELD3_1"] = createItem.txtFIELD3_1;
            TempData["txtFIELD3_2"] = createItem.txtFIELD3_2;
            TempData["txtFIELD_3_Comments"] = createItem.txtFIELD_3_Comments;

            TempData["txtFIELD4_1_1"] = createItem.txtFIELD4_1_1;
            TempData["txtFIELD4_1_2"] = createItem.txtFIELD4_1_2;
            TempData["txtFIELD4_1_3"] = createItem.txtFIELD4_1_3;
            TempData["txtFIELD4_1_4_1"] = createItem.txtFIELD4_1_4_1;
            TempData["txtFIELD4_1_4_2"] = createItem.txtFIELD4_1_4_2;
            TempData["txtFIELD4_1_4_3"] = createItem.txtFIELD4_1_4_3;
            TempData["txtFIELD4_1_5_1"] = createItem.txtFIELD4_1_5_1;
            TempData["txtFIELD4_1_5_2"] = createItem.txtFIELD4_1_5_2;
            TempData["txtFIELD4_1_5_3"] = createItem.txtFIELD4_1_5_3;
            TempData["txtFIELD4_1_6_1"] = createItem.txtFIELD4_1_6_1;
            TempData["txtFIELD4_1_6_2"] = createItem.txtFIELD4_1_6_2;
            TempData["txtFIELD4_1_6_3"] = createItem.txtFIELD4_1_6_3;
            TempData["txtFIELD4_2_1"] = createItem.txtFIELD4_2_1;
            TempData["txtFIELD4_2_2"] = createItem.txtFIELD4_2_2;
            TempData["txtFIELD4_2_3"] = createItem.txtFIELD4_2_3;
            TempData["txtFIELD4_2_4_1"] = createItem.txtFIELD4_2_4_1;
            TempData["txtFIELD4_2_4_2"] = createItem.txtFIELD4_2_4_2;
            TempData["txtFIELD4_2_4_3"] = createItem.txtFIELD4_2_4_3;
            TempData["txtFIELD4_2_5_1"] = createItem.txtFIELD4_2_5_1;
            TempData["txtFIELD4_2_5_2"] = createItem.txtFIELD4_2_5_2;
            TempData["txtFIELD4_2_5_3"] = createItem.txtFIELD4_2_5_3;
            TempData["txtFIELD4_2_6_1"] = createItem.txtFIELD4_2_6_1;
            TempData["txtFIELD4_2_6_2"] = createItem.txtFIELD4_2_6_2;
            TempData["txtFIELD4_2_6_3"] = createItem.txtFIELD4_2_6_3;
            TempData["txtFIELD4_3_1"] = createItem.txtFIELD4_3_1;
            TempData["txtFIELD4_3_2"] = createItem.txtFIELD4_3_2;
            TempData["txtFIELD4_3_3"] = createItem.txtFIELD4_3_3;
            TempData["txtFIELD4_3_4_1"] = createItem.txtFIELD4_3_4_1;
            TempData["txtFIELD4_3_4_2"] = createItem.txtFIELD4_3_4_2;
            TempData["txtFIELD4_3_4_3"] = createItem.txtFIELD4_3_4_3;
            TempData["txtFIELD4_3_5_1"] = createItem.txtFIELD4_3_5_1;
            TempData["txtFIELD4_3_5_2"] = createItem.txtFIELD4_3_5_2;
            TempData["txtFIELD4_3_5_3"] = createItem.txtFIELD4_3_5_3;
            TempData["txtFIELD4_3_6_1"] = createItem.txtFIELD4_3_6_1;
            TempData["txtFIELD4_3_6_2"] = createItem.txtFIELD4_3_6_2;
            TempData["txtFIELD4_3_6_3"] = createItem.txtFIELD4_3_6_3;
            TempData["txtFIELD_4_Comments"] = createItem.txtFIELD_4_Comments;

            TempData["txtFIELD5_1"] = createItem.txtFIELD5_1;
            TempData["txtFIELD5_2"] = createItem.txtFIELD5_2;
            TempData["txtFIELD5_3"] = createItem.txtFIELD5_3;
            TempData["txtFIELD5_4"] = createItem.txtFIELD5_4;
            TempData["txtFIELD_5_Comments"] = createItem.txtFIELD_5_Comments;

            TempData["txtFIELD6_1_1"] = createItem.txtFIELD6_1_1;
            TempData["txtFIELD6_1_2"] = createItem.txtFIELD6_1_2;
            TempData["txtFIELD6_1_3"] = createItem.txtFIELD6_1_3;
            TempData["txtFIELD6_2_1"] = createItem.txtFIELD6_2_1;
            TempData["txtFIELD6_2_2"] = createItem.txtFIELD6_2_2;
            TempData["txtFIELD6_2_3"] = createItem.txtFIELD6_2_3;
            TempData["txtFIELD6_3_1"] = createItem.txtFIELD6_3_1;
            TempData["txtFIELD6_3_2"] = createItem.txtFIELD6_3_2;
            TempData["txtFIELD6_3_3"] = createItem.txtFIELD6_3_3;
            TempData["txtFIELD_6_Comments"] = createItem.txtFIELD_6_Comments;

            TempData["txtFIELD7_1_1"] = createItem.txtFIELD7_1_1;
            TempData["txtFIELD7_1_2"] = createItem.txtFIELD7_1_2;
            TempData["txtFIELD7_1_3"] = createItem.txtFIELD7_1_3;
            TempData["txtFIELD_7_Comments"] = createItem.txtFIELD_7_Comments;

            TempData["txtFIELD8_1"] = createItem.txtFIELD8_1;
            TempData["txtFIELD8_2"] = createItem.txtFIELD8_2;
            TempData["txtFIELD8_3"] = createItem.txtFIELD8_3;
            TempData["txtFIELD_8_Comments"] = createItem.txtFIELD_8_Comments;

            TempData["txtFIELD9_1"] = createItem.txtFIELD9_1;
            TempData["txtFIELD9_2"] = createItem.txtFIELD9_2;
            TempData["txtFIELD_9_Comments"] = createItem.txtFIELD_9_Comments;

            TempData["txtFIELD10_1"] = createItem.txtFIELD10_1;
            TempData["txtFIELD_10_Comments"] = createItem.txtFIELD_10_Comments;

            TempData["txtFIELD11_1"] = createItem.txtFIELD11_1;
            TempData["txtFIELD11_2"] = createItem.txtFIELD11_2;
            TempData["txtFIELD_11_Comments"] = createItem.txtFIELD_11_Comments;

            TempData["txtFIELD_12_Comments"] = createItem.txtFIELD_12_Comments;

            TempData["emailAddress"] = emailAddress;
            TempData["modelUuid"] = modelUuid;
            TempData["nodeUuid"] = nodeUuid;

            var fromSelect = Request.Query["fromSelect"].FirstOrDefault();

            var submitForSave = Request.Query["submitForSave"].FirstOrDefault();
            if (!String.IsNullOrEmpty(submitForSave))
            {
                bool success = HandleSubmit(createItem);
                if (success)
                {

                    //TempData["reqJson"] = reqJson;
                    //TempData["resJson"] = resJson;
                    //TempData["responseStatusCode"] = responseStatusCode;
                    return Page();
                }
            }

            if (!String.IsNullOrEmpty(fromSelect))
            {
                return Page();
            }
            else
            {
                return RedirectToPage("Review");
            }
        }

        public void OnGetLoad()
        {
            txtCOURT = (string)TempData["txtCOURT"];
            dtFROM = (DateTime?)TempData["dtFROM"];
            dtTO = (DateTime?)TempData["dtTO"];
            intREPORTINGYEAR = (string)TempData["intREPORTINGYEAR"];

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
            txtFIELD2_2_1 = (int?)TempData["txtFIELD2_1_1"];
            txtFIELD2_2_1_1 = (int?)TempData["txtFIELD2_2_1_1"];
            txtFIELD2_2_1_2 = (int?)TempData["txtFIELD2_2_1_2"];
            txtFIELD2_2_1_3 = (int?)TempData["txtFIELD2_2_1_3"];
            txtFIELD2_2_2 = (int?)TempData["txtFIELD2_1_2"];
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

            sectId = (string?)TempData["sectionId"];
        }

        public IActionResult LoadFiles(InputFileChangeEventArgs e)
        {
            try
            {
                IBrowserFile file = e.File;
                if (file != null)
                {
                    if (file?.Size > maxFileSize)
                    {

                        return Page();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Page();
        }

        public IActionResult OnPostBasicInfo()
        {
            if (!ModelState.IsValid)
                return Page();

            SetValuesInTempData();

            TempData["sectionId"] = "1";
            return RedirectToPage("Create", "Load");
        }

        public IActionResult OnPostDetails1()
        {
            if (!ModelState.IsValid)
                return Page();

            SetValuesInTempData();

            TempData["sectionId"] = "2";
            return RedirectToPage("Create", "Load");
        }

        public void SetValuesInTempData()
        {
            TempData["txtCOURT"] = txtCOURT;
            TempData["dtFROM"] = dtFROM;
            TempData["dtTO"] = dtTO;
            TempData["intREPORTINGYEAR"] = intREPORTINGYEAR;

            TempData["txtFIELD1_1_1"] = txtFIELD1_1_1;
            TempData["txtFIELD1_1_2"] = txtFIELD1_1_2;
            TempData["txtFIELD1_1_3"] = txtFIELD1_1_3;
            TempData["txtFIELD1_1_4"] = txtFIELD1_1_4;
            TempData["txtFIELD1_1_5"] = txtFIELD1_1_5;
            TempData["txtFIELD1_1_6"] = txtFIELD1_1_6;
            TempData["txtFIELD1_1_7"] = txtFIELD1_1_7;
            TempData["txtFIELD1_2_1"] = txtFIELD1_2_1;
            TempData["txtFIELD1_2_2"] = txtFIELD1_2_2;
            TempData["txtFIELD1_2_3"] = txtFIELD1_2_3;
            TempData["txtFIELD1_2_4"] = txtFIELD1_2_4;
            TempData["txtFIELD1_2_5"] = txtFIELD1_2_5;
            TempData["txtFIELD_1_Comments"] = txtFIELD_1_Comments;

            TempData["txtFIELD2_1_1"] = txtFIELD2_1_1;
            TempData["txtFIELD2_1_2"] = txtFIELD2_1_2;
            TempData["txtFIELD2_2_1"] = txtFIELD2_2_1;
            TempData["txtFIELD2_2_1_1"] = txtFIELD2_2_1_1;
            TempData["txtFIELD2_2_1_2"] = txtFIELD2_2_1_2;
            TempData["txtFIELD2_2_1_3"] = txtFIELD2_2_1_3;
            TempData["txtFIELD2_2_2"] = txtFIELD2_2_2;
            TempData["txtFIELD2_2_2_1"] = txtFIELD2_2_2_1;
            TempData["txtFIELD2_2_2_2"] = txtFIELD2_2_2_2;
            TempData["txtFIELD2_2_2_3"] = txtFIELD2_2_2_3;
            TempData["txtFIELD_2_Comments"] = txtFIELD_2_Comments;

            TempData["txtFIELD3_1"] = txtFIELD3_1;
            TempData["txtFIELD3_2"] = txtFIELD3_2;
            TempData["txtFIELD_3_Comments"] = txtFIELD_3_Comments;

            TempData["txtFIELD4_1_1"] = txtFIELD4_1_1;
            TempData["txtFIELD4_1_2"] = txtFIELD4_1_2;
            TempData["txtFIELD4_1_3"] = txtFIELD4_1_3;
            TempData["txtFIELD4_1_4_1"] = txtFIELD4_1_4_1;
            TempData["txtFIELD4_1_4_2"] = txtFIELD4_1_4_2;
            TempData["txtFIELD4_1_4_3"] = txtFIELD4_1_4_3;
            TempData["txtFIELD4_1_5_1"] = txtFIELD4_1_5_1;
            TempData["txtFIELD4_1_5_2"] = txtFIELD4_1_5_2;
            TempData["txtFIELD4_1_5_3"] = txtFIELD4_1_5_3;
            TempData["txtFIELD4_1_6_1"] = txtFIELD4_1_6_1;
            TempData["txtFIELD4_1_6_2"] = txtFIELD4_1_6_2;
            TempData["txtFIELD4_1_6_3"] = txtFIELD4_1_6_3;
            TempData["txtFIELD4_2_1"] = txtFIELD4_2_1;
            TempData["txtFIELD4_2_2"] = txtFIELD4_2_2;
            TempData["txtFIELD4_2_3"] = txtFIELD4_2_3;
            TempData["txtFIELD4_2_4_1"] = txtFIELD4_2_4_1;
            TempData["txtFIELD4_2_4_2"] = txtFIELD4_2_4_2;
            TempData["txtFIELD4_2_4_3"] = txtFIELD4_2_4_3;
            TempData["txtFIELD4_2_5_1"] = txtFIELD4_2_5_1;
            TempData["txtFIELD4_2_5_2"] = txtFIELD4_2_5_2;
            TempData["txtFIELD4_2_5_3"] = txtFIELD4_2_5_3;
            TempData["txtFIELD4_2_6_1"] = txtFIELD4_2_6_1;
            TempData["txtFIELD4_2_6_2"] = txtFIELD4_2_6_2;
            TempData["txtFIELD4_2_6_3"] = txtFIELD4_2_6_3;
            TempData["txtFIELD4_3_1"] = txtFIELD4_3_1;
            TempData["txtFIELD4_3_2"] = txtFIELD4_3_2;
            TempData["txtFIELD4_3_3"] = txtFIELD4_3_3;
            TempData["txtFIELD4_3_4_1"] = txtFIELD4_3_4_1;
            TempData["txtFIELD4_3_4_2"] = txtFIELD4_3_4_2;
            TempData["txtFIELD4_3_4_3"] = txtFIELD4_3_4_3;
            TempData["txtFIELD4_3_5_1"] = txtFIELD4_3_5_1;
            TempData["txtFIELD4_3_5_2"] = txtFIELD4_3_5_2;
            TempData["txtFIELD4_3_5_3"] = txtFIELD4_3_5_3;
            TempData["txtFIELD4_3_6_1"] = txtFIELD4_3_6_1;
            TempData["txtFIELD4_3_6_2"] = txtFIELD4_3_6_2;
            TempData["txtFIELD4_3_6_3"] = txtFIELD4_3_6_3;
            TempData["txtFIELD_4_Comments"] = txtFIELD_4_Comments;

            TempData["txtFIELD5_1"] = txtFIELD5_1;
            TempData["txtFIELD5_2"] = txtFIELD5_2;
            TempData["txtFIELD5_3"] = txtFIELD5_3;
            TempData["txtFIELD5_4"] = txtFIELD5_4;
            TempData["txtFIELD_5_Comments"] = txtFIELD_5_Comments;

            TempData["txtFIELD6_1_1"] = txtFIELD6_1_1;
            TempData["txtFIELD6_1_2"] = txtFIELD6_1_2;
            TempData["txtFIELD6_1_3"] = txtFIELD6_1_3;
            TempData["txtFIELD6_2_1"] = txtFIELD6_2_1;
            TempData["txtFIELD6_2_2"] = txtFIELD6_2_2;
            TempData["txtFIELD6_2_3"] = txtFIELD6_2_3;
            TempData["txtFIELD6_3_1"] = txtFIELD6_3_1;
            TempData["txtFIELD6_3_2"] = txtFIELD6_3_2;
            TempData["txtFIELD6_3_3"] = txtFIELD6_3_3;
            TempData["txtFIELD_6_Comments"] = txtFIELD_6_Comments;

            TempData["txtFIELD7_1_1"] = txtFIELD7_1_1;
            TempData["txtFIELD7_1_2"] = txtFIELD7_1_2;
            TempData["txtFIELD7_1_3"] = txtFIELD7_1_3;
            TempData["txtFIELD_7_Comments"] = txtFIELD_7_Comments;

            TempData["txtFIELD8_1"] = txtFIELD8_1;
            TempData["txtFIELD8_2"] = txtFIELD8_2;
            TempData["txtFIELD8_3"] = txtFIELD8_3;
            TempData["txtFIELD_8_Comments"] = txtFIELD_8_Comments;

            TempData["txtFIELD9_1"] = txtFIELD9_1;
            TempData["txtFIELD9_2"] = txtFIELD9_2;
            TempData["txtFIELD_9_Comments"] = txtFIELD_9_Comments;

            TempData["txtFIELD10_1"] = txtFIELD10_1;
            TempData["txtFIELD_10_Comments"] = txtFIELD_10_Comments;

            TempData["txtFIELD11_1"] = txtFIELD11_1;
            TempData["txtFIELD11_2"] = txtFIELD11_2;
            TempData["txtFIELD_11_Comments"] = txtFIELD_11_Comments;

            TempData["txtFIELD_12_Comments"] = txtFIELD_12_Comments;
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
                value = "DRAFT",
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
            //reqJson = json;
            //resJson = "";
            var responseStatusCode = "200";

            var apiEndpoint = _configuration.GetValue<string>("SaveURL1");

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
                        var casResponseModel = JsonConvert.DeserializeObject<CasModel>(apiResponse);
                        modelUuid = casResponseModel.uuid;
                        nodeUuid = casResponseModel.nodes[0].uuid;
                    }
                    responseStatusCode = response.StatusCode.ToString();
                }
            }

            return true;
        }
    }
}
