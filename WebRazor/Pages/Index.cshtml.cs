using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBreadcrumbs.Attributes;
using WebRazor.Models;

namespace WebRazor.Pages
{
    [DefaultBreadcrumb]
    public class IndexModel : PageModel
    {
    }
}
