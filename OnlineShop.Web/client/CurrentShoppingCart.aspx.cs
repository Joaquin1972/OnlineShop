using Microsoft.AspNet.Identity;
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
            CurrentOrderPendingbyUser();
        }

        public void CurrentOrderPendingbyUser()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    //Recupero Id de usuario
                    string userId = User.Identity.GetUserId();

                    //Cargo el contexto de datos de Order
                    ApplicationDbContext context = new ApplicationDbContext();
                    OrderManager orderManager = new OrderManager(context);
                    //Cargo de Order solo los pedidos pendiente (Status = 0)
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

                };

            }
            catch
            {

            }
        }
    }
}