using Microsoft.AspNet.Identity;
using Microsoft.SqlServer.Server;
using OnlineShop.Application;
using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.client
{
    public partial class CurrentShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargo ordenes pendientes del usuario autenticado
            try
            {
                CurrentOrderPendingbyUser();
            }
            catch (Exception ex)
            {
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        public void CurrentOrderPendingbyUser()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    // Recupero Id de usuario
                    string userId = User.Identity.GetUserId();

                    // Cargo el contexto de datos de Order
                    ApplicationDbContext context = new ApplicationDbContext();
                    OrderManager orderManager = new OrderManager(context);
                    // Cargo de Order solo los pedidos pendiente (Status = 0)
                    var userOrders = orderManager.GetPendingOrderByUserId(userId);

                    if (userOrders != null && userOrders.OrderDetails.Any())
                    {
                        // Envío a las labels el identificador de pedido, que actuará como nº de pedido y la fecha de pedido
                        LblOrderUserIdPending.Text = userOrders.Id.ToString();
                        LblDateOrderUserIdPending.Text = userOrders.DateOrder.ToString("dd/MM/yyyy");

                        // Enlazo los detalles del pedido al GridView
                        gvUserOrders.DataSource = userOrders.OrderDetails;
                        gvUserOrders.DataBind();

                        // Calculo el total de todos los detalles del pedido
                        decimal totalOrderPrice = userOrders.OrderDetails.Sum(od => od.TotalPrice);

                        // Envío el total a un label en la interfaz de usuario
                        LblTotalOrderPrice.Text = totalOrderPrice.ToString();
                        // Asignar un valor a la variable de sesión
                        Session["PaymentAmount"] = totalOrderPrice;
                    }
                    else
                    {
                        // Si no hay órdenes pendientes, puedes mostrar un mensaje o realizar alguna otra acción.
                        // Por ejemplo:
                        LblOrderUserIdPending.Text = "No hay órdenes pendientes.";
                        LblDateOrderUserIdPending.Text = "";
                        gvUserOrders.DataSource = null;
                        gvUserOrders.DataBind();
                        LblTotalOrderPrice.Text = "";
                    }

                }
            }
            catch (Exception ex)
            {
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al cargar las ordenes pendientes",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        public void gvUserOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //Si el usuario ha pulsado Volver al producto
                if (e.CommandName == "ReturnProduct")
                {
                    string Name = e.CommandArgument.ToString();
                    // Creo el contexto de datos
                    ApplicationDbContext contextP = new ApplicationDbContext();
                    ProductManager productManager = new ProductManager(contextP);
                    // A traves del nombre del producto recibido, localizo el producto en el listado de productos
                    var product = contextP.Products.FirstOrDefault(p => p.Name == Name);
                    int ProductId = product.Id;
                    Session["ProductIdS"] = ProductId;

                    //redirecciono al usuario al producto, por si quiere verlo o cambiar la cantidad comprada
                    Response.Redirect("ProductEditClient.aspx?id=" + ProductId);
                }

                //Si el usuario ha pulsado borrar
                else if (e.CommandName == "DeleteItem")
                {

                    // Creo el contexto de datos
                    ApplicationDbContext context = new ApplicationDbContext();
                    OrderDetailManager orderDetailManager = new OrderDetailManager(context);

                    // Obtengo el identificador del Detalle de la Orden a borrar
                    int orderDetailId = Convert.ToInt32(e.CommandArgument);
                              
                    // Obtengo el detalle de pedido a borrar          
                    OrderDetail orderDetail = context.OrderDetails.Find(orderDetailId);
                    int Quantity = orderDetail.Quantity;
                    string Name = orderDetail.ProductName;
                    ApplicationDbContext contextP = new ApplicationDbContext();
                    ProductManager productManager = new ProductManager(contextP);
                    var product = contextP.Products.FirstOrDefault(p => p.Name == Name);
                    int ProductId = product.Id;
                    ChangeStock(ProductId, Quantity);

                    // Si fue encontrado, actualizo stock y elimino el detalle
                    if (orderDetail != null)
                    {
                        //Añado al stock la cantidad que se borra del producto

                        orderDetailManager.Remove(orderDetail);
                    }

                    context.SaveChanges();

                    // Calculo la cantidad de elementos que aun tengo en Detalle de la orden
                    var totalQuantity = context.OrderDetails
                      .Where(od => od.OrderId == orderDetail.OrderId)
                      .DefaultIfEmpty()
                      .Sum(od => od == null ? 0 : od.Quantity);

                    // Si el numero de elementos en el detalle de la orden es 0, entonces elimino el pedido
                    if (totalQuantity == 0)
                    {
                        OrderManager orderManager = new OrderManager(context);
                        Order orderToDelete = context.Orders.Find(orderDetail.OrderId);
                        if (orderToDelete != null)
                        {
                            orderManager.Remove(orderToDelete);
                        }
                    }

                    context.SaveChanges();
                    // Vuelvo a cargar el detalle de pedido
                    CurrentOrderPendingbyUser();

                }
            }
            catch (Exception ex)
            {
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al borrar",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        //Añado al stock el producto borrado
        public void ChangeStock(int id, int quantity)
        {
            try { 
            ApplicationDbContext context = new ApplicationDbContext();
            ProductManager productManager = new ProductManager(context);
            var product = productManager.GetById(id);
            product.Stock += quantity;
            productManager.Update(product);
            } catch
            {
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al actualizar el stock",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        public void BtnMakePayment_Click(object sender, EventArgs e)
        {

            // Redirigir a la página de destino
            Response.Redirect("PaymentGateway.aspx");
        }

        public void BtnReturn_Click(object sender, EventArgs e)
        {

            // Redirigir a la página de destino
            Response.Redirect("tienda.aspx");
        }

    }
}
