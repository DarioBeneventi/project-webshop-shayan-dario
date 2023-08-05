using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebShop.BOL.Entities;
using WebShop.DAL.Repositories;
using WebShop.ViewModels.Customers;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<WebsiteUser> _userManager;
        private readonly SignInManager<WebsiteUser> _signInManager;
        private readonly ICustomerRepository _customerRepository;

        public AccountController(
            UserManager<WebsiteUser> userManager,
            SignInManager<WebsiteUser> signInManager,
            ICustomerRepository customerRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerRepository = customerRepository;
        }

        #region Register
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    CreatedDate = DateTime.UtcNow,
                };

                var customerToegevoegd = _customerRepository.CreateCustomer(customer);

                var websiteUser = new WebsiteUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    CustomerId = customerToegevoegd.CustomerId,
                    CreatedDate = DateTime.UtcNow
                };

                var identityResult = await _userManager.CreateAsync(websiteUser, model.Password);

                if (identityResult.Succeeded)
                {
                    if (_userManager.AddToRoleAsync(websiteUser, "Customer").Result.Succeeded)
                    {
                        await _signInManager.SignInAsync(websiteUser, false);
                        return RedirectToAction("Index", "Home");
                    }
                }

                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        #endregion

        #region Login

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                
                if (user != null)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false).ConfigureAwait(false);

                    if (signInResult.Succeeded)
                    {
                        if (user != null)
                        {
                            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                            {
                                return LocalRedirect(returnUrl);
                            }

                            return RedirectToAction("Index", "Home");
                        }
                    }

                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
            }

            return View(model);
        }
        #endregion

        #region Logout

        [HttpPost]
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion        

        #region Other methods

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUseAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }

            return Json($"Email {email} is already in use.");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion
    }
}
