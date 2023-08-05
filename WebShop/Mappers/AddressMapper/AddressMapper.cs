using System;
using WebShop.BLL.DTOs.Addresses;
using WebShop.ViewModels.Addresses;

namespace WebShop.Mappers.AddressMapper
{
    public class AddressMapper : IAddressMapper
    {
        public DeliveryAddressDTO MapFromViewModelToDTO(DeliveryAddressViewModel deliveryAddressVM, int customerId)
        {
            if (deliveryAddressVM == null)
            {
                return null;
            }

            var dto = new DeliveryAddressDTO()
            {
                DeliveryAddressId = deliveryAddressVM.DeliveryAddressId,
                CustomerId = customerId,
                NameOfDeliveryAddress = deliveryAddressVM.NameOfDeliveryAddress,
                City = deliveryAddressVM.City,
                Country = deliveryAddressVM.Country,
                Street = deliveryAddressVM.Street,
                ZipCode = deliveryAddressVM.ZipCode,
                CreatedDate = DateTime.UtcNow
            };

            return dto;
        }

        public BillingAddressDTO MapFromViewModelToDTO(BillingAddressViewModel billingAddressVM, int customerId)
        {
            if (billingAddressVM == null)
            {
                return null;
            }

            var dto = new BillingAddressDTO()
            {
                BillingAddressId = billingAddressVM.BillingAddressId,
                CustomerId = customerId,
                NameOfBillingAddress = billingAddressVM.NameOfBillingAddress,
                City = billingAddressVM.City,
                Country = billingAddressVM.Country,
                Street = billingAddressVM.Street,
                ZipCode = billingAddressVM.ZipCode,
                CreatedDate = DateTime.UtcNow
            };

            return dto;
        }

        public EditDeliveryAddressDTO MapFromViewModelToDTO(EditDeliveryAddressViewModel editDeliveryAddressVM)
        {
            if (editDeliveryAddressVM == null)
            {
                return null;
            }

            var dto = new EditDeliveryAddressDTO()
            {
                DeliveryAddressId = editDeliveryAddressVM.DeliveryAddressId,
                CustomerId = editDeliveryAddressVM.CustomerId,
                NameOfDeliveryAddress = editDeliveryAddressVM.NameOfDeliveryAddress,
                City = editDeliveryAddressVM.City,
                Country = editDeliveryAddressVM.Country,
                Street = editDeliveryAddressVM.Street,
                ZipCode = editDeliveryAddressVM.ZipCode,
                CreatedDate = editDeliveryAddressVM.CreatedDate,
                UpdatedDate = DateTime.UtcNow
            };

            return dto;
        }



        public EditBillingAddressDTO MapFromViewModelToDTO(EditBillingAddressViewModel editBillingAddressVM)
        {
            if (editBillingAddressVM == null)
            {
                return null;
            }

            var dto = new EditBillingAddressDTO()
            {
                BillingAddressId = editBillingAddressVM.BillingAddressId,
                CustomerId = editBillingAddressVM.CustomerId,
                NameOfBillingAddress = editBillingAddressVM.NameOfBillingAddress,
                City = editBillingAddressVM.City,
                Country = editBillingAddressVM.Country,
                Street = editBillingAddressVM.Street,
                ZipCode = editBillingAddressVM.ZipCode,
                CreatedDate = editBillingAddressVM.CreatedDate,
                UpdatedDate = DateTime.UtcNow
            };

            return dto;
        }
    }
}
