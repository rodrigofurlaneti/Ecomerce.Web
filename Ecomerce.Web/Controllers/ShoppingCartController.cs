using Ecomerce.Domain.Models;
using Ecomerce.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Product = Ecomerce.Web.Model.Product;

namespace Ecomerce.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Ecomerce.Web.Model.ShoppingCart _shoppingCart;
        public ShoppingCartController(ILogger<HomeController> logger,
            Ecomerce.Web.Model.ShoppingCart shoppingCart)
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
