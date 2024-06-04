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
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Creo el contexto de datos
        ApplicationDbContext context = new ApplicationDbContext();
        CategoryManager categoryManager;
        //Cargo categorias al cargar la página
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryManager = new CategoryManager(context);
                LoadCategories();
            }
        }

        //Botón para crear la categoría
        public void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Category category = new Category
                {
                    CategoryName = txtCategory.Text,
                };
                categoryManager.Add(category);
                categoryManager.Context.SaveChanges();

            }
            catch (Exception ex)
            {
                // Manejo de errores
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al guardar" + ex.Message,
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
            finally
            {
                txtCategory.Text = "";
                LoadCategories();
            }
        }

        public void LoadCategories()
        {
            // Cargo todas las categorías existentes
            var categories = categoryManager.GetAll().ToList();

            // Construyo el Grid View
            gvCategories.DataSource = categories;
            gvCategories.DataBind();
        }
    }
}