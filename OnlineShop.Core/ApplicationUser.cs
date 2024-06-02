using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core
{
    public class ApplicationUser : IdentityUser
    {
        public ClaimsIdentity GenerateUserIdentity(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

        //AÑADO MAS DATOS A LA ENTIDAD USUARIO//


        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DNI del usuario
        /// </summary>
        public string DNI {  get; set; }

        /// <summary>
        /// Dirección del usuario
        /// </summary>
        public string Adress {  get; set; }

        /// <summary>
        /// Codigo Postal del usuario
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Ciudad del usuario
        /// </summary>

        public string City { get; set; }

        /// <summary>
        /// País del Usuario
        /// </summary>
        public string Country { get; set; }
    }

}
