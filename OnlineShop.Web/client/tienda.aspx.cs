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
        //Establezco los productos por página
        public int PageSize = 6;
        public int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    ViewState["CurrentPage"] = 0;
                }
                return (int)ViewState["CurrentPage"];
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }

        //Cargo categorias y construyo DL
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                BindDataList();
            }
        }

        //Contruyl el desplegable de categorias
        public void LoadCategories()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var categories = context.Categories.ToList();
                ddlCategories.DataSource = categories;
                ddlCategories.DataTextField = "CategoryName";
                ddlCategories.DataValueField = "Id";
                ddlCategories.DataBind();
                ddlCategories.Items.Insert(0, new ListItem("Todas las categorías", "0"));
            }
        }

        //Contruyo el data list que muestra los productos
        public void BindDataList(int categoryId = 0)
        {
            try
            {
                ApplicationDbContext context = new ApplicationDbContext();

                    //Selecciono los productos
                    var products = context.Products.Include(p => p.Category).Include(p => p.Images).OrderByDescending(p => p.Id).ToList();

                //Los filtro por categorías
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


                PagedDataSource pagedDataSource = new PagedDataSource(); //Instancio a una clase que permite paginar listas de datos
                pagedDataSource.DataSource = productList; // Le asigno la fuente de datos
                pagedDataSource.AllowPaging = true; // Permito paginación
                pagedDataSource.PageSize = PageSize; // Indico tamaño de la página
                pagedDataSource.CurrentPageIndex = CurrentPage; //Establezco página actual

                //Habilito los botones anterior o posterior en función si hay más paginas
                btnPrev.Enabled = !pagedDataSource.IsFirstPage;
                btnPrevBottom.Enabled = !pagedDataSource.IsFirstPage;
                btnNext.Enabled = !pagedDataSource.IsLastPage;
                btnNextBottom.Enabled = !pagedDataSource.IsLastPage;

                //Construyo el datalist
                dlProducts.DataSource = pagedDataSource;
                dlProducts.DataBind();

                int totalPages = pagedDataSource.PageCount;
                int currentPage = pagedDataSource.CurrentPageIndex + 1;

                lblPageInfo.Text = $"Página {currentPage} de {totalPages}";
                lblPageInfoBottom.Text = $"Página {currentPage} de {totalPages}";

            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al cargar los productos. Por favor, inténtelo de nuevo más tarde.";
                lblError.Visible = true;
            }
        }

        public void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = 0; // Reiniciar a la primera página
            int selectedCategoryId = int.Parse(ddlCategories.SelectedValue);
            BindDataList(selectedCategoryId);
        }

        //Metodo para ir a página anterior
        public void btnPrev_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;
                BindDataList(int.Parse(ddlCategories.SelectedValue));
            }
        }

        //Metodo para ir a página posterior
        public void btnNext_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            BindDataList(int.Parse(ddlCategories.SelectedValue));
        }

        //Redirecciono a la página del producto seleccionado
        public void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "SelectProduct")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("ProductEditClient.aspx?id=" + id);
            }
        }

        //Muestra disponibe o sin stock en el data list del producto
        public string GetStockText(int stock)
        {
            return stock > 0 ? "Disponible" : "Sin stock";
        }
    }
}
