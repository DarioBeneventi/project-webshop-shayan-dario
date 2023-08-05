using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.BOL.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Required]
        public int CustomerId { get; set; } //created by
        public int ProductId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        [StringLength(25)]
        public string TitleReview { get; set; }
        [Required]
        [StringLength(300)]
        public string ReviewText { get; set; }
        [Required]
        [Display(Name = "Date of review")]
        public DateTime CreatedDate { get; set; }
    }
}