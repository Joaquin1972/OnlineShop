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
                //Creo el contexto de datos de categoria
                ApplicationDbContext context = new ApplicationDbContext();
                categoryManager = new CategoryManager(context);
                var categories = categoryManager.GetAll().ToList();

                //Construyo el DDL desplegable de categorias, con las categorías existentes
                ddlCategory.DataSource = categories;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "id";
                ddlCategory.DataBind();
            }
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
                    // Si la fotos sube correctamente ...
                    UpLoadOK.Text = "Archivo subido correctamente!";
                }
                catch (Exception ex)
                {
                    // Si la foto ha dado algún error
                    UpLoadOK.Text = "Error al subir el archivo: " + ex.Message;
                }
            }
            else
            {
                // Mensaje de error si no se selecciona ningún archivo
                UpLoadOK.Text = "Por favor, seleccione un archivo.";
            }
        }

        public void BtnSubmit_Click(object sender, EventArgs e)
        {
            //Genero el contexto de datos
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);
            try
            {
                //Creo variable de sesión
                string uploadedFilePath = Session["UploadedFilePath"] as string;
                if (string.IsNullOrEmpty(uploadedFilePath))
                {
                    throw new Exception("No se ha subido ningún archivo o la sesión ha expirado.");
                }

                //Cargo valores actualizados
                Product Product = new Product
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Stock = Convert.ToInt32(txtStock.Text),
                    Category_Id = Convert.ToInt32(ddlCategory.SelectedValue),
                    ImagePath = uploadedFilePath,
                    //Genero lista de imágenes
                    Images = new List<Image>()
                    {
                        new Image
                        {
                           ImagePath = uploadedFilePath,
                        }
                    }
                };
                //Añado el producto
                productManager.Add(Product);
                productManager.Context.SaveChanges();
                //Limpio la variable de sesión después de usarla
                Session["UploadedFilePath"] = null;
                //Informo de producto correctamente creado
                LblCreateOK.Text = "Producto correctamente creado";
                LblCreateOK.CssClass = "alert alert-success";
                LblCreateOK.Visible = true;



            }
            catch (Exception ex)
            {
                
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al guardar" + ex.Message,
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
            finally
            {
                //Una vez creado el producto, limpio los TB
                txtName.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
                txtStock.Text = "";
                UpLoadOK.Text = "";
                
            }
        }

    }
}
