using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebShop.BLL.Services;
using WebShop.BOL.Entities;
using WebShop.BOL.Enums;
using WebShop.Mappers.AddressMapper;
using WebShop.Mappers.CustomerMapper;
using WebShop.Mappers.ProductMapper;
using WebShop.ViewModels.Addresses;
using WebShop.ViewModels.Customers;
using WebShop.ViewModels.Products;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductMapper _productMapper;
        private readonly ICustomerService _customerService;
        private readonly ICustomerMapper _customerMapper;
        private readonly IAddressService _addressService;
        private readonly IAddressMapper _addressMapper;
        private readonly UserManager<WebsiteUser> _userManager;

        public HomeController(
            IProductService productService,
            IProductMapper productMapper,
            ICustomerService customerService,
            ICustomerMapper customerMapper,
            IAddressService addressService,
            IAddressMapper addressMapper,
            UserManager<WebsiteUser> userManager)
        {
            _productService = productService;
            _productMapper = productMapper;
            _customerService = customerService;
            _customerMapper = customerMapper;
            _addressService = addressService;
            _addressMapper = addressMapper;
            _userManager = userManager;
        }

        #region Index&DetailsProd&Profile
        [AllowAnonymous]
        public IActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var productList = _productService.GetAllProducts();

            if (!string.IsNullOrEmpty(searchString))
            {
                productList = productList.Where(p => p.Brand.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 || p.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            return View(productList);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult DetailsProduct(int id)
        {
            var dto = _productService.GetProductById(id);

            if (dto != null && dto.ProductId >= 0)
            {
                var viewModel = _productMapper.MapFromDTOToViewModel(dto);

                var productDetailViewModel = new ProductDetailViewModel()
                {
                    Product = viewModel,
                    PageTitle = "Product Details"
                };

                return View(productDetailViewModel);
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> ProfileAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
            var dto = _customerService.GetCustomerById(customer.CustomerId);

            if (dto != null && dto.CustomerId >= 0)
            {
                var customerViewModel = new CustomerViewModel()
                {
                    CustomerId = dto.CustomerId,
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName
                };

                return View(customerViewModel);
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }

        #endregion

        #region Review

        [Authorize(Roles = "Reviewer")]
        [HttpGet]
        public IActionResult CreateReview()
        {
            return View();
        }

        [Authorize(Roles = "Reviewer")]
        [HttpPost]
        public async Task<IActionResult> CreateReviewAsync(ReviewViewModel model, int id)
        {
            if (model != null)
            {
                WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();

                if (customer != null && customer.CustomerId >= 0)
                {
                    var dto = _productMapper.MapFromViewModelToDTO(model,id,customer.CustomerId);

                    var newReview = _productService.CreateReview(dto);

                    if (newReview != null)
                    {
                        return RedirectToAction("ListReviews", "Home", new { Id = newReview.ReviewId });
                    }
                }
                return View();
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [Authorize(Roles = "Reviewer")]
        [HttpGet]
        public async Task<IActionResult> ListReviewsAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();

            var listReviews = _productService.GetAllReviewsByCustomer(customer.CustomerId);

            if (listReviews != null)
            {
                return View(listReviews);
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ListReviewsByProductAsync(int id)
        {
            var listReviewsByProduct = _productService.GetAllReviewsByProduct(id);

            if (listReviewsByProduct != null)
            {
                return View(listReviewsByProduct);
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }

        [Authorize(Roles = "Reviewer")]
        [HttpPost]
        public IActionResult DeleteReview(int reviewId)
        {
            var responseReview = _productService.DeleteMyReview(reviewId);

            if (responseReview != null && responseReview.ReviewId >= 0)
            {
                return RedirectToAction("ListReviews", "Home");
            }

            return View("NotFound");
        }
        #endregion

        #region LikedItem
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> AddLikedItemAsync(int productId)
        {
            if (ModelState.IsValid)
            {
                WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();

                if (customer != null && customer.CustomerId >= 0)
                {
                    var likedItemViewModel = new LikedItemViewModel()
                    {
                        ProductId = productId,
                        CustomerId = customer.CustomerId,
                        CreatedDate = DateTime.UtcNow
                    };

                    var dto = _customerMapper.MapFromViewModelToDTO(likedItemViewModel);
                    var newLikedItem = _customerService.CreateLikedItem(dto);

                    if (newLikedItem != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> ListLikedItemsAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
            var listLikedItems = _customerService.GetAllLikedItemsByCustomer(customer.CustomerId);

            if (listLikedItems != null)
            {
                return View(listLikedItems);
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> DeleteLikedItemAsync(int productId)
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
            if (customer.CustomerId >= 0 && productId >= 0)
            {
                var deleteLikedItem = _customerService.DeleteLikedItem(customer.CustomerId, productId);

                if (deleteLikedItem != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            Response.StatusCode = 404;
            return View("Error");
        }
        #endregion

        #region Addressess
        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> CreateDeliveryAddressAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
            if (_addressService.DeliveryAddressExistsOrNot(customer.CustomerId) == false)
            {
                return View();
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> CreateDeliveryAddressAsync(DeliveryAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
                if (_addressService.DeliveryAddressExistsOrNot(customer.CustomerId) == false)
                {
                    var dto = _addressMapper.MapFromViewModelToDTO(model, customer.CustomerId);

                    var newDeliveryAddress = _addressService.AddDeliveryAddress(dto);

                    if (newDeliveryAddress != null)
                    {
                        return RedirectToAction("Profile", "Home");
                    }
                }
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> EditDeliveryAddressAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
            var deliveryAddress = _addressService.GetDeliveryAddressByCustomer(customer.CustomerId);

            if (deliveryAddress != null)
            {
                var editDeliveryAddressViewModel = new EditDeliveryAddressViewModel()
                {
                    DeliveryAddressId = deliveryAddress.DeliveryAddressId,
                    CustomerId = deliveryAddress.CustomerId,
                    City = deliveryAddress.City,
                    Country = deliveryAddress.Country,
                    NameOfDeliveryAddress = deliveryAddress.NameOfDeliveryAddress,
                    Street = deliveryAddress.Street,
                    CreatedDate = deliveryAddress.CreatedDate,
                    ZipCode = deliveryAddress.ZipCode
                };

                return View(editDeliveryAddressViewModel);
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public IActionResult EditDeliveryAddress(EditDeliveryAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _addressMapper.MapFromViewModelToDTO(model);

                var newDeliveryAddress = _addressService.EditDeliveryAddress(dto);



                if (newDeliveryAddress != null && newDeliveryAddress.CustomerId >= 0)
                {
                    return RedirectToAction("Profile", "Home");
                }
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> DeleteDeliveryAddressAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
            var responseDeliveryAddress = _addressService.DeleteDeliveryAddress(customer.CustomerId);



            if (responseDeliveryAddress != null && responseDeliveryAddress.CustomerId >= 0)
            {
                return RedirectToAction("Profile", "Home");
            }



            Response.StatusCode = 404;
            return View("NotFound");
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> CreateBillingAddressAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
            if (_addressService.BillingAddressExistsOrNot(customer.CustomerId) == false)
            {
                return View();
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> CreateBillingAddressAsync(BillingAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
                if (_addressService.BillingAddressExistsOrNot(customer.CustomerId) == false)
                {
                    var dto = _addressMapper.MapFromViewModelToDTO(model, customer.CustomerId);

                    var newBillingAddress = _addressService.AddBillingAddress(dto);

                    if (newBillingAddress != null)
                    {
                        return RedirectToAction("Profile", "Home");
                    }
                }
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> EditBillingAddressAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
            var billingAddress = _addressService.GetBillingAddressByCustomer(customer.CustomerId);

            if (billingAddress != null)
            {
                var editBillingAddressViewModel = new EditBillingAddressViewModel()
                {
                    BillingAddressId = billingAddress.BillingAddressId,
                    CustomerId = billingAddress.CustomerId,
                    City = billingAddress.City,
                    Country = billingAddress.Country,
                    NameOfBillingAddress = billingAddress.NameOfBillingAddress,
                    Street = billingAddress.Street,
                    CreatedDate = billingAddress.CreatedDate,
                    ZipCode = billingAddress.ZipCode
                };

                return View(editBillingAddressViewModel);
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public IActionResult EditBillingAddress(EditBillingAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = _addressMapper.MapFromViewModelToDTO(model);

                var newBillingAddress = _addressService.EditBillingAddress(dto);

                if (newBillingAddress != null && newBillingAddress.CustomerId >= 0)
                {
                    return RedirectToAction("Profile", "Home");
                }
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> DeleteBilingAddressAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();
            var responseBillingAddress = _addressService.DeleteBillingAddress(customer.CustomerId);

            if (responseBillingAddress != null && responseBillingAddress.CustomerId >= 0)
            {
                return RedirectToAction("Profile", "Home");
            }

            Response.StatusCode = 404;
            return View("NotFound");
        }
        #endregion

        #region ShoppingCart
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> ShoppingCartAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();

            var productList = _customerService.GetShoppingCartByCustomer(customer.CustomerId);
            
            return View(productList);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> CreateShoppingCartItemAsync(int id, Size size)
        {
            if (ModelState.IsValid)
            {
                WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();

                var product = _productService.GetProductById(id);

                if (customer != null && customer.CustomerId >= 0 && id != 0)
                {
                    var shoppingCartViewModel = new ShoppingCartViewModel()
                    {
                        ProductId = id,
                        CustomerId = customer.CustomerId,
                        Size = size,
                        Price = product.Price
                    };

                    var dto = _customerMapper.MapFromViewModelToDTO(shoppingCartViewModel);

                    var createdItem = _customerService.CreateShoppingCartItem(dto);

                    if (createdItem != null)
                    {
                        return RedirectToAction("ShoppingCart", "Home");
                    }
                }
            }

            Response.StatusCode = 404;
            return View("Error");
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public IActionResult DeleteShoppingCartItem(int id)
        {
            var responseShoppingCartItem = _customerService.DeleteShoppingCartItem(id);

            if (responseShoppingCartItem != null && responseShoppingCartItem.CustomerId >= 0)
            {
                return RedirectToAction("ShoppingCart", "Home");
            }

            Response.StatusCode = 404;
            return View("Error");
        }
        #endregion

        #region Order

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> OrderAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();

            var productList = _customerService.GetShoppingCartByCustomer(customer.CustomerId);

            return View(productList);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync()
        {
            WebsiteUser customer = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new ArgumentNullException();

            var productsList = _customerService.GetShoppingCartByCustomer(customer.CustomerId).ToList();

            if (productsList != null)
            {
                foreach (ShoppingCartItem item in productsList)
                {
                    var orderViewModel = new OrderViewModel()
                    {
                        AmountPaid = item.Price,
                        CustomerId = item.CustomerId,
                        OrderStatus = OrderStatus.Pending,
                        ProductId = item.ProductId
                    };

                    var dto = _customerMapper.MapFromViewModelToDTO(orderViewModel);

                    _customerService.CreateOrder(dto);
                }

                foreach (var item in productsList)
                {
                    _customerService.DeleteShoppingCartItem(item.ShoppingCartItemId);
                }

                return View("OrderCompleted", "Home");
            }

            return View(productsList);
        }

        #endregion
    }
}