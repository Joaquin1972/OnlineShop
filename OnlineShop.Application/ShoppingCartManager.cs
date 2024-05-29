using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application
{
    public class ShoppingCartManager : GenericManager<ShoppingCart>
    {
        public ShoppingCartManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
