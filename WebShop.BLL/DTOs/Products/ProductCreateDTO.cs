using Microsoft.AspNetCore.Http;
using System;

namespace WebShop.BLL.DTOs.Products
{
    public class ProductCreateDTO : ProductDTO
    {
        public IFormFile Photo { get; set; }
    }
}