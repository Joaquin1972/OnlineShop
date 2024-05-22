using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Core
{
    public class OrderDetail
    {
        /// <summary>
        /// Clase para agrupar los productos del pedido del usuario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Clave foránea en el pedido
        /// </summary>
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Cantidad del producto
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Precio total del producto
        /// </summary>
        //public decimal TotalPrice { get; set; }
    }

}