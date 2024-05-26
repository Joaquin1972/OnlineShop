using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.client
{
    public partial class ProductEditClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar el ID de la consulta
                string id = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    // Aquí puedes llamar a un método para cargar los detalles del producto
                    // utilizando el ID recuperado
                    lblId.Text = id;
                }
                else
                {
                    // Manejar el caso donde el ID no esté presente o sea inválido
                    // Esto puede incluir redirigir a una página de error o mostrar un mensaje
                    lblId.Text = "ko" + id + "ko";
                }
            }
        }
    }
}