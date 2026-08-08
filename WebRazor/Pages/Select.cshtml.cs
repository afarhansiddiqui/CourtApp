using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebRazor.Models;

namespace WebRazor.Pages
{
    [Breadcrumb("ViewData.Home")]
    public class SelectModel : PageModel
    {
        [BindProperty]
        public string? emailAddress { get; set; }

        public void OnGet()
        {
            // var userEmail = User.FindFirstValue(;

            //var userEmail = User.FindFirstValue(ClaimTypes.Name)
            //             ?? User.FindFirstValue("name")    // OpenID Connect / some providers
            //             ?? User.FindFirstValue(ClaimTypes.NameIdentifier)
            //             ?? User.FindFirstValue("subject");    // JWT subject

            var userEmail = "abc";

            if (!string.IsNullOrEmpty(userEmail))
            {
                emailAddress = userEmail + "@example.com";
            }
        }
        public IActionResult OnPost()
        {
            TempData["emailAddress"] = emailAddress;
            return RedirectToPage("/Create", new { retrieveRecord = "true" });
        }
    }
}
