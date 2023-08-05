using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.ViewModels.Addresses
{
    public class BillingAddressViewModel
    {
        public int BillingAddressId { get; set; }
        [Required]
        [Display(Name = "Name of billing address")]
        public string NameOfBillingAddress { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int CustomerId { get; set; } //created and updated by
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
