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

        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Creo el contexto de datos de los productos.
                ApplicationDbContext context = new ApplicationDbContext();
                productManager = new ProductManager(context);
                var products = productManager.GetAll().Include(i => i.Category).ToList();
            }
            gvProducts.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            LoadProduts();
        }

        // Vuelve a cargar los productos con el nuevo tamaño de página
        public void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvProducts.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            LoadProduts();
        }

        // Carga los datos de la página seleccionada
        public void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducts.PageIndex = e.NewPageIndex;
            LoadProduts();
        }

        //Cargo los productos y los ordeno por Id, el más reciente se verá al principio
        public void LoadProduts()
        {
            //Creo el contexto de datos
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);
            var products = productManager.GetAll().
                Include(i => i.Category).
                Include(p => p.Images).
                OrderByDescending
                (p => p.Id).ToList();

            //Construyo el GV con el listado de los productos
            var productList = products.Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
                p.Price,
                p.Stock,
                p.Category.CategoryName,
                //CategoryName = p.Category.CategoryName,
                FirstImagePath = p.Images != null && p.Images.Count > 0 ? p.Images.First().ImagePath : Session["UploadedFilePath"]
            }).ToList();


            gvProducts.DataSource = productList;
            gvProducts.DataBind();
        }



        //Redirecciono a la página concreto del producto. Le envío la Id para cargar 
        //el producto en concreto
        public void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("ProductEdit.aspx?id=" + id);
            }
        }




        public void gvProducts_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            // Obtener el Id del producto seleccionado
            int selectedProductId = Convert.ToInt32(gvProducts.DataKeys[e.NewSelectedIndex].Value);
           // Response.Write(selectedProductId);
            // Redirigir a la otra página con el Id del producto
            Response.Redirect($"ProductEdit.aspx?Id={selectedProductId}");
        }
    }
}
