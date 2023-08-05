using Microsoft.AspNetCore.Http;
using System;

namespace WebShop.ViewModels.Products
{
    public class ProductCreateViewModel : ProductViewModel
    {
        public IFormFile Photo { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
