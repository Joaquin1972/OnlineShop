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
        public int OrderId { get; set; }
        public Order Order { get; set; }

        /// <summary>
        /// Clave foránea del producto
        /// </summary>
        public int ProductId { get; set; }
        public Product Product { get; set; }

        /// <summary>
        /// Cantidad del producto
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Precio total del producto
        /// </summary>
        public decimal TotalPrice { get; set; }
    }

}