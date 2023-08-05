using System;
using WebShop.BLL.DTOs.Customers;
using WebShop.ViewModels.Customers;

namespace WebShop.Mappers.CustomerMapper
{
    public class CustomerMapper : ICustomerMapper
    {
        public LikedItemDTO MapFromViewModelToDTO(LikedItemViewModel likedItemVM)
        {
            if (likedItemVM == null)
            {
                return null;
            }

            var dto = new LikedItemDTO()
            {
                LikedItemId = likedItemVM.LikedItemId,
                CustomerId = likedItemVM.CustomerId,
                ProductId = likedItemVM.ProductId,
                CreatedDate = DateTime.UtcNow
            };

            return dto;
        }

        public CustomerViewModel MapFromDTOToViewModel(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return null;
            }

            var customerViewModel = new CustomerViewModel()
            {
                CustomerId = customerDTO.CustomerId,
                Email = customerDTO.Email,
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName
            };

            return customerViewModel;
        }

        public ShoppingCartItemDTO MapFromViewModelToDTO(ShoppingCartViewModel shoppingCartVM)
        {
            if (shoppingCartVM == null)
            {
                return null;
            }

            var dto = new ShoppingCartItemDTO()
            {
                ShoppingCartItemId = shoppingCartVM.ShoppingCartItemId,
                ProductId = shoppingCartVM.ProductId,
                CustomerId = shoppingCartVM.CustomerId,
                Size = shoppingCartVM.Size,
                Price = shoppingCartVM.Price
            };

            return dto;
        }

        public OrderDTO MapFromViewModelToDTO(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
            {
                return null;
            }

            var dto = new OrderDTO()
            {
                AmountPaid = orderViewModel.AmountPaid,
                CustomerId = orderViewModel.CustomerId,
                OrderStatus = orderViewModel.OrderStatus,
                ProductId = orderViewModel.ProductId,
                OrderId = orderViewModel.OrderId,
                CreatedDate = orderViewModel.CreatedDate
            };

            return dto;
        }

        public EditOrderDTO MapFromViewModelToEditDTO(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
            {
                return null;
            }

            var dto = new EditOrderDTO()
            {
                AmountPaid = orderViewModel.AmountPaid,
                CustomerId = orderViewModel.CustomerId,
                OrderStatus = orderViewModel.OrderStatus,
                ProductId = orderViewModel.ProductId,
                OrderId = orderViewModel.OrderId,
                CreatedDate = orderViewModel.CreatedDate
            };

            return dto;
        }
    }
}
