using Ecomerce.Service.Service.PhysicalPerson;
using Ecomerce.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Web.Controllers
{
    public class PhysicalPersonController : Controller
    {
        private readonly IPhysicalPersonService _physicalPersonService;

        public PhysicalPersonController(IPhysicalPersonService physicalPersonService)
        {
            this._physicalPersonService = physicalPersonService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("ActivateYourRegistration_PhysicalPerson")]
        [HttpPost]
        public async Task<IActionResult> ActivateYourRegistration_PhysicalPerson()
        {
            var modelFormCollection = Request.Form;

            if (modelFormCollection != null)
            {
                var model = PhysicalPersonHelper.DeparaViewToController_PhysicalPerson(modelFormCollection);

                await _physicalPersonService.PostAsync(model);
            }
            return View();
        }
    }
}
