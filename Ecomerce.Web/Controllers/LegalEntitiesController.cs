using Ecomerce.Service.Service.Legal;
using Ecomerce.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Web.Controllers
{
    public class LegalController : Controller
    {
        private readonly ILegalService _registerService;

        public LegalController(ILegalService registerService)
        {
            this._registerService = registerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("ActivateYourRegistration_Legal")]
        [HttpPost]
        public async Task<IActionResult> ActivateYourRegistration_Legal()
        {
            var modelFormCollection = Request.Form;

            if (modelFormCollection != null)
            {
                var model = LegalHelper.DeparaViewToController_Legal(modelFormCollection);

                await _registerService.PostAsync(model);
            }
            return View();
        }
    }
}
