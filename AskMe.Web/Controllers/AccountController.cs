using Microsoft.AspNetCore.Mvc;

namespace AskMe.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
