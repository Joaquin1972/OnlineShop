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

        //public void btnPay_Click(object sender, EventArgs e)
        //{
        //    //Convierto la numeracion de la tarjeta a texto. Limpio en blanco
        //    string CardNumber = TBCardNumber.Text.Trim();
        //    string CardDate = TBDate.Text.Trim();
        //    if (!string.IsNullOrEmpty(CardNumber))
        //    {
        //        //Obtengo 4 ultimos digitos de la tarjeta bancaria y comparo con 4321
        //        string LastFourNumber = CardNumber.Substring(CardNumber.Length - 4);
        //        if (LastFourNumber == "4321")
        //        { //Si es correcto, asumo pago correcto e informo de ello
        //            lblMessage.Text = "Pago correctamente realizado. Comenzamos a preparar su pedido";
        //            lblMessage.CssClass = "text-success";
        //            lblMessage.Visible = true;
        //            TBCardNumber.Text = "";
        //            TBDate.Text = "";
        //            TBCCV.Text = "";
        //            //Procedo a cambiar el estado del pedido a "1" que sería "en preparacion"
        //            ChangeStatusOrder();

        //        }
        //        else
        //        {// Si no es correcto, informo de pago incorrecto
        //            lblMessage.Text = "Ha habido un error en el pago.";
        //            lblMessage.CssClass = "text-danger";
        //            TBCardNumber.Text = "";
        //            TBDate.Text = "";
        //            TBCCV.Text = "";
        //        }
        //    }
        //}

        public void btnPay_Click(object sender, EventArgs e)
        {
            // Convierto la numeración de la tarjeta a texto y limpio en blanco
            string CardNumber = TBCardNumber.Text.Trim();
            string CardDate = TBDate.Text.Trim();

            // Verifico si el número de tarjeta no está vacío
            if (!string.IsNullOrEmpty(CardNumber))
            {
                // Verifico si la fecha de la tarjeta no está vacía y tiene el formato correcto
                if (!string.IsNullOrEmpty(CardDate) && CardDate.Length == 5 && CardDate.Contains("/"))
                {
                    // Obtengo mes y año de la fecha de la tarjeta
                    string[] dateParts = CardDate.Split('/');
                    int month = int.Parse(dateParts[0]);
                    int year = int.Parse("20" + dateParts[1]);

                    // Verifico si la fecha de la tarjeta es mayor que la fecha actual
                    DateTime cardExpiryDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                    if (cardExpiryDate > DateTime.Now) 
                        //Si no esta caducada compruebo tarjeta
                    {
                        // Obtengo los 4 últimos dígitos de la tarjeta bancaria y comparo con 4321
                        string LastFourNumber = CardNumber.Substring(CardNumber.Length - 4);
                        if (LastFourNumber == "4321")
                        {
                            // Si es correcto, asumo pago correcto e informo de ello
                            lblMessage.Text = "Pago correctamente realizado. Comenzamos a preparar su pedido";
                            lblMessage.CssClass = "text-success";
                            lblMessage.Visible = true;
                            TBCardNumber.Text = "";
                            TBDate.Text = "";
                            TBCCV.Text = "";

                            // Procedo a cambiar el estado del pedido a "1" que sería "en preparación"
                            ChangeStatusOrder();
                        }
                        else
                        {
                            // Si no es correcto, informo de pago incorrecto
                            lblMessage.Text = "Ha habido un error en el pago.";
                            lblMessage.CssClass = "text-danger";
                            TBCardNumber.Text = "";
                            TBDate.Text = "";
                            TBCCV.Text = "";
                        }
                    }
                    else
                    {
                        // Si la fecha de la tarjeta es inválida (caducada), informo de error en la fecha
                        lblMessage.Text = "La fecha de caducidad de la tarjeta no es correcta.";
                        lblMessage.CssClass = "text-danger";
                        TBCardNumber.Text = "";
                        TBDate.Text = "";
                        TBCCV.Text = "";
                    }
                }
                else
                {
                    // Si la fecha de la tarjeta tiene un formato incorrecto, informo de error en la fecha
                    lblMessage.Text = "El formato de la fecha es incorrecto. Use mm/aa.";
                    lblMessage.CssClass = "text-danger";
                    TBDate.Text = "";
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
            catch
            {
            }
            finally
            {

            }
        }
    }
}