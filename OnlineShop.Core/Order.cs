using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
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
        public String User_Id { get; set; }

        /// <summary>
        /// Detalles del pedido. Un pedido tendrá uno o varios productos
        /// Pero cada OrderDetails pertenece a un solo pedido.
        /// </summary>
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Fecha del pedido
        /// </summary>
        public DateTime DateOrder { get; set; }

        /// <summary>
        /// Precio del pedido
        /// </summary>

        public Decimal OrderTotalPrice { get; set; }

        /// <summary>
        /// Estado del pedido
        /// </summary>
        public OrderStatus Status { get; set; }

    }

}
