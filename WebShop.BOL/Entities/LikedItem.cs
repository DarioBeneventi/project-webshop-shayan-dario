using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.BOL.Entities
{
    public class LikedItem
    {
        public int LikedItemId { get; set; }
        [Required]
        public int CustomerId { get; set; } //created by
        [Required]
        public int ProductId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
