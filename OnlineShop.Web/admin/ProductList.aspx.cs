using OnlineShop.Application;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.admin
{
    public partial class ProductList : System.Web.UI.Page
    {
        ProductManager productManager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                ApplicationDbContext context = new ApplicationDbContext();
                productManager = new ProductManager(context);
                var products = productManager.GetAll().Include(i => i.Category).ToList();
                gvProducts.DataSource = products;
                gvProducts.DataBind();
                gvLoadProduts();

            }
            gvProducts.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            gvLoadProduts();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvProducts.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            gvLoadProduts(); // Vuelve a cargar los productos con el nuevo tamaño de página
        }

        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducts.PageIndex = e.NewPageIndex;
            gvLoadProduts(); // Carga los datos de la página seleccionada
        }

        protected void gvLoadProduts()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);
            var products = productManager.GetAll().Include(i => i.Category).ToList();
            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }

        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("ProductEdit.aspx?id=" + id);
            }
        }

        //private void LoadProducts()
        //{

        //    var products = productManager.GetAll().Include(i => i.Category).ToList();
        //    ProductsListView.DataSource = products;
        //    ProductsListView.DataBind();
        //}

        protected void lnkName_Command(object sender, CommandEventArgs e)
        {
            // Obtén el ID del CommandArgument
            string id = e.CommandArgument.ToString();

            // Redirige a la página deseada con el ID en la URL
            Response.Redirect("ProductEdit.aspx?id=" + id);
        }


    }
}
