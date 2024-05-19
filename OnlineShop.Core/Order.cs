using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core
{
    public class Order
    {
        /// <summary>
        /// Identificador del pedido
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Usuario que realiza el pedido. Clave foranea
        /// </summary>
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }

        /// <summary>
        /// Producto seleccionado. Clave foranea
        /// </summary>
        public Products SelectedProduct { get; set; }
        [ForeignKey("SelectedProduct")]
        public int Product_Id { get; set; }

        /// <summary>
        /// Cantidad a comprar
        /// </summary>
        public int ProductQuantity { get; set; }
        
        /// <summary>
        /// Precio Total del producto
        /// </summary>
        public decimal TotalProductPrice { get; set; }
    }
}
