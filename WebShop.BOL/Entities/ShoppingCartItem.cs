using System;
using System.ComponentModel.DataAnnotations;
using WebShop.BOL.Enums;

namespace WebShop.BOL.Entities
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        [Required]
        public int CustomerId { get; set; } //created by
        public int ProductId { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
