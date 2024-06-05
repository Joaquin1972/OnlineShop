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
        // Creo el contexto de datos
        ApplicationDbContext context = new ApplicationDbContext();
        CategoryManager categoryManager;

        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoryManager = new CategoryManager(context);
                LoadCategories();
            }
        }

        // Cargo todas las categorías y construyo el GV
        public void LoadCategories()
        {
            try
            {
                var categories = categoryManager.GetAll().ToList();
                gvCategories.DataSource = categories;
                gvCategories.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                // Manejo de errores
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al cargar categorias" + ex.Message,
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        public void gvCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
         
                int selectedRowIndex = gvCategories.SelectedIndex;
                string selectedCategory = gvCategories.SelectedRow.Cells[1].Text;
                txtCategory.Text = selectedCategory;
                string selectedId = gvCategories.SelectedRow.Cells[0].Text;
                txtId.Value = selectedId;
       

            
        }

        // Evento generado al hacer click en el botón actualizar. Actualiza la categoría seleccionada.
        public void txtUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Genero el contexto de datos
                ApplicationDbContext context = new ApplicationDbContext();
                categoryManager = new CategoryManager(context);

                // Cargo los valores existentes en el textbox y en el campo oculto en las 
                // propiedades de la entidad
                Category category = new Category
                {
                    CategoryName = txtCategory.Text,
                    id = Convert.ToInt32(txtId.Value)
                };
                categoryManager.Update(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                
                // Manejo de errores
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al actualizar datos" + ex.Message,
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        // Evento generado al hacer click en el botón eliminar. Eliminar la categoría seleccionada
        public void txtDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Creo el contexto de datos
                ApplicationDbContext context = new ApplicationDbContext();
                categoryManager = new CategoryManager(context);

                // Cargo en un entero el valor del campo oculto txtId
                // que tiene el Id de la categoría seleccionada
                int categoryId = Convert.ToInt32(txtId.Value);

                // Busco dicho Id en la entidad Category y la borra
                Category category = context.Categories.Find(categoryId);
                categoryManager.Remove(category);
                categoryManager.Context.SaveChanges();

                // Actualizo el grid que muestra las categorías
                LoadCategories();

                // Pongo en blanco el campo Categorías
                txtCategory.Text = "";
            }
            catch (Exception ex)
            {
                // Manejo de errores
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al borrar categorias" + ex.Message,
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }
    }
}

