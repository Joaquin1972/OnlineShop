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
    public partial class ProductEdit : System.Web.UI.Page
    {
        CategoryManager categoryManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar el ID de la consulta
                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    // Aquí puedes llamar a un método para cargar los detalles del producto
                    // utilizando el ID recuperado
                    LoadProduct(id);
                }
                else
                {
                    // Manejar el caso donde el ID no esté presente o sea inválido
                    // Esto puede incluir redirigir a una página de error o mostrar un mensaje
                    Response.Write("ID no válido.");
                }

            
                
                    ApplicationDbContext context = new ApplicationDbContext();
                    categoryManager = new CategoryManager(context);
                    var categories = categoryManager.GetAll().ToList();

                    ddlCategory.DataSource = categories;
                    ddlCategory.DataTextField = "CategoryName"; // Propiedad que se mostrará en el DropDownList
                    ddlCategory.DataValueField = "id";  // Propiedad que se usará como valor (usualmente un identificador único)
                    ddlCategory.DataBind();
                
            }
        }

        private void LoadProduct(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentException("El ID del producto no puede ser nulo o vacío.");
                }

                ApplicationDbContext context = new ApplicationDbContext();
                ProductManager productManager = new ProductManager(context);

                int productId;
                if (!int.TryParse(id, out productId))
                {
                    throw new FormatException("El ID del producto no tiene un formato válido.");
                }

                var product = productManager.GetById(productId);
                if (product == null)
                {
                    throw new Exception("Producto no encontrado.");
                }


                txtProduct.Text = product.Name;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
                txtStock.Text = product.Stock.ToString();
                ddlCategory.SelectedValue = product.Category_Id.ToString();
                ProductImage.ImageUrl = product.ImagePath;
            }
            catch (Exception ex)
            {
                // Manejo de errores, como mostrar un mensaje al usuario
                Response.Write($"Error al cargar el producto: {ex.Message}");
            }
        }
    }
}
