using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core
{
    public class Product
    {
        /// <summary>
        /// Identificador del Producto
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del Producto
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Descripción del producto
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Cantidades en stock del producto
        /// </summary>
        public int Stock {  get; set; }
        /// <summary>
        /// Path de la fotografía del producto
        /// </summary>
        public string FotographyPath { get; set; }

        /// <summary>
        /// Categoria a la que pertenece el producto. Clave foranea de categoria
        /// </summary>
        public Category Category { get; set; }
        [ForeignKey ("Category")]
        public int Category_Id { get; set; }




    }
}
