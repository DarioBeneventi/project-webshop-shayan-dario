using Microsoft.AspNetCore.Hosting;
using WebShop.BLL.DTOs.Addresses;
using WebShop.BLL.Mappers.Address;
using WebShop.BLL.Mappers.CustomerMapper;
using WebShop.BOL.Entities;
using WebShop.DAL.Repositories;

namespace WebShop.BLL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAddressMapper _addressMapper;
        private readonly ICustomerMapper _customerMapper;


        public AddressService(
            IAddressRepository addressRepository,
            IWebHostEnvironment webHostEnvironment,
            IAddressMapper addressMapper,
            ICustomerMapper customerMapper)
        {
            _addressRepository = addressRepository;
            _webHostEnvironment = webHostEnvironment;
            _addressMapper = addressMapper;
            _customerMapper = customerMapper;
        }

        #region Billing Address
        public BillingAddressDTO GetBillingAddressByCustomer(int id)
        {
            var billingAddress = _addressRepository.GetBillingAddressByCustomer(id);
            var DTO = _addressMapper.MapFromEntityToDTO(billingAddress);

            return DTO;
        }

        public BillingAddress AddBillingAddress(BillingAddressDTO model)
        {
            var billingAddress = _addressMapper.MapFromDTOToEntity(model);

            var billingAddressAdded = _addressRepository.AddBillingAddress(billingAddress);

            return billingAddressAdded;
        }

        public BillingAddress EditBillingAddress(EditBillingAddressDTO model)
        {
            var customer = _addressMapper.MapFromDTOToEntity(model);

            var response = _addressRepository.EditBillingAddress(customer);

            return response;
        }

        public BillingAddress DeleteBillingAddress(int id)
        {
            var billingAddress = _addressRepository.GetBillingAddressByCustomer(id);

            if (billingAddress != null && billingAddress.CustomerId >= 0)
            {
                var response = _addressRepository.DeleteBillingAddress(billingAddress.BillingAddressId);



                return response;
            }

            return null;
        }

        public bool BillingAddressExistsOrNot(int customerId)
        {
            var billingAddress = _addressRepository.GetBillingAddressByCustomer(customerId);

            if (billingAddress != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Delivery Address
        public DeliveryAddressDTO GetDeliveryAddressByCustomer(int id)
        {
            var deliveryAddress = _addressRepository.GetDeliveryAddressByCustomer(id);
            var DTO = _addressMapper.MapFromEntityToDTO(deliveryAddress);

            return DTO;
        }

        public bool DeliveryAddressExistsOrNot(int customerId)
        {
            var deliveryAddress = _addressRepository.GetDeliveryAddressByCustomer(customerId);

            if (deliveryAddress != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DeliveryAddress AddDeliveryAddress(DeliveryAddressDTO model)
        {
            var deliveryAddress = _addressMapper.MapFromDTOToEntity(model);

            var deliveryAddressAdded = _addressRepository.AddDeliveryAddress(deliveryAddress);

            return deliveryAddressAdded;
        }

        public DeliveryAddress EditDeliveryAddress(EditDeliveryAddressDTO model)
        {
            var customer = _addressMapper.MapFromDTOToEntity(model);

            var response = _addressRepository.EditDeliveryAddress(customer);

            return response;
        }

        public DeliveryAddress DeleteDeliveryAddress(int id)
        {

            var deliveryAddress = _addressRepository.GetDeliveryAddressByCustomer(id);

            if (deliveryAddress != null && deliveryAddress.CustomerId >= 0)
            {
                var response = _addressRepository.DeleteDeliveryAddress(deliveryAddress.DeliveryAddressId);



                return response;
            }

            return null;
        }
        #endregion
    }
}
