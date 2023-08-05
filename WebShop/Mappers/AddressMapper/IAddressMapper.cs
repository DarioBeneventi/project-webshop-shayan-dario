using WebShop.BLL.DTOs.Addresses;
using WebShop.ViewModels.Addresses;

namespace WebShop.Mappers.AddressMapper
{
    public interface IAddressMapper
    {
        DeliveryAddressDTO MapFromViewModelToDTO(DeliveryAddressViewModel deliveryAddressVM, int customerId);
        BillingAddressDTO MapFromViewModelToDTO(BillingAddressViewModel billingAddressVM, int customerId);
        EditDeliveryAddressDTO MapFromViewModelToDTO(EditDeliveryAddressViewModel editDeliveryAddressVM);
        EditBillingAddressDTO MapFromViewModelToDTO(EditBillingAddressViewModel editBillingAddressVM);
    }
}
