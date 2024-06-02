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
        CategoryManager categoryManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext(); ;
            categoryManager = new CategoryManager(context);
            LoadCategories();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
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

        protected void LoadCategories()
        {
            // Retrieve all categories and convert to a list
            var categories = categoryManager.GetAll().ToList();

            // Bind the list to the GridView
            gvCategories.DataSource = categories;
            gvCategories.DataBind();
        }



    }
}