using System;
using System.Collections.Generic;
using WebShop.BLL.DTOs.Customers;
using WebShop.BOL.Entities;

namespace WebShop.BLL.Mappers.CustomerMapper
{
    public class CustomerMapper : ICustomerMapper
    {
        public Customer MapFromDTOToEntity(CustomerDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new Customer()
            {
                CustomerId = DTO.CustomerId,
                FirstName = DTO.FirstName,
                LastName = DTO.LastName,
                Email = DTO.Email, 
            };

            return entity;
        }

        public LikedItem MapFromDTOToEntity(LikedItemDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new LikedItem()
            {
                LikedItemId = DTO.LikedItemId,
                CustomerId = DTO.CustomerId,
                ProductId = DTO.ProductId,
                CreatedDate = DTO.CreatedDate
            };

            return entity;
        }

        public Order MapFromDTOToEntity(OrderDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new Order()
            {
                OrderId = DTO.OrderId,
                OrderStatus = DTO.OrderStatus,
                CustomerId = DTO.CustomerId,
                ProductId = DTO.ProductId,
                AmountPaid = DTO.AmountPaid,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            return entity;
        }

        public Order MapFromDTOToEntity(EditOrderDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new Order()
            {
                OrderId = DTO.OrderId,
                OrderStatus = DTO.OrderStatus,
                CustomerId = DTO.CustomerId,
                ProductId = DTO.ProductId,
                AmountPaid = DTO.AmountPaid,
                CreatedDate = DTO.CreatedDate,
                UpdatedDate = DateTime.UtcNow
            };

            return entity;
        }

        public ShoppingCartItem MapFromDTOToEntity(ShoppingCartItemDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            var entity = new ShoppingCartItem()
            {
                ShoppingCartItemId = DTO.ShoppingCartItemId,
                CustomerId = DTO.CustomerId,
                ProductId = DTO.ProductId,
                Size = DTO.Size,
                Price = DTO.Price,
                CreatedDate = DateTime.UtcNow
            };

            return entity;
        }

        public CustomerDTO MapFromEntityToDTO(Customer entity)
        {
            if (entity == null)
            {
                return null;
            }

            var DTO = new CustomerDTO()
            {
                CustomerId = entity.CustomerId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email
            };

            return DTO;
        }

        public IEnumerable<CustomerDTO> MapFromEntityToDTO(IEnumerable<Customer> entity)
        {
            if (entity == null)
            {
                return null;
            }

            var DTOList = new List<CustomerDTO>();

            foreach (var item in entity)
            {
                var DTO = MapFromEntityToDTO(item);
                DTOList.Add(DTO);
            }

            return DTOList;
        }

        public OrderDTO MapFromEntityToDTO(Order entity)
        {
            if (entity == null)
            {
                return null;
            }

            var DTO = new OrderDTO()
            {
                OrderId = entity.OrderId,
                OrderStatus = entity.OrderStatus,
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
                AmountPaid = entity.AmountPaid,
                CreatedDate = entity.CreatedDate
            };

            return DTO;
        }
    }
}
