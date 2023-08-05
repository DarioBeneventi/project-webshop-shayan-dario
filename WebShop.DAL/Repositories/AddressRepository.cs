using EmpManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using WebShop.BOL.Entities;

namespace WebShop.DAL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AddressRepository> _logger;

        public AddressRepository(AppDbContext context, ILogger<AddressRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region Billing Address

        public BillingAddress GetBillingAddressByCustomer(int id)
        {
            var billingAddress = _context.BillingAddresses.FirstOrDefault(b => b.CustomerId == id);

            if (billingAddress != null && billingAddress.CustomerId >= 0)
            {
                return billingAddress;
            }

            return null;
        }

        public BillingAddress AddBillingAddress(BillingAddress billingAddress)
        {
            if (billingAddress != null)
            {
                var newBillingAddress = _context.BillingAddresses.Add(billingAddress);

                if (newBillingAddress != null && newBillingAddress.State == EntityState.Added)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return newBillingAddress.Entity;
                    }
                }
            }
            else
            {
                _logger.LogWarning($"Billing Address is empty, couldn't be added.");
            }

            return null;
        }

        public BillingAddress EditBillingAddress(BillingAddress billingAddress)
        {
            var newBillingAddress = _context.BillingAddresses.Update(billingAddress);

            if (newBillingAddress != null && newBillingAddress.State == EntityState.Modified)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newBillingAddress.Entity;
                }
            }

            return null;
        }

        public BillingAddress DeleteBillingAddress(int id)
        {
            var billingAddress = _context.BillingAddresses.Find(id);

            if (billingAddress != null)
            {
                var deletedBillingAddress = _context.BillingAddresses.Remove(billingAddress);

                if (deletedBillingAddress != null && deletedBillingAddress.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedBillingAddress.Entity;
                    }
                }
            }

            return null;
        }
        #endregion

        #region Delivery Address

        public DeliveryAddress GetDeliveryAddressByCustomer(int id)
        {
            var deliveryAddress = _context.DeliveryAddresses.FirstOrDefault(b => b.CustomerId == id);

            if (deliveryAddress != null && deliveryAddress.CustomerId >= 0)
            {
                return deliveryAddress;
            }

            return null;
        }

        public DeliveryAddress AddDeliveryAddress(DeliveryAddress deliveryAddress)
        {
            if (deliveryAddress != null)
            {
                var newDeliveryAddress = _context.DeliveryAddresses.Add(deliveryAddress);

                if (newDeliveryAddress != null && newDeliveryAddress.State == EntityState.Added)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return newDeliveryAddress.Entity;
                    }
                }
            }
            else
            {
                _logger.LogWarning($"Delivery Address is empty, couldn't be added.");
            }

            return null;
        }

        public DeliveryAddress EditDeliveryAddress(DeliveryAddress deliveryAddress)
        {
            var newDeliveryAddress = _context.DeliveryAddresses.Update(deliveryAddress);

            if (newDeliveryAddress != null && newDeliveryAddress.State == EntityState.Modified)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return newDeliveryAddress.Entity;
                }
            }

            return null;
        }

        public DeliveryAddress DeleteDeliveryAddress(int id)
        {
            var deliveryAddress = _context.DeliveryAddresses.Find(id);

            if (deliveryAddress != null)
            {
                var deletedDeliveryAddress = _context.DeliveryAddresses.Remove(deliveryAddress);

                if (deletedDeliveryAddress != null && deletedDeliveryAddress.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedDeliveryAddress.Entity;
                    }
                }
            }

            return null;
        }
        #endregion        
    }
}
