using Microsoft.AspNet.Identity;
using OnlineShop.Application;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.client
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

                if (User.Identity.IsAuthenticated)
                {
                    // Recupero Id de usuario
                    string userId = User.Identity.GetUserId();
                    // Cargo el contexto de datos de Order
                    ApplicationDbContext context = new ApplicationDbContext();
                    OrderManager orderManager = new OrderManager(context);
                    //Cargo solo las ordenes del usuario (tanto en preparacion, como enviadas, como pendientes)
                    var orders = orderManager.GetAll().Where(o => o.User_Id == userId).ToList();
                    
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

        protected void gvOrderByUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int orderId = Convert.ToInt32(e.CommandArgument);
                BindOrderDetails(orderId);
            }
        }

        private void BindOrderDetails(int orderId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            OrderManager orderManager = new OrderManager(context);
            var orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
            gvOrderDetails.DataSource = orderDetails;
            gvOrderDetails.DataBind();
        }
    }


}
