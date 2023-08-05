using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.ViewModels.Customers
{
    public class ReviewViewModel
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
