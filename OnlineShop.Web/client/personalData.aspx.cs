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
                LoadCurrentData();
                
            }
        }

        public void LoadCurrentData()
        {
            string userId = User.Identity.GetUserId();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            TBCity.Text = user.City;
            TBAdress.Text = user.Adress;
            TBName.Text = user.Name;
            TBCountry.Text = user.Country;
            TBCP.Text = user.PostalCode;
        }

        public void BtnUpdate_Click(object sender, EventArgs e)
        {
            try {
            // Recupero Id de usuario
            string userId = User.Identity.GetUserId();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            user.City = TBCity.Text.Trim();
            user.Adress = TBAdress.Text.Trim();
            user.Name = TBName.Text.Trim();
            user.Country = TBCountry.Text.Trim();
            user.PostalCode = TBCP.Text.Trim();
            manager.Update(user); }
            catch
            {

            }
            finally
            {
                Response.Redirect("UserArea.aspx");
            }
        }
    }
}