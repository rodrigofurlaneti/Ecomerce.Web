using Ecomerce.Domain.Entities;
using Ecomerce.Service.Service;
using Ecomerce.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShoppingCartHelper _shoppingCartHelper;
        public ShoppingCartController(ILogger<HomeController> logger, ShoppingCartHelper shoppingCartHelper)
        {
            _logger = logger;
            _shoppingCartHelper = shoppingCartHelper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
