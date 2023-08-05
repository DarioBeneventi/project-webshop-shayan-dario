using System;
using WebShop.BOL.Entities;

namespace WebShop.BLL.DTOs.Customers
{
    public class LikedItemDTO
    {
        public int LikedItemId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
