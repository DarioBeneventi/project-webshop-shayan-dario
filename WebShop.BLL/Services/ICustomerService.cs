using System.Collections.Generic;
using WebShop.BLL.DTOs.Customers;
using WebShop.BOL.Entities;

namespace WebShop.BLL.Services
{
    public interface ICustomerService
    {
        CustomerDTO GetCustomerById(int id);
        IEnumerable<Customer> GetAllCustomers();
        Customer CreateCustomer(CustomerDTO model);
        Customer DeleteCustomer(int id);
        OrderDTO GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        Order CreateOrder(OrderDTO model);
        Order EditOrder(EditOrderDTO model);
        IEnumerable<LikedItem> GetAllLikedItemsByCustomer(int id);
        LikedItem CreateLikedItem(LikedItemDTO model);
        LikedItem DeleteLikedItem(int customerId, int productId);
        IEnumerable<LikedItem> DeleteLikedItemsByProduct(int productId);
        bool LikedItemExistsOrNot(List<LikedItem> likedItems, int customerId, int productId);
        IEnumerable<ShoppingCartItem> GetShoppingCartByCustomer(int id);
        ShoppingCartItem CreateShoppingCartItem(ShoppingCartItemDTO model);
        ShoppingCartItem DeleteShoppingCartItem(int id);
    }
}
