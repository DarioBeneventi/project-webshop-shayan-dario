using System;
using WebShop.BLL.DTOs.Products;
using WebShop.BOL.Entities;

namespace WebShop.BLL.Mappers.ProductMapper
{
    public class ProductMapper : IProductMapper
    {
        public Product MapFromDTOToEntity(ProductCreateDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new Product()
            {
                ProductId = DTO.ProductId,
                PhotoPath = DTO.PhotoPath,
                Price = DTO.Price,
                Name = DTO.Name,
                Brand = DTO.Brand,
                Category = DTO.Category,
                Description = DTO.Description,
                CreatedDate = DTO.CreatedDate,
                UpdatedDate = DateTime.UtcNow
            };

            return entity;
        }

        public Review MapFromDTOToEntity(ReviewDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new Review()
            {
                ReviewId = DTO.ReviewId,
                CustomerId = DTO.CustomerId,
                ProductId = DTO.ProductId,
                Rating = DTO.Rating,
                TitleReview = DTO.TitleReview,
                ReviewText = DTO.ReviewText,
                CreatedDate = DTO.CreatedDate
            };

            return entity;
        }

        public ProductDTO MapFromEntityToDTO(Product entity)
        {
            if (entity == null)
            {
                return null;
            }

            var DTO = new ProductDTO()
            {
                ProductId = entity.ProductId,
                PhotoPath = entity.PhotoPath,
                Price = entity.Price,
                Name = entity.Name,
                Brand = entity.Brand,
                Category = entity.Category,
                Description = entity.Description,
                CreatedDate = entity.CreatedDate
            };

            return DTO;
        }
    }
}
