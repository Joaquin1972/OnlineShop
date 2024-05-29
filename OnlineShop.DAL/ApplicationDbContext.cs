using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// Creamos las colecciones persistentes == Tablas de Datos de 
        /// las entidades de negocio
        /// </summary>

        //Coleccion/Tabla de Categorías
        public DbSet<Category> Categories { get; set; }
        //Coleccion/Taba de productos
        public DbSet<Product> Products { get; set; }
        //Coleccion/Tabla de pedidos
        public DbSet<Order> Orders { get; set; }
        //Coleccion/Tabla de Detalles del pedido
        public DbSet<OrderDetail> OrderDetails { get; set; }
        //Coleccion/Tabla de path de imagenes
        public DbSet<Image> Images { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set;}


    }
}
