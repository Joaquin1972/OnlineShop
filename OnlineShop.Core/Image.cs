using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Core
{
    public class Image
    {
        public int Id { get; set; }

        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public string ImagePath { get; set; }
    }
}



///Cesta de la compra
///ShoppingCart
///identificador, usuario que ha añadido al carrito, cantidad, 
///producto