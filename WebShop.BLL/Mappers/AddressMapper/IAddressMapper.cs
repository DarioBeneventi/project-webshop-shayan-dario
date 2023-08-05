using System.Collections.Generic;
using WebShop.BLL.DTOs.Addresses;
using WebShop.BOL.Entities;

namespace WebShop.BLL.Mappers.Address
{
    public interface IAddressMapper
    {
        BillingAddress MapFromDTOToEntity(BillingAddressDTO DTO);

        BillingAddress MapFromDTOToEntity(EditBillingAddressDTO DTO);

        DeliveryAddress MapFromDTOToEntity(DeliveryAddressDTO DTO);

        DeliveryAddress MapFromDTOToEntity(EditDeliveryAddressDTO DTO);

        BillingAddressDTO MapFromEntityToDTO(BillingAddress entity);

        IEnumerable<BillingAddressDTO> MapFromEntityToDTO(IEnumerable<BillingAddress> entity);

        DeliveryAddressDTO MapFromEntityToDTO(DeliveryAddress entity);

        IEnumerable<DeliveryAddressDTO> MapFromEntityToDTO(IEnumerable<DeliveryAddress> entity);
    }
}
