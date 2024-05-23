using OnlineShop.Application;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.admin
{
    public partial class ProductList : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {

            var context = new ApplicationDbContext();
            var productManager = new ProductManager(context);
            var products = productManager.GetAll().ToList();
            ProductsRepeater.DataSource = products;
            ProductsRepeater.DataBind();
        }
    }
}
