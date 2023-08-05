using WebShop.BOL.Entities;

namespace WebShop.DAL.Repositories
{
    public interface IAddressRepository
    {
        BillingAddress GetBillingAddressByCustomer(int id);
        BillingAddress AddBillingAddress(BillingAddress billingAddress);
        BillingAddress EditBillingAddress(BillingAddress billingAddress);
        BillingAddress DeleteBillingAddress(int id);
        DeliveryAddress GetDeliveryAddressByCustomer(int id);
        DeliveryAddress AddDeliveryAddress(DeliveryAddress deliveryAddress);
        DeliveryAddress EditDeliveryAddress(DeliveryAddress deliveryAddress);
        DeliveryAddress DeleteDeliveryAddress(int id);
    }
}
