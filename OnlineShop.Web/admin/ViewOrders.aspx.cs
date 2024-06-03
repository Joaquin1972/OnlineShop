using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using OnlineShop.Application;
using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.admin
{
    public partial class ViewOrders : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAllOrders();
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
        public void LoadAllOrders()
        {
            try
            {
                // Cargo el contexto de datos de Order
                ApplicationDbContext context = new ApplicationDbContext();
                OrderManager orderManager = new OrderManager(context);
                //Cargo TODAS las ordenes de la usuarios, ordenadas por fecha y luego por estado
                var orders = orderManager.GetAll().OrderByDescending(p => p.DateOrder).ThenBy(p => p.Status).ToList();

                //Compruebo si hay ordenes
                if (orders != null && orders.Count > 0)
                {
                    //Si hay ordenes, creo el GV
                    gvOrderByUser.DataSource = orders;
                    gvOrderByUser.DataBind();
                }
                else
                {
                    //Si no hay ordenes
                    Response.Write("No hay ordedes");
                }
            }

            catch (Exception ex)
            {
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al cargar las ordenes del cliente",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        //Comando de la fila
        public void gvOrderByUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Mostras detalles en el siguiente GV
            if (e.CommandName == "Details")
            {
                //Obtengo identificador del pedido y lo envío al método que construye el GV
                int orderId = Convert.ToInt32(e.CommandArgument);
                BindOrderDetails(orderId);
            }

            //Cambiar estado
            if (e.CommandName == "Change")
            {   //Obtengo el id del pedido
                int orderId = Convert.ToInt32(e.CommandArgument);
                ApplicationDbContext context = new ApplicationDbContext();
                OrderManager orderManager = new OrderManager(context);
                //Obtengo el pedido a cambiar con la Id obtenida
                var OrderToChange = orderManager.GetById(orderId);
                if (OrderToChange != null)
                {
                    //Obtengo de dicho pedido su estado actual
                    var CurrentStatus = OrderToChange.Status;

                    switch (CurrentStatus)
                    {
                        //Los pedido pasa por pendiente->en preparación->enviado->entregado
                        //Hay un 5º estado por si el admin quiere pasar algún pedido a cancelado
                        case OrderStatus.Pending:
                            OrderToChange.Status = OrderStatus.InPreparation;
                            break;
                        case OrderStatus.InPreparation:
                            OrderToChange.Status = OrderStatus.Shipping;
                            break;
                        case OrderStatus.Shipping:
                            OrderToChange.Status = OrderStatus.Delivered;
                            break;
                        case OrderStatus.Delivered:
                            OrderToChange.Status = OrderStatus.Cancelled;
                            break;
                        case OrderStatus.Cancelled:
                            OrderToChange.Status = OrderStatus.Pending;
                            break;
                    }

                    //Actualizo el pedido con el nuevo estado
                    orderManager.Update(OrderToChange);
                    LoadAllOrders();

                }
            }
        }

        //Metodo que construye el GV que muestra los detalles de la orden
        public void BindOrderDetails(int orderId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            OrderManager orderManager = new OrderManager(context);
            var orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
            gvOrderDetails.DataSource = orderDetails;
            gvOrderDetails.DataBind();
        }

        //Metodo para mostra el email del usuario y no el Id
        public string GetUserEmail(object userId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.Find(userId);
            return user.Email;
        }

        //Método para ejecutar acciones de cada línea de la orden de detalle
        public void gvOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Si pulsa Volver al producto
            if (e.CommandName == "ReturnProduct")
            {
                // Obtengo el nombre del producto desde el CommandArgument
                string productName = e.CommandArgument.ToString();


                // Crea el contexto de datos
                var contextP = new ApplicationDbContext();

                // Localiza el producto en el listado de productos
                var product = contextP.Products.FirstOrDefault(p => p.Name == productName);

                // Si el producto se encuentra, redirige a la página de edición del producto
                if (product != null)
                {
                    int id = product.Id;
                    Response.Redirect("~/admin/ProductEdit.aspx?id=" + id);
                }
                else
                {
                    Response.Write("Producto no encontrado.");
                }

            }
        }

        //Métod para cambiar de página el GV
        protected void gvOrderByUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex >= 0 && e.NewPageIndex < gvOrderByUser.PageCount)
            {
                gvOrderByUser.PageIndex = e.NewPageIndex;
                LoadAllOrders();
            }
        }


    }
}