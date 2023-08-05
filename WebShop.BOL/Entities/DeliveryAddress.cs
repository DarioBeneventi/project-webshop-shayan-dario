using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.BOL.Entities
{
    public class DeliveryAddress
    {
        public int DeliveryAddressId { get; set; }
        [Required]
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
        public DateTime UpdatedDate { get; set; }
    }
}
