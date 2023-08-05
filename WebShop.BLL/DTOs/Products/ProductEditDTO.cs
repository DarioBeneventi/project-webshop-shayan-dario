using System;

namespace WebShop.BLL.DTOs.Products
{
    public class ProductEditDTO : ProductCreateDTO
    {
        public string ExistingPhotoPath { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
