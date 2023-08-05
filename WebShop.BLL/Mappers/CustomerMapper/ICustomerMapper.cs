using System.Collections.Generic;
using WebShop.BLL.DTOs.Customers;
using WebShop.BOL.Entities;

namespace WebShop.BLL.Mappers.CustomerMapper
{
    public interface ICustomerMapper
    {
        Customer MapFromDTOToEntity(CustomerDTO DTO);
        LikedItem MapFromDTOToEntity(LikedItemDTO DTO);
        Order MapFromDTOToEntity(OrderDTO DTO);
        Order MapFromDTOToEntity(EditOrderDTO DTO);
        ShoppingCartItem MapFromDTOToEntity(ShoppingCartItemDTO DTO);
        CustomerDTO MapFromEntityToDTO(Customer entity);
        OrderDTO MapFromEntityToDTO(Order entity);
        IEnumerable<CustomerDTO> MapFromEntityToDTO(IEnumerable<Customer> entity);
    }
}
