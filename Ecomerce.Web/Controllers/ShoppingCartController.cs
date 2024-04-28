using Ecomerce.Web.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(ILogger<HomeController> logger,
            ShoppingCart shoppingCart)
        {
            _logger = logger;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
