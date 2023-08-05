using EmpManagement.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebShop.BLL.Mappers.Address;
using WebShop.BLL.Mappers.CustomerMapper;
using WebShop.BLL.Mappers.ProductMapper;
using WebShop.BLL.Services;
using WebShop.BOL.Entities;
using WebShop.BOL.Enums;
using WebShop.DAL.Repositories;

namespace WebShop.BLL.Extensions
{
    public static class StartupExtension
    {
        public static void ConfigureBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(
                options =>
                    options.UseSqlServer(configuration.GetConnectionString("WebShopDBConnection"))
            );

            services.AddIdentity<WebsiteUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<AppDbContext>();

            // Repo DAL
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            // Mappers BLL
            services.AddScoped<ICustomerMapper, CustomerMapper>();
            services.AddScoped<IProductMapper, ProductMapper>();
            services.AddScoped<IAddressMapper, AddressMapper>();

            // Service BLL
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAddressService, AddressService>();
        }

        public static void SeedData(UserManager<WebsiteUser> userManager,RoleManager<IdentityRole> roleManager, IAddressRepository addressRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager, addressRepository, customerRepository, productRepository);
        }

        public static void SeedUsers(UserManager<WebsiteUser> userManager, IAddressRepository addressRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            if (userManager.FindByNameAsync("SiteManager").Result == null)
            {
                WebsiteUser siteManager = new WebsiteUser
                {
                    UserName = "SiteManager",
                    Email = "site_manager@test.com",
                    CreatedDate = DateTime.UtcNow
                };

                Product product1 = new Product
                {
                    Brand = "Nike",
                    Category = Category.Hoodies,
                    CreatedDate = DateTime.UtcNow,
                    Description = "New Nike hoodie made of 100% cotton.",
                    Name = "Grey Hoodie",
                    Price = 59,
                    PhotoPath = $"nike_hoodie.jpg"
                };

                Product product2 = new Product
                {
                    Brand = "Adidas",
                    Category = Category.Jackets,
                    CreatedDate = DateTime.UtcNow,
                    Description = "Adidas jacket for cold weather.",
                    Name = "Black Jacket",
                    Price = 149,
                    PhotoPath = $"adidas_jacket.jpg"
                };

                Product product3 = new Product
                {
                    Brand = "Adidas",
                    Category = Category.Pants,
                    CreatedDate = DateTime.UtcNow,
                    Description = "Adidas pants for when you want to sport.",
                    Name = "Black pants",
                    Price = 79,
                    PhotoPath = $"adidas_pants.jpg"
                };

                Product product4 = new Product
                {
                    Brand = "Nike",
                    Category = Category.Shirts,
                    CreatedDate = DateTime.UtcNow,
                    Description = "Nike shirt for when it's hot outside.",
                    Name = "Blue shirt",
                    Price = 29,
                    PhotoPath = $"nike_shirt.jpg"
                };

                Product product5 = new Product
                {
                    Brand = "Adidas",
                    Category = Category.Hoodies,
                    CreatedDate = DateTime.UtcNow,
                    Description = "Adidas hoodie when you want to look good.",
                    Name = "Blue hoodie",
                    Price = 59,
                    PhotoPath = $"adidas_hoodie.jpg"
                };

                productRepository.CreateProduct(product1);
                productRepository.CreateProduct(product2);
                productRepository.CreateProduct(product3);
                productRepository.CreateProduct(product4);
                productRepository.CreateProduct(product5);

                IdentityResult result = userManager.CreateAsync(siteManager, "Test12345$").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(siteManager,"SiteManager").Wait();
                }
            }

            if (userManager.FindByNameAsync("Customer").Result == null)
            {
                WebsiteUser customer = new WebsiteUser
                {
                    UserName = "Customer",
                    Email = "customer@test.com",
                    CreatedDate = DateTime.UtcNow,
                    CustomerId = 1

                };

                Customer customer1 = new Customer
                {
                    Email = "customer@test.com",
                    FirstName = "CustomerFirstName",
                    LastName = "CustomerLastName",
                    CreatedDate = DateTime.UtcNow
                };

                DeliveryAddress deliveryAddress = new DeliveryAddress
                {
                    City = "Brussels",
                    Country = "Belgium",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    CustomerId = 1,
                    NameOfDeliveryAddress = "My address",
                    Street = "Bergenstraat 10",
                    ZipCode = 1000
                };

                BillingAddress billingAddress = new BillingAddress
                {
                    City = "Brussels",
                    Country = "Belgium",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    CustomerId = 1,
                    NameOfBillingAddress = "My address",
                    Street = "Bergenstraat 10",
                    ZipCode = 1000
                };

                IdentityResult result = userManager.CreateAsync(customer, "Test12345$").Result;
                customerRepository.CreateCustomer(customer1);
                addressRepository.AddBillingAddress(billingAddress);
                addressRepository.AddDeliveryAddress(deliveryAddress);

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(customer, "Customer").Wait();
                }
            }

            if (userManager.FindByNameAsync("Reviewer").Result == null)
            {
                WebsiteUser reviewer = new WebsiteUser
                {
                    UserName = "Reviewer",
                    Email = "reviewer@test.com",
                    CreatedDate = DateTime.UtcNow,
                    CustomerId = 2
                };

                Customer reviewer1 = new Customer
                {
                    Email = "reviewer@test.com",
                    FirstName = "ReviewerFirstName",
                    LastName = "ReviewerLastName",
                    CreatedDate = DateTime.UtcNow
                };

                IdentityResult result = userManager.CreateAsync(reviewer, "Test12345$").Result;
                customerRepository.CreateCustomer(reviewer1);

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(reviewer, "Reviewer").Wait();
                }

                Review review = new Review
                {
                    CreatedDate = DateTime.UtcNow,
                    CustomerId = 2,
                    ProductId = 1,
                    Rating = 4,
                    TitleReview = "Good hoodie",
                    ReviewText = "I was very surprised by the quality of the product. I would recommend it to anyone."
                };

                productRepository.CreateReview(review);
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("SiteManager").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "SiteManager"
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Customer").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Customer"
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Reviewer").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Reviewer"
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
