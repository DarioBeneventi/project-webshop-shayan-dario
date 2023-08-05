using EmpManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebShop.BOL.Entities;

namespace WebShop.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(AppDbContext context, ILogger<CustomerRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region Customer

        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var listCustomers = _context.Customers;
            return listCustomers;
        }

        public Customer CreateCustomer(Customer customer)
        {
            if (customer != null)
            {
                var newCustomer = _context.Customers.Add(customer);

                if (newCustomer != null && newCustomer.State == EntityState.Added)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return newCustomer.Entity;
                    }
                }
            }
            else
            {
                _logger.LogWarning($"Customer is empty, couldn't be added.");
            }

            return null;
        }

        public Customer DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer != null)
            {
                var deletedCustomer = _context.Customers.Remove(customer);

                if (deletedCustomer != null && deletedCustomer.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedCustomer.Entity;
                    }
                }
            }

            return null;
        }
        #endregion

        #region Order

        public Order GetOrderById(int id)
        {
            var order = _context.Orders.Find(id);
            return order;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var listOrders = _context.Orders;
            return listOrders;
        }

        public Order CreateOrder(Order order)
        {
            if (order != null)
            {
                var newOrder = _context.Orders.Add(order);

                if (newOrder != null && newOrder.State == EntityState.Added)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return newOrder.Entity;
                    }
                }
            }
            else
            {
                _logger.LogWarning($"Orders is empty, couldn't be added.");
            }

            return null;
        }

        public Order EditOrder(Order order)
        {
            var updatedOrder = _context.Orders.Update(order);

            if (updatedOrder != null && updatedOrder.State == EntityState.Modified)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return updatedOrder.Entity;
                }
            }

            return null;
        }
        #endregion

        #region Liked Item

        public LikedItem GetLikedItemById(int id)
        {
            var likedItem = _context.LikedItems.Find(id);
            return likedItem;
        }

        public IEnumerable<LikedItem> GetAllLikedItems()
        {
            var listLikedItems = _context.LikedItems;
            return listLikedItems;
        }

        public LikedItem CreateLikedItem(LikedItem likedItem)
        {
            var listLikedItems = _context.LikedItems;

            if (likedItem != null)
            {
                var newLikedItem = _context.LikedItems.Add(likedItem);

                if (newLikedItem != null && newLikedItem.State == EntityState.Added && !listLikedItems.Any(l => l.CustomerId == newLikedItem.Entity.CustomerId && l.ProductId == newLikedItem.Entity.ProductId))
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return newLikedItem.Entity;
                    }
                }
            }
            else
            {
                _logger.LogWarning($"Liked Item is empty, couldn't be added.");
            }

            return null;
        }

        public LikedItem DeleteLikedItem(int customerId, int productId)
        {
            var likedItem = _context.LikedItems.FirstOrDefault(l => l.CustomerId == customerId && l.ProductId == productId);

            if (likedItem != null)
            {
                var deletedLikedItem = _context.LikedItems.Remove(likedItem);

                if (deletedLikedItem != null && deletedLikedItem.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedLikedItem.Entity;
                    }
                }
            }

            return null;
        }

        public IEnumerable<LikedItem> DeleteLikedItemByProduct(IEnumerable<LikedItem> likedItems)
        {
            if (likedItems != null)
            {
                _context.LikedItems.RemoveRange(likedItems);
                _context.SaveChanges();
            }

            return null;
        }
        #endregion

        #region ShoppingCart Item

        public ShoppingCartItem GetShoppingCartItemById(int id)
        {
            var shoppingCartItem = _context.ShoppingCartItems.Find(id);
            return shoppingCartItem;
        }

        public IEnumerable<ShoppingCartItem> GetAllShoppingCartItems()
        {
            var shoppingCartItemsList = _context.ShoppingCartItems;
            return shoppingCartItemsList;
        }

        public ShoppingCartItem CreateShoppingCartItem(ShoppingCartItem shoppingCart)
        {
            if (shoppingCart != null)
            {
                var newShoppingCart = _context.ShoppingCartItems.Add(shoppingCart);

                if (newShoppingCart != null && newShoppingCart.State == EntityState.Added)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return newShoppingCart.Entity;
                    }
                }
            }
            else
            {
                _logger.LogWarning($"ShoppingCart Item is empty, couldn't be added.");
            }

            return null;
        }

        public ShoppingCartItem DeleteShoppingCartItem(int id)
        {
            var shoppingCartItem = _context.ShoppingCartItems.Find(id);

            if (shoppingCartItem != null)
            {
                var deletedShoppingCartItem = _context.ShoppingCartItems.Remove(shoppingCartItem);

                if (deletedShoppingCartItem != null && deletedShoppingCartItem.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedShoppingCartItem.Entity;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
