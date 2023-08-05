using System.ComponentModel.DataAnnotations;
using WebShop.BOL.Entities;

namespace WebShop.BLL.DTOs.Customers
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(40)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "The email is not in correct format.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
