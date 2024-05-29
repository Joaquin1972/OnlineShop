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
                //gvProducts.DataSource = products;
                //gvProducts.DataBind();
               

            }
            gvProducts.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            LoadProduts();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvProducts.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            LoadProduts(); // Vuelve a cargar los productos con el nuevo tamaño de página
        }

        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducts.PageIndex = e.NewPageIndex;
            LoadProduts(); // Carga los datos de la página seleccionada
        }

        protected void LoadProduts()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);
            var products = productManager.GetAll().
                Include(i => i.Category).
                Include(p => p.Images).
                OrderByDescending
                (p => p.Id).ToList();
            //gvProducts.DataSource = products;
            //gvProducts.DataBind();
            
            var productList = products.Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
                p.Price,
                p.Stock,
                CategoryName = p.Category.CategoryName,
                FirstImagePath = p.Images != null && p.Images.Count > 0 ? p.Images.First().ImagePath : Session["UploadedFilePath"]
            }).ToList();

            gvProducts.DataSource = productList;
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



        protected void gvProducts_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            // Obtener el Id del producto seleccionado
            int selectedProductId = Convert.ToInt32(gvProducts.DataKeys[e.NewSelectedIndex].Value);
            Response.Write(selectedProductId);
            // Redirigir a la otra página con el Id del producto
            Response.Redirect($"ProductEdit.aspx?Id={selectedProductId}");
        }
    }
}
