using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.BOL.Entities
{
    public class WebsiteUser : IdentityUser
    {
        public int CustomerId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
