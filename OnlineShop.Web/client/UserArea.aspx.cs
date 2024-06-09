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
        //Cargo pedidos y datos del usuario seleccionado
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadOrdersByUser();
                LoadPersonalData();
            }
            catch 
            {
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        //Cargo datos personales
        public void LoadPersonalData()
        {
            try {
            // Recupero Id de usuario
            string userId = User.Identity.GetUserId();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            //Relleno los label de los datos personales
            LblCity.Text = user.City;
            LblAdress.Text = user.Adress;
            LblName.Text = user.Name;
            LblCountry.Text = user.Country;
            LblCP.Text = user.PostalCode;
             } catch
            {
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al actualizar los datos del cliente",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        //Cargo pedidos
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

        //Metodo que se ejecuta si de pulsa detalles en el GV. Se construyo el GV de detalles con el Id
        public void gvOrderByUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int orderId = Convert.ToInt32(e.CommandArgument);
                BindOrderDetails(orderId);
            }
        }

        //Construyo el GV con el Id enviado desde la fila del anterior GV
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
