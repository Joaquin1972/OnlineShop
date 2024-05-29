using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core
{
    public class ShoppingCart
    {

        /// <summary>
        /// Identificador 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Usuario que realiza la compra
        /// </summary>
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public String User_Id { get; set; }

        /// <summary>
        /// Numero de undades que compra
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Producto que compra
        /// </summary>
       public Product Product { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }

        /// <summary>
        /// Precio del producto cuando realiza la compra
        /// </summary>
        public decimal Price { get; set; }
    }
}
