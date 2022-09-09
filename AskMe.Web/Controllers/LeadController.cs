using AskMe.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AskMe.Web.Controllers
{
    public class LeadController : Controller
    {
        public IActionResult AddLead(LeadViewModel leadViewModel)
        {
            return RedirectToAction("Index", "AskMe");
        }
    }
}
