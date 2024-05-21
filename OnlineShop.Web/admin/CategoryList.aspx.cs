using OnlineShop.Application;
using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        CategoryManager categoryManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                categoryManager = new CategoryManager(context);
                LoadCategories();
            }
        }

        protected void LoadCategories()
        {
            var categories = categoryManager.GetAll().ToList();
            gvCategories.DataSource = categories;
            gvCategories.DataBind();
        }

        protected void gvCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRowIndex = gvCategories.SelectedIndex;
            string selectedCategory = gvCategories.SelectedRow.Cells[1].Text;
            txtCategory.Text = selectedCategory;
            string selectedId = gvCategories.SelectedRow.Cells[0].Text;
            txtId.Value = selectedId;
        }



        protected void gvCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            categoryManager = new CategoryManager(context);

        }

        //Evento generado al hacer click en el botón actualizar. Actualizar la categoria seleccionada
        protected void txtUpdate_Click(object sender, EventArgs e)
        {
            //Genero el contexto de datos
            ApplicationDbContext context = new ApplicationDbContext();
            categoryManager = new CategoryManager(context);
            //Cargo los valores existenten en el textbox y en el campo oculto en las 
            //propiedades de la entidad
            Category category = new Category
            {
                CategoryName = txtCategory.Text,
                id = Convert.ToInt32(txtId.Value)
            };
            categoryManager.Update(category);
            LoadCategories();

        }

        //Evento generado al hacer click en el botón eliminar. Eliminar la categoria seleccionada
        protected void txtDelete_Click(object sender, EventArgs e)
        {
            //Creo el contexto de datos
            ApplicationDbContext context = new ApplicationDbContext();
            categoryManager = new CategoryManager(context);

            //Cargo en un entero el valor del campo oculto txtId
            //que tiene el Id de la categoria seleccionada
            int categoryId = Convert.ToInt32(txtId.Value);

            //Busco dicho Id en la entidad Category y la borra
            Category category = context.Categories.Find(categoryId);
            categoryManager.Remove(category);
            categoryManager.Context.SaveChanges();

            //Actualizo el grid que muestra las categorias
            LoadCategories();

            //Pongo en blanco el campo Categorias
            txtCategory.Text = "";
        }
}

}

