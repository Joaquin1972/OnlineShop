using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.client
{
    public partial class personalData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Recupero Id de usuario
                string userId = User.Identity.GetUserId();
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(userId);
                user.City = "Burgos";
                user.Adress = "Calle de la Oscuridad";
                user.Name = "Jose";
                user.Country = "España";
                user.PostalCode = "50016";
                manager.Update(user);
                
            }
        }
    }
}