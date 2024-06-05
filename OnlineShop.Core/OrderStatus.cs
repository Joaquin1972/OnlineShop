namespace OnlineShop.Core
{
    /// <summary>
    /// Estado del pedido
    /// </summary>
    public enum OrderStatus : int
    {
        Pending = 0,
        InPreparation = 1,
        Shipping = 2,
        Delivered = 3,
        Cancelled = 4,
    }
}