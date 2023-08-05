using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShop.BOL.Enums;

namespace WebShop.ViewModels.Customers
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
        [Required]
        public int CustomerId { get; set; } //created by
        [Required]
        public int ProductId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public double AmountPaid { get; set; }
    }
}
