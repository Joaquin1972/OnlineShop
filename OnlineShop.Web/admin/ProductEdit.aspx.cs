﻿using OnlineShop.Application;
using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = OnlineShop.Core.Image;

namespace OnlineShop.Web.admin
{
    public partial class ProductEdit : System.Web.UI.Page
    {
        CategoryManager categoryManager = null;
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recupero el ID de la consulta
                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    //Cargo el producto seleccionado, mandandole el id enviado desde página anterior
                    LoadProduct(id);
                }
                else
                {
                    //Caso de id no válido
                    Response.Write("ID no válido.");
                }


                //Genero el contexto de datos de categorias
                ApplicationDbContext context = new ApplicationDbContext();
                categoryManager = new CategoryManager(context);
                var categories = categoryManager.GetAll().ToList();
                //Construyo el dropdownList
                ddlCategory.DataSource = categories;
                ddlCategory.DataTextField = "CategoryName"; // Propiedad que se mostrará en el DropDownList
                ddlCategory.DataValueField = "id";  // Propiedad que se usará como valor 
                ddlCategory.DataBind();

            }
        }

        //Función para cargar el producto, recibe id como argunmento
        public void LoadProduct(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentException("El ID del producto no puede ser nulo o vacío.");
                }

                //Creo el contexto de datos del producto
                ApplicationDbContext context = new ApplicationDbContext();
                ProductManager productManager = new ProductManager(context);

                int productId;
                if (!int.TryParse(id, out productId))
                {
                    throw new FormatException("El ID del producto no tiene un formato válido.");
                }

                //Cargo el producto seleccionado con la Id
                var product = productManager.GetById(productId);
                if (product == null)
                {
                    throw new Exception("Producto no encontrado.");
                }

                //Cargo en los textbox los datos del producto
                ID.Text = productId.ToString();
                txtProduct.Text = product.Name;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
                txtStock.Text = product.Stock.ToString();
                ddlCategory.SelectedValue = product.Category_Id.ToString();

                //Cargo la primera imagen
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
                // Manejo de errores
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al cargar" + ex.Message,
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        //Método para cargar la foto
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

        //Metodo para la actualización del producto
        public void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Creo variable de sesión
                string uploadedFilePath = Session["UploadedFilePath"] as string;
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
                    Category_Id = Convert.ToInt32(ddlCategory.SelectedValue),
                    Images = new List<Image>()
                    {
                        new Image
                        {
                           ImagePath = uploadedFilePath,
                        }
                    }

                };
                productManager.Update(product);
                lblUpdateOk.Text = "Actualización correcta";
                lblUpdateOk.CssClass = "alert alert-success";
            }
            catch
            {
                // Manejo de errores
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al actualizar el producto ",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        //Método para el borrado del producto
        public void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                //Creo el contexto de datos
                ApplicationDbContext context = new ApplicationDbContext();
                ProductManager productManager = new ProductManager(context);
                int productId = Convert.ToInt32(ID.Text);

                //Borro el producto seleccionado por la id
                Product product = context.Products.Find(productId);
                productManager.Remove(product);
                productManager.Context.SaveChanges();
                ID.Text = "Borrado";
                txtProduct.Text = "Borrado";
                txtDescription.Text = "Borrado";
                txtPrice.Text = "Borrado";
                txtStock.Text = "Borrado";
                lblUpdateOk.Text = "Borrado correcto";
                lblUpdateOk.CssClass = "alert alert-success";
            }
            catch
            {
                // Manejo de errores
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al borrar el producto ",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }
    }
}
