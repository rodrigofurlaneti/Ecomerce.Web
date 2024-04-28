namespace Ecomerce.Domain.Entities
{
    public class ShoppingCartEntity
    {
        public string ShoppingCartId { get; set; }
        public List<CartPurchaseItem> CartPurchaseItems { get; set; }
    }
}
