using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Web.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
