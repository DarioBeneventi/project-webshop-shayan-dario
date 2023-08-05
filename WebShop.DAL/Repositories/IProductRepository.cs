using System;
using System.Collections.Generic;
using System.Text;
using WebShop.BOL.Entities;

namespace WebShop.DAL.Repositories
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        Product CreateProduct(Product product);
        Product EditProduct(Product product);
        Product DeleteProduct(int id);
        Review GetReviewById(int id);
        IEnumerable<Review> GetAllReviews();
        Review CreateReview(Review review);
        Review EditReview(Review review);
        Review DeleteReview(int id);
    }
}
