using System;

namespace WebShop.ViewModels.Products
{
    public class ProductEditViewModel : ProductCreateViewModel
    {
        public string ExistingPhotoPath { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
