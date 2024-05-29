using Microsoft.AspNet.Identity;
using OnlineShop.Application;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.client
{
    public partial class CurrentShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentOrderPendingbyUser();
        }

        public void CurrentOrderPendingbyUser()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    string userId = User.Identity.GetUserId();

                    ApplicationDbContext context = new ApplicationDbContext();


                    OrderManager orderManager = new OrderManager(context);
                    var userOrders = orderManager.GetPendingOrderByUserId(userId);
                    LblOrderUserIdPending.Text = userOrders.Id.ToString();
                    LblDateOrderUserIdPending.Text = userOrders.DateOrder.ToString("dd/MM/yyyy");

                    // Aquí puedes enlazar los pedidos del usuario a un control de UI, como un GridView o Repeater
                    //    gvUserOrders.DataSource = userOrders;
                    //    gvUserOrders.DataBind();

                }

            }
            catch
            {

            }
        }
    }
}