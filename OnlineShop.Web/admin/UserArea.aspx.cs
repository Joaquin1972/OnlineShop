using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Application;
using OnlineShop.DAL;
using OnlineShop.Web.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.Admin
{
    public partial class UserArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadOrdersByUser();
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

        public void LoadOrdersByUser()
        {
            try
            {


                // Recupero Id de enviado desde la pagina de usuarios
                string id = Request.QueryString["id"];
                // Cargo el contexto de datos de Order
                ApplicationDbContext context = new ApplicationDbContext();
                OrderManager orderManager = new OrderManager(context);
                //Cargo todas las ordenes del usuario (tanto en preparacion, como enviadas, como pendientes)
                var orders = orderManager.GetAll().Where(o => o.User_Id == id).ToList();

                ApplicationDbContext contextU = new ApplicationDbContext();
                var user = contextU.Users.Find(id);
                var userName = user.UserName;

                if (orders != null)
                {
                    //Si hay ordenes, creo el GV
                    gvOrderByUser.DataSource = orders;
                    gvOrderByUser.DataBind();
                    OrdersUser.Text = "Listado de pedidos de: " + userName;
                }
                else
                {
                    //Si no hay ordenes
                    OrdersUser.Text = "No hay pedidos de: " + userName;

                }

                // Obtengo el userName del cliente

                //var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext()));

                //var user = userManager.FindById(id);
                //if (user != null)
                //{
                //    var userName = user.UserName;
                //    OrdersUser.Text = "Listado de pedidos de: " + userName;

                //}
                //else
                //{
                //    // Manejar el caso donde el usuario no se encuentra
                //    OrdersUser.Text = "Usuario no localizado";
                //}




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
        }

        public void BindOrderDetails(int orderId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            OrderManager orderManager = new OrderManager(context);
            var orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
            gvOrderDetails.DataSource = orderDetails;
            gvOrderDetails.DataBind();
        }

    }


}
