using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Web.Model
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        [Key]
        public string? ShoppingCartId { get; set; }


        public List<CartPurchaseItem>? CartPurchaseItems { get; set; }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            //Define a session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Get or generate the cart ID
            string shoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            //Assigns the cart id in the Session
            session.SetString("ShoppingCartId", shoppingCartId);

            //Returns the cart with the context and the assigned or obtained Id
            ShoppingCart shoppingCartEntity = new ShoppingCart();

            shoppingCartEntity.ShoppingCartId = shoppingCartId;

            return shoppingCartEntity;
        }
    }
}
