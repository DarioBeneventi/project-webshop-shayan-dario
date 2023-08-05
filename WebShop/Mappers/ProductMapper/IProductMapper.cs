using WebShop.BLL.DTOs.Products;
using WebShop.BOL.Entities;
using WebShop.ViewModels.Customers;
using WebShop.ViewModels.Products;

namespace WebShop.Mappers.ProductMapper
{
    public interface IProductMapper
    {
        ProductCreateDTO MapFromViewModelToDTO(ProductCreateViewModel productCreateVM);
        ProductEditDTO MapFromViewModelToDTO(ProductEditViewModel editVM);
        ProductViewModel MapFromDTOToViewModel(ProductDTO dto);
        Product MapFromDTOToEntity(ProductDTO dto);
        ReviewDTO MapFromViewModelToDTO(ReviewViewModel reviewVM, int productId, int customerId);
    }
}
