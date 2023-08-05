using System;
using System.Collections.Generic;
using WebShop.BLL.DTOs.Addresses;
using WebShop.BOL.Entities;

namespace WebShop.BLL.Mappers.Address
{
    public class AddressMapper : IAddressMapper
    {
        public BillingAddress MapFromDTOToEntity(BillingAddressDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new BillingAddress()
            {
                BillingAddressId = DTO.BillingAddressId,
                CustomerId = DTO.CustomerId,
                NameOfBillingAddress = DTO.NameOfBillingAddress,
                Street = DTO.Street,
                ZipCode = DTO.ZipCode,
                City = DTO.City,
                Country = DTO.Country,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            return entity;
        }

        public DeliveryAddress MapFromDTOToEntity(DeliveryAddressDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new DeliveryAddress()
            {
                DeliveryAddressId = DTO.DeliveryAddressId,
                CustomerId = DTO.CustomerId,
                NameOfDeliveryAddress = DTO.NameOfDeliveryAddress,
                Street = DTO.Street,
                ZipCode = DTO.ZipCode,
                City = DTO.City,
                Country = DTO.Country,
                CreatedDate = DTO.CreatedDate,
                UpdatedDate = DateTime.UtcNow
            };

            return entity;
        }

        public BillingAddress MapFromDTOToEntity(EditBillingAddressDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new BillingAddress()
            {
                BillingAddressId = DTO.BillingAddressId,
                CustomerId = DTO.CustomerId,
                NameOfBillingAddress = DTO.NameOfBillingAddress,
                Street = DTO.Street,
                ZipCode = DTO.ZipCode,
                City = DTO.City,
                Country = DTO.Country,
                CreatedDate = DTO.CreatedDate,
                UpdatedDate = DateTime.UtcNow
            };

            return entity;
        }

        public DeliveryAddress MapFromDTOToEntity(EditDeliveryAddressDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new DeliveryAddress()
            {
                DeliveryAddressId = DTO.DeliveryAddressId,
                CustomerId = DTO.CustomerId,
                NameOfDeliveryAddress = DTO.NameOfDeliveryAddress,
                Street = DTO.Street,
                ZipCode = DTO.ZipCode,
                City = DTO.City,
                Country = DTO.Country,
                CreatedDate = DTO.CreatedDate,
                UpdatedDate = DateTime.UtcNow
            };

            return entity;
        }

        public BillingAddressDTO MapFromEntityToDTO(BillingAddress entity)
        {
            if (entity == null)
            {
                return null;
            }

            var DTO = new BillingAddressDTO()
            {
                BillingAddressId = entity.BillingAddressId,
                CustomerId = entity.CustomerId,
                NameOfBillingAddress = entity.NameOfBillingAddress,
                Street = entity.Street,
                ZipCode = entity.ZipCode,
                City = entity.City,
                Country = entity.Country,
                CreatedDate = entity.CreatedDate
            };

            return DTO;
        }

        public IEnumerable<BillingAddressDTO> MapFromEntityToDTO(IEnumerable<BillingAddress> entity)
        {
            if (entity == null)
            {
                return null;
            }

            var DTOList = new List<BillingAddressDTO>();

            foreach (var item in entity)
            {
                var DTO = MapFromEntityToDTO(item);
                DTOList.Add(DTO);
            }

            return DTOList;
        }

        public DeliveryAddressDTO MapFromEntityToDTO(DeliveryAddress entity)
        {
            if (entity == null)
            {
                return null;
            }

            var DTO = new DeliveryAddressDTO()
            {
                DeliveryAddressId = entity.DeliveryAddressId,
                CustomerId = entity.CustomerId,
                NameOfDeliveryAddress = entity.NameOfDeliveryAddress,
                Street = entity.Street,
                ZipCode = entity.ZipCode,
                City = entity.City,
                Country = entity.Country,
                CreatedDate = entity.CreatedDate
            };

            return DTO;
        }

        public IEnumerable<DeliveryAddressDTO> MapFromEntityToDTO(IEnumerable<DeliveryAddress> entity)
        {
            if (entity == null)
            {
                return null;
            }

            var DTOList = new List<DeliveryAddressDTO>();

            foreach (var item in entity)
            {
                var DTO = MapFromEntityToDTO(item);
                DTOList.Add(DTO);
            }

            return DTOList;
        }
    }
}
