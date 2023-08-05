using System;
using WebShop.BLL.DTOs.Products;
using WebShop.BOL.Entities;
using WebShop.ViewModels.Customers;
using WebShop.ViewModels.Products;

namespace WebShop.Mappers.ProductMapper
{
    public class ProductMapper : IProductMapper
    {
        public ProductViewModel MapFromDTOToViewModel(ProductDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            var productViewModel = new ProductViewModel()
            {
                ProductId = dto.ProductId,
                PhotoPath = dto.PhotoPath,
                Price = dto.Price,
                Name = dto.Name,
                Brand = dto.Brand,
                Category = dto.Category,
                Description = dto.Description
            };

            return productViewModel;
        }

        public ProductCreateDTO MapFromViewModelToDTO(ProductCreateViewModel productCreateVM)
        {
            if (productCreateVM == null)
            {
                return null;
            }

            var dto = new ProductCreateDTO()
            {
                ProductId = productCreateVM.ProductId,
                PhotoPath = productCreateVM.PhotoPath,
                Photo = productCreateVM.Photo,
                Price = productCreateVM.Price,
                Name = productCreateVM.Name,
                Brand = productCreateVM.Brand,
                Category = productCreateVM.Category,
                Description = productCreateVM.Description,
                CreatedDate = DateTime.UtcNow
            };

            return dto;
        }

        public ProductEditDTO MapFromViewModelToDTO(ProductEditViewModel ProductEditVM)
        {
            if (ProductEditVM == null)
            {
                return null;
            }

            var dto = new ProductEditDTO()
            {
                ProductId = ProductEditVM.ProductId,
                ExistingPhotoPath = ProductEditVM.ExistingPhotoPath,
                PhotoPath = ProductEditVM.PhotoPath,
                Photo = ProductEditVM.Photo,
                Price = ProductEditVM.Price,
                Name = ProductEditVM.Name,
                Brand = ProductEditVM.Brand,
                Category = ProductEditVM.Category,
                Description = ProductEditVM.Description,
                CreatedDate = ProductEditVM.CreatedDate,
                UpdatedDate = DateTime.UtcNow
            };

            return dto;
        }

        public Product MapFromDTOToEntity(ProductDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            var product = new Product()
            {
                ProductId = dto.ProductId,
                PhotoPath = dto.PhotoPath,
                Price = dto.Price,
                Name = dto.Name,
                Brand = dto.Brand,
                Category = dto.Category,
                Description = dto.Description
            };

            return product;
        }

        public ReviewDTO MapFromViewModelToDTO(ReviewViewModel reviewVM, int productId, int customerId)
        {
            if (reviewVM == null)
            {
                return null;
            }

            var dto = new ReviewDTO()
            {
                ReviewId = reviewVM.ReviewId,
                ProductId = productId,
                CustomerId = customerId,
                Rating = reviewVM.Rating,
                ReviewText = reviewVM.ReviewText,
                TitleReview = reviewVM.TitleReview,
                CreatedDate = DateTime.UtcNow
            };

            return dto;
        }
    }
}
