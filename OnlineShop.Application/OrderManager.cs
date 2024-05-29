using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application
{
    public class OrderManager : GenericManager<Order>
    {
        public OrderManager(ApplicationDbContext context) : base(context)
        {
        }

        public Order GetPendingOrderByUserId(string userId)
        {
            // Buscar un pedido pendiente para el usuario actual
            return Context.Orders.FirstOrDefault(o => o.User_Id == userId && o.Status == OrderStatus.Pending);
        }
    }
}
