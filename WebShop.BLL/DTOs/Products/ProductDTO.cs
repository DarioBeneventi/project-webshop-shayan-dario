using System;
using System.ComponentModel.DataAnnotations;
using WebShop.BOL.Enums;

namespace WebShop.BLL.DTOs.Products
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        [Required]
        public string PhotoPath { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }
        [Required]
        public Category Category { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
