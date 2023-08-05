using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.ViewModels.Addresses
{
    public class DeliveryAddressViewModel
    {
        public int DeliveryAddressId { get; set; }
        [Required]
        [Display(Name = "Name of delivery address")]
        public string NameOfDeliveryAddress { get; set; }
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
