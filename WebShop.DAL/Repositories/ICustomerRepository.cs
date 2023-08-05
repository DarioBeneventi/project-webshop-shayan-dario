using System.Collections.Generic;
using WebShop.BOL.Entities;

namespace WebShop.DAL.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetAllCustomers();
        Customer CreateCustomer(Customer customer);
        Customer DeleteCustomer(int id);
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        Order CreateOrder(Order order);
        Order EditOrder(Order order);
        LikedItem GetLikedItemById(int id);
        IEnumerable<LikedItem> GetAllLikedItems();
        LikedItem CreateLikedItem(LikedItem likedItem);
        LikedItem DeleteLikedItem(int customerId, int productId);
        IEnumerable<LikedItem> DeleteLikedItemByProduct(IEnumerable<LikedItem> likedItems);
        ShoppingCartItem GetShoppingCartItemById(int id);
        IEnumerable<ShoppingCartItem> GetAllShoppingCartItems();
        ShoppingCartItem CreateShoppingCartItem(ShoppingCartItem shoppingCart);
        ShoppingCartItem DeleteShoppingCartItem(int id);
    }
}
