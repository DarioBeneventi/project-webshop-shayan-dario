using WebShop.BOL.Enums;


namespace WebShop.ViewModels.Customers
{
    public class ShoppingCartViewModel
    {
        public int ShoppingCartItemId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
    }

}
