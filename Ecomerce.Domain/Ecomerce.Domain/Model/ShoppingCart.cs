using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Domain.Model
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        [Key]
        public string? ShoppingCartId { get; set; }


        public List<CartPurchaseItem>? CartPurchaseItems { get; set; }


    }
}
