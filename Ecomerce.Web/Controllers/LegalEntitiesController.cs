using Ecomerce.Service.Service.LegalEntities;
using Ecomerce.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Web.Controllers
{
    public class LegalEntitiesController : Controller
    {
        private readonly ILegalEntitiesService _registerService;

        public LegalEntitiesController(ILegalEntitiesService registerService)
        {
            this._registerService = registerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("ActivateYourRegistration_LegalEntities")]
        [HttpPost]
        public async Task<IActionResult> ActivateYourRegistration_LegalEntities()
        {
            var modelFormCollection = Request.Form;

            if (modelFormCollection != null)
            {
                var model = LegalEntitiesHelper.DeparaViewToController_LegalEntities(modelFormCollection);

                await _registerService.PostAsync(model);
            }
            return View();
        }
    }
}
