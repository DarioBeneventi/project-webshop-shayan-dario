using System;
using WebShop.BOL.Entities;
using WebShop.BOL.Enums;

namespace WebShop.BLL.DTOs.Customers
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public double AmountPaid { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
