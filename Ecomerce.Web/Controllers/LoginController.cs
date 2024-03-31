using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
