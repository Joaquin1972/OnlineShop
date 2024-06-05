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
        // Creo el contexto de datos
        CategoryManager categoryManager = null;



        // Cargo categorías al cargar la página
        public void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                categoryManager = new CategoryManager(context);
                LoadCategories();
            }
        }

        // Botón para crear la categoría
        public void BtnSubmit_Click(object sender, EventArgs e)
        {
            AddCategory();
        }

        private void AddCategory()
        {
            try
            {
                ApplicationDbContext context = new ApplicationDbContext();
                categoryManager = new CategoryManager(context);
                string categoryName = txtCategory.Text.Trim();
                if (!string.IsNullOrEmpty(categoryName))
                {
                    Category category = new Category
                    {
                        CategoryName = categoryName,
                    };
                    categoryManager.Add(category);
                    context.SaveChanges();
                    txtCategory.Text = string.Empty;
                    LoadCategories();
                }

            }
            catch (Exception ex)
            {
                // Manejo de errores
                var err = new CustomValidator
                {
                    ErrorMessage = "Error al añadir la categoria",
                    IsValid = false
                };
                Page.Validators.Add(err);

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

