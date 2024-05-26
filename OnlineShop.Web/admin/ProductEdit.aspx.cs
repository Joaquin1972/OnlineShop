using OnlineShop.Application;
using OnlineShop.Core;
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

                ID.Text = productId.ToString();
                txtProduct.Text = product.Name;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
                txtStock.Text = product.Stock.ToString();
                ddlCategory.SelectedValue = product.Category_Id.ToString();
                if (product != null && product.Images != null && product.Images.Count > 0)
                {
                    var firstImage = product.Images.FirstOrDefault();
                    if (firstImage != null)
                    {
                        ProductImage.ImageUrl = firstImage.ImagePath;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores, como mostrar un mensaje al usuario
                Response.Write($"Error al cargar el producto: {ex.Message}");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Genero el contexto de Datos
            ApplicationDbContext context = new ApplicationDbContext();
            ProductManager productManager = new ProductManager(context);
            //Cargo valores actualizados
            Product product = new Product
            {
                Id = Convert.ToInt32(ID.Text),
                Name = txtProduct.Text,
                Description = txtDescription.Text,
                Price = Convert.ToDecimal(txtPrice.Text),
                Stock = Convert.ToInt32(txtStock.Text),
                Category_Id = Convert.ToInt32(ddlCategory.SelectedValue)
            };
            productManager.Update(product);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
            //Creo el contexto de datos
            ApplicationDbContext context = new ApplicationDbContext();
            ProductManager productManager = new ProductManager(context);
            int productId = Convert.ToInt32(ID.Text);

            Product product = context.Products.Find(productId);
            productManager.Remove(product);
            productManager.Context.SaveChanges();
            ID.Text = "Borrado";
            txtProduct.Text = "Borrado";
            txtDescription.Text = "Borrado";
            txtPrice.Text = "Borrado";
            txtStock.Text = "Borrado";

        }
    }
}
