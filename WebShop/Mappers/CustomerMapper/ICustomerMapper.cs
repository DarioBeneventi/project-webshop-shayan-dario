using WebShop.BLL.DTOs.Customers;
using WebShop.ViewModels.Customers;

namespace WebShop.Mappers.CustomerMapper
{
    public interface ICustomerMapper
    {
        LikedItemDTO MapFromViewModelToDTO(LikedItemViewModel likedItemVM);
        CustomerViewModel MapFromDTOToViewModel(CustomerDTO customerDTO);
        ShoppingCartItemDTO MapFromViewModelToDTO(ShoppingCartViewModel shoppingCartVM);
        OrderDTO MapFromViewModelToDTO(OrderViewModel orderViewModel);
        EditOrderDTO MapFromViewModelToEditDTO(OrderViewModel orderViewModel);
    }
}
