using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomerce.Domain.Entities
{
    public class CartPurchaseItem
    {
        public int CartPurchaseItemId { get; set; }
        public ProductEntity Product { get; set; }

        public int Amount { get; set; }

        [StringLength(200)]
        public string ShoppingCartId { get; set; }
    }
}
