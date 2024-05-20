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
        /// Usuario que realiza el pedido. Clave foránea
        /// </summary>
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }

        /// <summary>
        /// Detalles del pedido. Un pedido tendrá uno o varios productos
        /// Pero cada OrderDetails pertenece a un solo pedido.
        /// </summary>
        public ICollection<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Precio total del pedido
        /// </summary>
        public decimal TotalOrderPrice { get; set; }
    }

}
