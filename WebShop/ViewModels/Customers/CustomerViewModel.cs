using System.ComponentModel.DataAnnotations;

namespace WebShop.ViewModels.Customers
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "The email is not in correct format.")]
        public string Email { get; set; }
    }
}
