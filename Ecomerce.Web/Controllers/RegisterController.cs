using Ecomerce.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService _userService;

        public IActionResult Index()
        {
            return View();
        }


        [Route("ActivateYourRegistration")]
        [HttpPost]
        public IActionResult ActivateYourRegistration()
        {
            var modelFormCollection = Request.Form;

            if (modelFormCollection != null)
            {
                var model = RegisterHelper.DeparaViewToController(modelFormCollection);

                
            }
            return View();
        }
    }
}
