using Ecomerce.Service.Service.Register;
using Ecomerce.Service.Service.User;
using Ecomerce.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            this._registerService = registerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("ActivateYourRegistration")]
        [HttpPost]
        public async Task<IActionResult> ActivateYourRegistration()
        {
            var modelFormCollection = Request.Form;

            if (modelFormCollection != null)
            {
                var model = RegisterHelper.DeparaViewToController(modelFormCollection);

                await _registerService.PostAsync(model);
            }
            return View();
        }
    }
}
