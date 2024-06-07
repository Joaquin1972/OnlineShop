using OnlineShop.Application;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.client
{
    public partial class tienda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Construyo el Drow Data List para seleccionar las categorias a filtar
                LoadCategories();
                //Contruyo el listado de datos que se muestra al cliente
                BindDataList();
            }
        }

        //Cargo categorias
        private void LoadCategories()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            {
                var categories = context.Categories.ToList();
                ddlCategories.DataSource = categories;
                ddlCategories.DataTextField = "CategoryName";
                ddlCategories.DataValueField = "Id";
                ddlCategories.DataBind();
                ddlCategories.Items.Insert(0, new ListItem("Todas las categorías", "0"));
            }
        }

        //Función para crear el listado, inicialmente con "Todas las categorias"
        private void BindDataList(int categoryId = 0)
        {
            try
            {
                //Creo el contexto de datos
                ApplicationDbContext context = new ApplicationDbContext();

                //Selecciono los productos ordenador por Id descendiente
                var products = context.Products.Include(p => p.Category).Include(p => p.Images).OrderByDescending(p => p.Id).ToList();

                //Seleccion no la categoria
                if (categoryId > 0)
                {
                    products = products.Where(p => p.Category_Id == categoryId).ToList();
                }

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

                //Cargo y bindeo el Listado de datos por los productos seleccionados
                dlProducts.DataSource = productList;
                dlProducts.DataBind();

            }
            catch (Exception ex)
            {
                //Mostrar un mensaje de error en la página en la etiqueta
                lblError.Text = "Ocurrió un error al cargar los productos. Por favor, inténtelo de nuevo más tarde.";
                lblError.Visible = true;
            }
        }

        //Evento que se lanza cuando el selector de categorias cambia de selección
        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategoryId = int.Parse(ddlCategories.SelectedValue);
            BindDataList(selectedCategoryId);
        }

        // Función para mostrar el stock
        // Si > 0, mostrará Disponible, si <=0, mostrará Sin stock
        protected string GetStockText(int stock)
        {
            return stock > 0 ? "Disponible" : "Sin stock";
        }


        // Evento para cargar en otra página el producto seleccionado por Id al pulsar Seleccionar
        protected void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "SelectProduct")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("ProductEditClient.aspx?id=" + id);

            }
        }
    }
}
