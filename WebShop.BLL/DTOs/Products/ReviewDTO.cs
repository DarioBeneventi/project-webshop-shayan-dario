using System;
using System.ComponentModel.DataAnnotations;
using WebShop.BOL.Entities;

namespace WebShop.BLL.DTOs.Products
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        [StringLength(25)]
        public string TitleReview { get; set; }
        [Required]
        [StringLength(50)]
        public string ReviewText { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
