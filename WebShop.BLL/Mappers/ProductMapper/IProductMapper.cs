using WebShop.BLL.DTOs.Products;
using WebShop.BOL.Entities;

namespace WebShop.BLL.Mappers.ProductMapper
{
    public interface IProductMapper
    {
        Product MapFromDTOToEntity(ProductCreateDTO DTO);
        Review MapFromDTOToEntity(ReviewDTO DTO);
        ProductDTO MapFromEntityToDTO(Product entity);
    }
}
