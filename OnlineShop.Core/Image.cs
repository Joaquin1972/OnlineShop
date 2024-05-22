using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Core
{
    public class Image
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// FK del Producto al cual la imagen esta asociada
        /// </summary>
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        /// <summary>
        /// Path de la imagen
        /// </summary>
        public string ImagePath { get; set; }
    }
}



///Cesta de la compra
///ShoppingCart
///identificador, usuario que ha añadido al carrito, cantidad, 
///producto