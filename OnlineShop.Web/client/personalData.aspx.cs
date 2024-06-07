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
            //Si el usuario esta autenticado, cargo sus datos
            if (User.Identity.IsAuthenticated)
            {
                LoadCurrentData();

            }
        }

        public void LoadCurrentData()
        {
            try { 
            //Obtengo al usuario logado
            string userId = User.Identity.GetUserId();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            //Cargo datos en los textbox
            TBCity.Text = user.City;
            TBAdress.Text = user.Adress;
            TBName.Text = user.Name;
            TBCountry.Text = user.Country;
            TBCP.Text = user.PostalCode;
            } catch
            {
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        public void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                // Obtengo el usuario logado
                string userId = User.Identity.GetUserId();
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(userId);
                //Actualizo su datos
                user.City = TBCity.Text.Trim();
                user.Adress = TBAdress.Text.Trim();
                user.Name = TBName.Text.Trim();
                user.Country = TBCountry.Text.Trim();
                user.PostalCode = TBCP.Text.Trim();
                manager.Update(user);
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
            finally
            {
                Response.Redirect("UserArea.aspx");
            }
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserArea.aspx");
        }
    }
}