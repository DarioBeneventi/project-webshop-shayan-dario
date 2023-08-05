using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebShop.BLL.Extensions;
using WebShop.BOL.Entities;
using WebShop.DAL.Repositories;
using WebShop.Mappers.AddressMapper;
using WebShop.Mappers.CustomerMapper;
using WebShop.Mappers.ProductMapper;

namespace WebShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureBLL(Configuration);

            services.AddControllersWithViews().AddXmlSerializerFormatters();

            //Mapper PLL
            services.AddScoped<ICustomerMapper, CustomerMapper>();
            services.AddScoped<IProductMapper, ProductMapper>();
            services.AddScoped<IAddressMapper, AddressMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<WebsiteUser> userManager, RoleManager<IdentityRole> roleManager, ICustomerRepository customerRepository, IProductRepository productRepository, IAddressRepository addressRepository)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            StartupExtension.SeedData(userManager, roleManager, addressRepository, customerRepository, productRepository);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}