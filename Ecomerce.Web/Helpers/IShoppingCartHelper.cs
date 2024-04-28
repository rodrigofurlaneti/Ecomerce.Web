using Ecomerce.Domain.Entities;

namespace Ecomerce.Web.Helpers
{
    public interface IShoppingCartHelper
    {
        ShoppingCartEntity GetShoppingCart(IServiceProvider services);
    }
}
