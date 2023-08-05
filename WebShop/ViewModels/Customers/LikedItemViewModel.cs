using System;

namespace WebShop.ViewModels.Customers
{
    public class LikedItemViewModel
    {
        public int LikedItemId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}