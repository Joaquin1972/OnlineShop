using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace OnlineShop.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Configurar la seguridad
            //Crear los roles necesarios
            ApplicationDbContext context = new ApplicationDbContext();
            RoleManager<IdentityRole> roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager =
    new UserManager<ApplicationUser>(
        new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));
            if (!roleManager.RoleExists("Client"))
                roleManager.Create(new IdentityRole("Client"));

            ApplicationUser user = userManager.FindByName("admin@admin.com");

            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                IdentityResult result = userManager.Create(user, "123Asd@");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
                else
                {
                    throw new Exception("Usuario no creado");
                }
            }


        }
    }
}