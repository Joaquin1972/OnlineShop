using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application
{
    public class CategoryManager : GenericManager<Category>
    {
        public CategoryManager(ApplicationDbContext context) : base(context)
        {
        }


    }
}
