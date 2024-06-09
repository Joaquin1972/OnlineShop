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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recupero el valor de la variable de sesión y lo aplico a la label
                if (Session["PaymentAmount"] != null)
                {
                    decimal paymentAmount = (decimal)Session["PaymentAmount"];
                    // 
                    lblPaymentAmount.Text = paymentAmount + "€";
                }
                else
                {
                    lblPaymentAmount.Text = "No se ha especificado una cantidad de pago.";
                }
            }
        }

        public void btnPay_Click(object sender, EventArgs e)
        {
            // Convierto la numeración de la tarjeta a texto y limpio blancos
            string CardNumber = TBCardNumber.Text.Trim();
            string CardDate = TBDate.Text.Trim();
            string CCV = TBCCV.Text.Trim();

            // Inicializo variables
            bool CCVOK = false;
            bool CardNumberOK = false;
            bool DateOK = false;

            //VERIFICO CCV
            if (!string.IsNullOrEmpty(CCV))
            {
                //Verifico si es 600 (me lo invento)
                if (CCV == "600")
                {
                    CCVOK = true;
                }
                else
                {
                    CCVOK = false;
                }
            }

            // VERIFICO NUMERO DE TARJERA
            if (!string.IsNullOrEmpty(CardNumber))
            {
                // Obtengo los 4 últimos dígitos de la tarjeta bancaria y comparo con 4321
                string LastFourNumber = CardNumber.Substring(CardNumber.Length - 4);
                if (LastFourNumber == "4321")
                {
                    CardNumberOK = true;
                }
                else
                {
                    CardNumberOK = false;
                }
            }

            // VERIFICO FECHA DE CADUCIDAD
            if (!string.IsNullOrEmpty(CardDate) && CardDate.Length == 5 && CardDate.Contains("/"))
            {
                // Obtengo mes y año de la fecha de la tarjeta
                string[] dateParts = CardDate.Split('/');
                int month = int.Parse(dateParts[0]);
                int year = int.Parse("20" + dateParts[1]);

                // Verifico si la fecha de la tarjeta es mayor que la fecha actual
                // Para mes=12 y año = 2024 toma fecha 31-12-2024 (2024,12,31)
                DateTime cardExpiryDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                if (cardExpiryDate > DateTime.Now)
                {
                    DateOK = true;
                }
                else
                {
                    DateOK = false;
                }

                //SI TODO ES CORRECTO

                if (CCVOK && CardNumberOK && DateOK)
                {
                    // Si es correcto, asumo pago correcto e informo de ello
                    lblMessage.Text = "Pago correctamente realizado. Comenzamos a preparar su pedido";
                    lblMessage.CssClass = "alert alert-success";
                    lblMessage.Visible = true;
                    TBCardNumber.Text = "";
                    TBDate.Text = "";
                    TBCCV.Text = "";
                    //SendMailUser();
                    //SendMailAdmin();

                    // Procedo a cambiar el estado del pedido a "1" que sería "en preparación"
                    ChangeStatusOrder();
                }
                else
                {
                    // Si no es correcto, informo de pago incorrecto
                    lblMessage.Text = "Error en el pago. Compruebe datos de la tarjeta";
                    lblMessage.CssClass = "alert alert-danger";
                    lblMessage.Visible = true;
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
                    var userOrders = orderManager.GetPendingOrderByUserId(userId);
                    int Pedido = userOrders.Id;

                    // Obtén la orden existente
                    var OrderToChange = orderManager.GetById(Pedido);

                    // Actualiza el estado de la orden
                    OrderToChange.Status = OrderStatus.InPreparation;
                    OrderToChange.OrderTotalPrice = (decimal)Session["PaymentAmount"];

                    // Guarda los cambios
                    orderManager.Update(OrderToChange);

                    // Opcional: recarga la orden actualizada para verificar los cambios
                    var updatedOrder = orderManager.GetById(Pedido);
                    Response.Write(updatedOrder.Id);
                    Response.Write(updatedOrder.Status);
                }
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