using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop.BOL.Enums;

namespace WebShop.BOL.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
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
        public DateTime UpdatedDate { get; set; }
    }
}
