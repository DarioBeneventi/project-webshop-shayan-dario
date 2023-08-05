using System;
using WebShop.BOL.Entities;
using WebShop.BOL.Enums;

namespace WebShop.BLL.DTOs.Customers
{
    public class ShoppingCartItemDTO
    {
        public int ShoppingCartItemId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
