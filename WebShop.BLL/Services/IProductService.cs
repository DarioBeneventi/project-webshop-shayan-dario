using System.Collections.Generic;
using WebShop.BLL.DTOs.Products;
using WebShop.BOL.Entities;

namespace WebShop.BLL.Services
{
    public interface IProductService
    {
        ProductDTO GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductsByCategory(string category);
        Product CreateProduct(ProductCreateDTO model);
        Product EditProduct(ProductEditDTO model);
        Product DeleteProduct(int id);
        IEnumerable<Review> GetAllReviewsByCustomer(int id);
        IEnumerable<Review> GetAllReviewsByProduct(int id);
        Review CreateReview(ReviewDTO model);
        Review DeleteMyReview(int reviewId);
    }
}
