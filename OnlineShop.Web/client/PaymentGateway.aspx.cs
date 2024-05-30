using Microsoft.AspNet.Identity;
using OnlineShop.Application;
using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Página de destino (por ejemplo, PaymentGateway.aspx.cs)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar el valor de la variable de sesión
                if (Session["PaymentAmount"] != null)
                {
                    decimal paymentAmount = (decimal)Session["PaymentAmount"];
                    // Utiliza el valor según sea necesario
                    lblPaymentAmount.Text = paymentAmount + "€";
                }
                else
                {
                    lblPaymentAmount.Text = "No se ha especificado un monto de pago.";
                }
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            //Convierto la numeracion de la tarjeta a texto. Limpio en blanco
            string CardNumber = TBCardNumber.Text.Trim();
            if (!string.IsNullOrEmpty(CardNumber))
            {
                //Obtengo 4 ultimos digitos de la tarjeta bancaria y comparo con 4321
                string LastFourNumber = CardNumber.Substring(CardNumber.Length - 4);
                if (LastFourNumber == "4321")
                { //Si es correcto, asumo pago correcto e informo de ello
                    lblMessage.Text = "Pago correctamente realizado. Comenzamos a preparar su pedido";
                    lblMessage.CssClass = "text-success";
                    lblMessage.Visible = true;
                    TBCardNumber.Text = "";
                    TBDate.Text = "";
                    TBCCV.Text = "";
                    //Procedo a cambiar el estado del pedido a "1" que sería "en preparacion"
                    ChangeStatusOrder();

                }
                else
                {// Si no es correcto, informo de pago incorrecto
                    lblMessage.Text = "Ha habido un error en el pago.";
                    lblMessage.CssClass = "text-danger";
                    TBCardNumber.Text = "";
                    TBDate.Text = "";
                    TBCCV.Text = "";
                }
            }
        }

        public void ChangeStatusOrder()
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
                    

                }


            }
            catch
            {
            }
            finally
            {

            }
        }
    }
}