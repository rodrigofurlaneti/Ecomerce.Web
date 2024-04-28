using Ecomerce.Domain.Entities;
using System;

namespace Ecomerce.Web.Helpers
{
    public class ShoppingCartHelper
    {
        public ShoppingCartHelper()
        {
            
        }

        public static ShoppingCartEntity GetShoppingCart(IServiceProvider services)
        {
            //Define a session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Get or generate the cart ID
            string shoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            //Assigns the cart id in the Session
            session.SetString("ShoppingCartId", shoppingCartId);

            //Returns the cart with the context and the assigned or obtained Id
            ShoppingCartEntity shoppingCartEntity = new ShoppingCartEntity();

            shoppingCartEntity.ShoppingCartId = shoppingCartId;

            return shoppingCartEntity;
        }

        //public void AdicionarAoCarrinho(Lanche lanche)
        //{
        //    var carrinhoCompraItem = _context.ShoppingCartEntityItens.SingleOrDefault(
        //             s => s.Lanche.LancheId == lanche.LancheId &&
        //             s.ShoppingCartEntityId == ShoppingCartEntityId);

        //    if (carrinhoCompraItem == null)
        //    {
        //        carrinhoCompraItem = new ShoppingCartEntityItem
        //        {
        //            ShoppingCartEntityId = ShoppingCartEntityId,
        //            Lanche = lanche,
        //            Quantidade = 1
        //        };
        //        _context.ShoppingCartEntityItens.Add(carrinhoCompraItem);
        //    }
        //    else
        //    {
        //        carrinhoCompraItem.Quantidade++;
        //    }
        //    _context.SaveChanges();
        //}

        //public int RemoverDoCarrinho(Lanche lanche)
        //{
        //    var carrinhoCompraItem = _context.ShoppingCartEntityItens.SingleOrDefault(
        //           s => s.Lanche.LancheId == lanche.LancheId &&
        //           s.ShoppingCartEntityId == ShoppingCartEntityId);

        //    var quantidadeLocal = 0;

        //    if (carrinhoCompraItem != null)
        //    {
        //        if (carrinhoCompraItem.Quantidade > 1)
        //        {
        //            carrinhoCompraItem.Quantidade--;
        //            quantidadeLocal = carrinhoCompraItem.Quantidade;
        //        }
        //        else
        //        {
        //            _context.ShoppingCartEntityItens.Remove(carrinhoCompraItem);
        //        }
        //    }
        //    _context.SaveChanges();
        //    return quantidadeLocal;
        //}

        //public List<ShoppingCartEntityItem> GetShoppingCartEntityItens()
        //{
        //    return ShoppingCartEntityItems ??
        //           (ShoppingCartEntityItems =
        //               _context.ShoppingCartEntityItens.Where(c => c.ShoppingCartEntityId == ShoppingCartEntityId)
        //                   .Include(s => s.Lanche)
        //                   .ToList());
        //}

        //public void LimparCarrinho()
        //{
        //    var carrinhoItens = _context.ShoppingCartEntityItens
        //                         .Where(carrinho => carrinho.ShoppingCartEntityId == ShoppingCartEntityId);

        //    _context.ShoppingCartEntityItens.RemoveRange(carrinhoItens);
        //    _context.SaveChanges();
        //}

        //public decimal GetShoppingCartEntityTotal()
        //{
        //    var total = _context.ShoppingCartEntityItens.Where(c => c.ShoppingCartEntityId == ShoppingCartEntityId)
        //        .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
        //    return total;
        //}
    }
}
