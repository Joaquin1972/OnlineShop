using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
                LoadPersonalData();
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

        public void LoadPersonalData()
        {
            // Recupero Id de usuario
            string userId = User.Identity.GetUserId();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            LblCity.Text = user.City;
            LblAdress.Text = user.Adress;
            LblName.Text = user.Name;
            LblCountry.Text = user.Country;
            LblCP.Text = user.PostalCode;
            
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

        protected void btnUpdatePersonalData_Click(object sender, EventArgs e)
        {
            // Recupero Id de usuario
            string userId = User.Identity.GetUserId();
            Response.Redirect($"personalData.aspx?id={userId}");
        }


    }


}
