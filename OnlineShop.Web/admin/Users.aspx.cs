using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity.Owin;
using OnlineShop.Core;

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
            try
            {
                // Creo el manager de usuarios y bbtengo la lista de todos los usuarios
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var usersShop = manager.Users.ToList();

                //Los muestro en un gridwiew
                gvUsuarios.DataSource = usersShop;
                gvUsuarios.DataBind();
            }


            catch
            {
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al cargar los usuarios",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }

            

        }
    }
}