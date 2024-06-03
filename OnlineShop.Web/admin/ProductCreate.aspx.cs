using OnlineShop.Application;
using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Image = OnlineShop.Core.Image;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace OnlineShop.Web.admin
{
    public partial class ProductCreate : System.Web.UI.Page
    {
        CategoryManager categoryManager = null;
        ProductManager productManager = null;

        public void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                categoryManager = new CategoryManager(context);
                var categories = categoryManager.GetAll().ToList();

                ddlCategory.DataSource = categories;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "id";
                ddlCategory.DataBind();
            }


            //gvProducts.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            //LoadProduts();
        }



        public void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                // Guardar el archivo en el servidor
                string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string savePath = Server.MapPath("~/img/") + fileName;
                Session["UploadedFilePath"] = "~/img/" + fileName;

                try
                {
                    FileUpload1.SaveAs(savePath);
                    Session["UploadedFilePath"] = "~/img/" + fileName;
                    // Mensaje de éxito
                    UpLoadOK.Text = "Archivo subido correctamente!";
                }
                catch (Exception ex)
                {
                    // Manejar error
                    Response.Write("Error al subir el archivo: " + ex.Message);
                }
            }
            else
            {
                // Mensaje de error si no se selecciona ningún archivo
                Response.Write("Por favor, seleccione un archivo.");
            }
        }

        public void BtnSubmit_Click(object sender, EventArgs e)
        {
            //Genero el contexto de datos
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);
            try
            {
                string uploadedFilePath = Session["UploadedFilePath"] as string;
                if (string.IsNullOrEmpty(uploadedFilePath))
                {
                    throw new Exception("No se ha subido ningún archivo o la sesión ha expirado.");
                }

                //Cargo valores actualizados
                Product Product = new Product
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Stock = Convert.ToInt32(txtStock.Text),
                    Category_Id = Convert.ToInt32(ddlCategory.SelectedValue),
                    ImagePath = uploadedFilePath,
                    Images = new List<Image>()
                    {
                        new Image
                        {
                           ImagePath = uploadedFilePath,
                        }
                    }
                };
                productManager.Add(Product);
                productManager.Context.SaveChanges();
                //Limpiar la variable de sesión después de usarla
                Session["UploadedFilePath"] = null;
                LblCreateOK.Text = "Producto correctamente creado";
                LblCreateOK.CssClass = "alert alert-success";
                LblCreateOK.Visible = true;



            }
            catch (Exception ex)
            {
                //
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al guardar" + ex.Message,
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
            finally
            {
                txtName.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
                txtStock.Text = "";
                UpLoadOK.Text = "";
                //LoadProduts();
            }
        }

        //public void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    gvProducts.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        //    LoadProduts(); // Vuelve a cargar los productos con el nuevo tamaño de página
        //}

        //public void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvProducts.PageIndex = e.NewPageIndex;
        //    LoadProduts(); // Carga los datos de la página seleccionada
        //}

        //public void LoadProduts()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    productManager = new ProductManager(context);
        //    var products = productManager.GetAll().
        //        Include(i => i.Category).
        //        Include(p => p.Images).
        //        OrderByDescending
        //        (p => p.Id).ToList();
        //    //gvProducts.DataSource = products;
        //    //gvProducts.DataBind();
        //    // Proyectar los productos con FirstImagePath
        //    var productList = products.Select(p => new
        //    {
        //        p.Id,
        //        p.Name,
        //        p.Description,
        //        p.Price,
        //        p.Stock,
        //        CategoryName = p.Category.CategoryName,
        //        FirstImagePath = p.Images != null && p.Images.Count > 0 ? p.Images.First().ImagePath : Session["UploadedFilePath"]
        //    }).ToList();

        //    gvProducts.DataSource = productList;
        //    gvProducts.DataBind();
        //}




    }
}
