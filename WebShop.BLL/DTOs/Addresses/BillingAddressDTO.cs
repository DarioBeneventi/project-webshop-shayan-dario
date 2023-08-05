using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.BLL.DTOs.Addresses
{
    public class BillingAddressDTO
    {
        public int BillingAddressId { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public string NameOfBillingAddress { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
