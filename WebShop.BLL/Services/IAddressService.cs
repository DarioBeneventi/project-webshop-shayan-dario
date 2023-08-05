using WebShop.BLL.DTOs.Addresses;
using WebShop.BLL.DTOs.Customers;
using WebShop.BOL.Entities;

namespace WebShop.BLL.Services
{
    public interface IAddressService
    {
        BillingAddressDTO GetBillingAddressByCustomer(int id);
        bool BillingAddressExistsOrNot(int customerId);
        BillingAddress AddBillingAddress(BillingAddressDTO model);
        BillingAddress EditBillingAddress(EditBillingAddressDTO model);
        BillingAddress DeleteBillingAddress(int id);
        DeliveryAddressDTO GetDeliveryAddressByCustomer(int id);
        bool DeliveryAddressExistsOrNot(int customerId);
        DeliveryAddress AddDeliveryAddress(DeliveryAddressDTO model);
        DeliveryAddress EditDeliveryAddress(EditDeliveryAddressDTO model);
        DeliveryAddress DeleteDeliveryAddress(int id);
    }
}
