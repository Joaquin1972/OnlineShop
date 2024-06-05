using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security.OAuth;

namespace OnlineShop.Web.admin
{
    public partial class Users : System.Web.UI.Page
    {

        public void Page_Load(object sender, EventArgs e)
        {
            //Cargo usuarios
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        public void LoadUsers()
        {
            // Creo el UserManager y el DbContext
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());

            // Obtengo la lista de todos los usuarios
            var usuarios = userManager.Users.ToList();
           

            // Mostrar los usuarios en un control, como un GridView
            gvUsuarios.DataSource = usuarios;
            gvUsuarios.DataBind();
        }
    }
}