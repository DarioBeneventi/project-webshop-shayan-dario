using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using WebShop.BLL.DTOs.Customers;
using WebShop.BLL.Mappers.CustomerMapper;
using WebShop.BOL.Entities;
using WebShop.DAL.Repositories;

namespace WebShop.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICustomerMapper _customerMapper;
        private readonly UserManager<WebsiteUser> _userManager;

        public CustomerService(
            ICustomerRepository customerRepository,
            IWebHostEnvironment webHostEnvironment,
            ICustomerMapper customerMapper,
            UserManager<WebsiteUser> userManager)
        {
            _customerRepository = customerRepository;
            _webHostEnvironment = webHostEnvironment;
            _customerMapper = customerMapper;
            _userManager = userManager;
        }

        #region Customer
        public CustomerDTO GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            var dto = _customerMapper.MapFromEntityToDTO(customer);

            return dto;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customerList = _customerRepository.GetAllCustomers();
            return customerList;
        }

        public Customer CreateCustomer(CustomerDTO model)
        {
            var oldCustomer = _customerMapper.MapFromDTOToEntity(model);

            var newCustomer = _customerRepository.CreateCustomer(oldCustomer);

            return newCustomer;
        }

        public Customer DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer != null && customer.CustomerId >= 0)
            {
                var response = _customerRepository.DeleteCustomer(id);

                return response;
            }

            return null;
        }
        #endregion

        #region Order
        public OrderDTO GetOrderById(int id)
        {
            var order = _customerRepository.GetOrderById(id);

            var dto = _customerMapper.MapFromEntityToDTO(order);

            return dto;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orderList = _customerRepository.GetAllOrders();

            return orderList;
        }

        public Order CreateOrder(OrderDTO model)
        {
            var oldOrder = _customerMapper.MapFromDTOToEntity(model);

            var newOrder = _customerRepository.CreateOrder(oldOrder);

            return newOrder;
        }

        public Order EditOrder(EditOrderDTO model)
        {
            var order = _customerMapper.MapFromDTOToEntity(model);

            var response = _customerRepository.EditOrder(order);

            return response;
        }
        #endregion

        #region Liked Item

        public IEnumerable<LikedItem> GetAllLikedItemsByCustomer(int id)
        {
            var likedItemList = _customerRepository.GetAllLikedItems();
            var likedItemsByCustomerList = likedItemList.Where(l => l.CustomerId == id);

            return likedItemsByCustomerList;
        }

        public LikedItem CreateLikedItem(LikedItemDTO model)
        {
            var likedItem = _customerMapper.MapFromDTOToEntity(model);

            var newLikedItem = _customerRepository.CreateLikedItem(likedItem);

            return newLikedItem;
        }

        public LikedItem DeleteLikedItem(int customerId, int productId)
        {
            var likedItemsList = _customerRepository.GetAllLikedItems().ToList();
            var likedItemToDelete = LikedItemExistsOrNot(likedItemsList, customerId, productId);
            
            if (likedItemToDelete == true)
            {
                var response = _customerRepository.DeleteLikedItem(customerId, productId);

                return response;
            }

            return null;
        }

        public IEnumerable<LikedItem> DeleteLikedItemsByProduct(int productId)
        {
            var likedItemList = _customerRepository.GetAllLikedItems().Where(l => l.ProductId == productId);

            if (likedItemList != null)
            {
                var response = _customerRepository.DeleteLikedItemByProduct(likedItemList);
            }

            return null;
        }

        public bool LikedItemExistsOrNot(List<LikedItem> likedItems, int customerId,int productId)
        {
            var contains = likedItems.Any(l => l.CustomerId == customerId && l.ProductId == productId);

            if (contains)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ShoppingCart Item

        public IEnumerable<ShoppingCartItem> GetShoppingCartByCustomer(int id)
        {
            var shoppingCartList = _customerRepository.GetAllShoppingCartItems();
            var shoppingCartByCustomerList = shoppingCartList.Where(s => s.CustomerId == id);

            return shoppingCartByCustomerList;
        }

        public ShoppingCartItem CreateShoppingCartItem(ShoppingCartItemDTO model)
        {
            var oldShoppingCartItem = _customerMapper.MapFromDTOToEntity(model);

            var newShoppingCartItem = _customerRepository.CreateShoppingCartItem(oldShoppingCartItem);

            return newShoppingCartItem;
        }

        public ShoppingCartItem DeleteShoppingCartItem(int id)
        {

            var shoppingCartItem = _customerRepository.GetShoppingCartItemById(id);
            
            if (shoppingCartItem != null && shoppingCartItem.CustomerId >= 0)
            {
                var response = _customerRepository.DeleteShoppingCartItem(id);

                return response;
                
            }

            return null;
        }
        #endregion
    }
}