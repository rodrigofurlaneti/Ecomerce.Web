using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Domain.Model
{
    [Table("Category")]
    public class CartPurchaseItem : Base
    {
        [Key]
        public int CartPurchaseItemId { get; set; }

        public Product? Product { get; set; }

        public int Amount { get; set; }

        [StringLength(200)]
        public string? ShoppingCartId { get; set; }
    }
}
