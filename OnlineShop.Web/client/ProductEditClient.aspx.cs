using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using OnlineShop.Application;
using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.client
{
    public partial class ProductEditClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //COMPROBAR SI EL USUARIO ESTA IDENTIFICADO PARA HABILITAR O NO EL BOTON DE COMPRA
                bool UserOK = User.Identity.IsAuthenticated;
                if (UserOK) //Lo está, habilito botón de compra
                {
                    BtnSell.Enabled = true;
                                    }
                else //No lo está, lo deshabilito y mensaje de aviso
                {
                    BtnSell.Enabled = false;
                    lblAlert.Text = "Debes estar registrado para comprar";
                    lblAlert.CssClass = "alert alert-danger";
                }

                //----------------------------------//
                // Recuperar el ID de la consulta
                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    // Cargo los productos por la id

                    LoadProducto(id);


                }
                else
                {
                    // Caso de Id no localizado
                    lblAlert.Text = "ID no encontrado";
                    lblAlert.CssClass = "alert alert-danger";
                }
            }
        }

        private void LoadProducto(string id)
        {
            try
            {

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
                //lblId.Text = productId.ToString();
                LblName.Text = product.Name;
                LblDescription.Text = product.Description;
                LblPrice.Text = product.Price.ToString() + "€";
                int maxStock = product.Stock;
                if (maxStock>5)
                {
                    maxStock = 5;
                }
                ConfigureDropDownList(DdlStock, 1, maxStock);

                //Cargo la primera imagen si hubiera más de 1
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

        //Método para configura el Drop Down List que indica el stock
        private void ConfigureDropDownList(DropDownList DdlStock, int v, int maxStock)
        {
            if (maxStock > 0)
            {
                //Si es mayor que cero, primero lo reinicio y luego lo relleno de 1 al máximo
                DdlStock.Items.Clear();
                for (int i = 1; i <= maxStock; i++)
                {
                    DdlStock.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }
            else
            {
                //Si es 0, pongo Sin stock
                DdlStock.Items.Add(new ListItem("Sin stock", "0"));
                BtnSell.Enabled = false;
                lblAlert.Text += " Pronto disponible. ";
                lblAlert.CssClass = "alert alert-danger";
            }
        }

        //Método para volver a la tienda
        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("tienda.aspx");
        }


        //Método para ir a la venta
        protected void BtnSell_Click(object sender, EventArgs e)
        {
            try
            {
                //Si usurio esta autenticado
                if (User.Identity.IsAuthenticated)
                {
                    // Obtener el contexto de la base de datos
                    ApplicationDbContext context = new ApplicationDbContext();
                    ShoppingCartManager shoppingCartManager = new ShoppingCartManager(context);

                    // Obtener el ID del producto desde la consulta (Query String)
                    string id = Request.QueryString["id"];
                    if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int productId))
                    {
                        throw new Exception("ID de producto inválido.");
                    }

                    // Obtener el producto por ID
                    ProductManager productManager = new ProductManager(context);
                    var product = productManager.GetById(productId);
                    if (product == null)
                    {
                        throw new Exception("Producto no encontrado.");
                    }

                    // Obtener la cantidad seleccionada desde el DropDownList
                    int quantity = Convert.ToInt32(DdlStock.SelectedValue);

                    // Obtener el usuario autenticado
                    string userId = User.Identity.GetUserId();

                    // Crear una nueva instancia de en el carro de compra
                    ShoppingCart shoppingCart = new ShoppingCart
                    {
                        User_Id = userId,
                        Product_Id = product.Id,
                        Quantity = quantity,
                        Price = product.Price // Guardar el precio actual del producto
                    };

                    // Añado el producto a la cesta de la compra.
                    shoppingCartManager.Add(shoppingCart);
                    context.SaveChanges();

                    //Añado el producto de la cesta al Pedido, le envio el usuario que ha comprado, el producto comprado por la Id y la cantidad
                    AddProductToOrder(userId, product.Id, quantity);
                    ChangeStock(product.Id, quantity);


                    // Mostrar un mensaje de confirmación al usuario
                    lblAlert.Text = "Producto añadido al carrito exitosamente.";
                    lblAlert.CssClass = "alert alert-success";

                    // Borro el producto añadido a la cesta una vez enviado a la orden de pedido y a detalles de pedio
                    shoppingCartManager.Remove(shoppingCart);
                    context.SaveChanges();

                }
                else
                {
                    // Caso que el usuario no esté registrado
                    lblAlert.Text = "Debes estar registrado para comprar.";
                    lblAlert.CssClass = "alert alert-danger";
                   

                }
            }
            catch (Exception ex)
            {
                // Info que aparece en caso de error
                lblAlert.Text = $"Error al añadir el producto al carrito: {ex.Message}";
                lblAlert.CssClass = "alert alert-danger";
            }
        }

        public void ChangeStock(int id, int quantity)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            ProductManager productManager = new ProductManager(context);
            var product = productManager.GetById(id);
            product.Stock -= quantity;
            productManager.Update(product);
        }

        //Método para añdir el producto comprado al pedido
        private void AddProductToOrder(string userId, int productId, int quantity)
        {
            try
            {
                // Obtengo el contexto de la base de datos
                ApplicationDbContext context = new ApplicationDbContext();

                // Selecciono el pedido pendiente para el usuario actual (userId), creo uno nuevo si no existe
                OrderManager orderManager = new OrderManager(context);
                Order order = orderManager.GetPendingOrderByUserId(userId);
                if (order == null)
                {
                    //Si no tengo pedido para el usuario, lo creo, si esta creado, esta parte se salta
                    order = new Order
                    {
                        User_Id = userId,
                        DateOrder = DateTime.Now,
                        Status = OrderStatus.Pending,
                        OrderDetails = new List<OrderDetail>()
                    };
                    context.Orders.Add(order);
                }

                // Obtener el nombre del producto por ID
                ProductManager productManager = new ProductManager(context);
                Product product = productManager.GetById(productId);
                if (product == null)
                {
                    throw new Exception("Producto no encontrado.");
                }

                // Verificar si ya hay un producto similar en esta orden de pedido
                OrderDetail existingOrderDetail = order.OrderDetails.FirstOrDefault(od => od.ProductName == product.Name);
                if (existingOrderDetail != null)
                {
                    // Si el producto ya existe en el pedido, actualizamos la cantidad
                    existingOrderDetail.Quantity = quantity;
                }
                else
                {
                    // Si el producto no existe en el pedido, creamos nuevo producto en la orden de detallas
                    OrderDetail orderDetail = new OrderDetail
                    {
                        ProductName = product.Name,
                        UnitPrice = product.Price,
                        Quantity = quantity
                    };
                    order.OrderDetails.Add(orderDetail);
                }

                // Guardar los cambios en el contexto de la base de datos
                context.SaveChanges();
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
        }


    }
}
