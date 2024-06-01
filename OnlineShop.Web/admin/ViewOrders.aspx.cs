using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using OnlineShop.Application;
using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
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

                if (User.Identity.IsAuthenticated)
                {
                    // Recupero Id de usuario
                    string userId = User.Identity.GetUserId();
                    // Cargo el contexto de datos de Order
                    ApplicationDbContext context = new ApplicationDbContext();
                    OrderManager orderManager = new OrderManager(context);
                    //Cargo solo las ordenes del usuario (tanto en preparacion, como enviadas, como pendientes)
                    var orders = orderManager.GetAll().OrderByDescending(p => p.DateOrder).ThenBy(p => p.Status).ToList();


                    if (orders != null)
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

        public void gvOrderByUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int orderId = Convert.ToInt32(e.CommandArgument);
                BindOrderDetails(orderId);
            }

            if (e.CommandName == "Change")
            {
                int orderId = Convert.ToInt32(e.CommandArgument);

                ApplicationDbContext context = new ApplicationDbContext();
                OrderManager orderManager = new OrderManager(context);
                // Obtén la orden existente
                var OrderToChange = orderManager.GetById(orderId);
                if (OrderToChange != null)
                {
                    var CurrentStatus = OrderToChange.Status;
                    //if (CurrentStatus == OrderStatus.InPreparation)
                    //{
                    //    OrderToChange.Status = OrderStatus.Shipping;
                    //    // Guarda los cambios
                    //    orderManager.Update(OrderToChange);
                    //    LoadAllOrders();
                    //}
                    switch (CurrentStatus)
                    {
                        case OrderStatus.InPreparation:
                            OrderToChange.Status = OrderStatus.Shipping;
                            break;
                        case OrderStatus.Shipping:
                            OrderToChange.Status = OrderStatus.Pending;
                            break;
                        case OrderStatus.Pending:
                            OrderToChange.Status = OrderStatus.InPreparation;
                            break;
                    }
                    orderManager.Update(OrderToChange);
                    LoadAllOrders();

                }
            }
        }

        public void BindOrderDetails(int orderId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            OrderManager orderManager = new OrderManager(context);
            var orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
            gvOrderDetails.DataSource = orderDetails;
            gvOrderDetails.DataBind();
        }

        public string GetUserEmail(object userId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.Find(userId);
            return user.Email;
        }

        protected void gvOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Asegúrate de que el CommandName es "ReturnProduct"
            if (e.CommandName == "ReturnProduct")
            {
                // Obtén el nombre del producto desde el CommandArgument
                string productName = e.CommandArgument.ToString();
                Response.Write("Producto a devolver: " + productName);

                // Crea el contexto de datos
                using (var contextP = new ApplicationDbContext())
                {
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
        }

    }
}