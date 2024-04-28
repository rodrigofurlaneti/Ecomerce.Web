using Ecomerce.Web.Context;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Web.Model
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _context; 

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

        public void AddToCart(Product product)
        {
                var cartPurchaseItem = _context.CartPurchaseItem.SingleOrDefault(
                     s => s.Product.ProductId == product.ProductId &&
                     s.ShoppingCartId == ShoppingCartId);

                if (cartPurchaseItem == null)
                {
                    int cartPurchaseItemId = 1;
                    cartPurchaseItem = new CartPurchaseItem
                    {
                        CartPurchaseItemId = cartPurchaseItemId,
                        Product = product,
                        Amount = 1
                    };
                    _context.CartPurchaseItem.Add(cartPurchaseItem);
                }
                else
                {
                    cartPurchaseItem.Amount++;
                }
                _context.SaveChanges();

        }

        public int RemoveFromCart(Product product)
        {
            var cartPurchaseItem = _context.CartPurchaseItem.SingleOrDefault(
                   s => s.Product.ProductId == product.ProductId &&
                   s.ShoppingCartId == ShoppingCartId);

            var quantidadeLocal = 0;

            if (cartPurchaseItem != null)
            {
                if (cartPurchaseItem.Amount > 1)
                {
                    cartPurchaseItem.Amount--;
                    quantidadeLocal = cartPurchaseItem.Amount;
                }
                else
                {
                    _context.CartPurchaseItem.Remove(cartPurchaseItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public void ClearCart()
        {
            var carrinhoItens = _context.CartPurchaseItem
                                 .Where(carrinho => carrinho.ShoppingCartId == ShoppingCartId);

            _context.CartPurchaseItem.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetTotalShoppingCart()
        {
            var total = _context.CartPurchaseItem.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
            return total;
        }
    }
}
