using System;
using System.Collections.Generic;
using System.Linq;
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
                    lblPaymentAmount.Text = "La cantidad a pagar a pagar es: " + paymentAmount + "€";
                }
                else
                {
                    lblPaymentAmount.Text = "No se ha especificado un monto de pago.";
                }
            }
        }

    }
}