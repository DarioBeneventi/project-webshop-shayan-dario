using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WebShop.BLL.Services;
using WebShop.BOL.Entities;
using WebShop.Mappers.CustomerMapper;
using WebShop.Mappers.ProductMapper;
using WebShop.ViewModels.Customers;
using WebShop.ViewModels.Products;

namespace WebShop.Controllers
{
    [Authorize(Roles = "SiteManager")]
    public class SiteManagerController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductMapper _productMapper;
        private readonly ICustomerService _customerService;
        private readonly ICustomerMapper _customerMapper;

        public SiteManagerController(
            IProductService productService,
            IProductMapper productMapper,
            ICustomerService customerService,
            ICustomerMapper customerMapper)
        {
            _productService = productService;
            _productMapper = productMapper;
            _customerService = customerService;
            _customerMapper = customerMapper;
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _productMapper.MapFromViewModelToDTO(model);

                var newProduct = _productService.CreateProduct(dto);

                if (newProduct != null)
                {
                    return RedirectToAction("DetailsProduct", "Home", new { Id = newProduct.ProductId });
                }
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _productService.GetProductById(id);

            if (product != null)
            {
                var productEditVM = new ProductEditViewModel()
                {
                    ProductId = product.ProductId,
                    ExistingPhotoPath = product.PhotoPath,
                    Price = product.Price,
                    Name = product.Name,
                    Brand = product.Brand,
                    Category = product.Category,
                    Description = product.Description,
                    CreatedDate = product.CreatedDate
                };

                return View(productEditVM);
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [HttpPost]
        public IActionResult EditProduct(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _productMapper.MapFromViewModelToDTO(model);

                var newProduct = _productService.EditProduct(dto);

                if (newProduct != null && newProduct.ProductId >= 0)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProductById(id);

            if (product != null)
            {
                var productEntity = _productMapper.MapFromDTOToEntity(product);

                return View(productEntity);
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }

        [HttpPost]
        public IActionResult DeleteSure(int id)
        {
            var responseProduct = _productService.DeleteProduct(id);
            _customerService.DeleteLikedItemsByProduct(id);

            if (responseProduct != null && responseProduct.ProductId >= 0)
            {
                return RedirectToAction("Index", "Home");
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }

        public IActionResult ListCustomers()
        {
            var listCustomers = _customerService.GetAllCustomers();

            if (listCustomers != null)
            {
                return View(listCustomers);
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }

        public IActionResult ListOrders()
        {
            var listOrders = _customerService.GetAllOrders();

            if (listOrders != null)
            {
                return View(listOrders);
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }

        [HttpGet]
        public IActionResult EditOrder(int id)
        {
            var order = _customerService.GetOrderById(id);

            if (order != null)
            {
                var orderViewModel = new OrderViewModel()
                {
                    AmountPaid = order.AmountPaid,
                    CustomerId = order.CustomerId,
                    OrderStatus = order.OrderStatus,
                    ProductId = order.ProductId,
                    OrderId = order.OrderId,
                    CreatedDate = order.CreatedDate
                };

                return View(orderViewModel);
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [HttpPost]
        public IActionResult EditOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _customerMapper.MapFromViewModelToEditDTO(model);

                var newOrder = _customerService.EditOrder(dto);

                if (newOrder != null && newOrder.ProductId >= 0)
                {
                    return RedirectToAction("ListOrders", "SiteManager");
                }
            }

            Response.StatusCode = 404;
            return View("Error");
        }
    }
}