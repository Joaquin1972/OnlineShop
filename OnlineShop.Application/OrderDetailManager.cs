using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application
{
    public class OrderDetailManager : GenericManager<OrderDetail>
    {
        public OrderDetailManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
