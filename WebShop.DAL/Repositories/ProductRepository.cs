using EmpManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebShop.BOL.Entities;

namespace WebShop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(AppDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region Product

        public Product GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var listProducts = _context.Products;
            return listProducts;
        }

        public Product CreateProduct(Product product)
        {
            if (product != null)
            {
                var newProduct = _context.Products.Add(product);

                if (newProduct != null && newProduct.State == EntityState.Added)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return newProduct.Entity;
                    }
                }
            }
            else
            {
                _logger.LogWarning($"Product is empty, couldn't be added.");
            }

            return null;
        }

        public Product EditProduct(Product product)
        {
            var updatedProduct = _context.Products.Update(product);

            if (updatedProduct != null && updatedProduct.State == EntityState.Modified)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return updatedProduct.Entity;
                }
            }

            return null;
        }

        public Product DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                var deletedProduct = _context.Products.Remove(product);

                if (deletedProduct != null && deletedProduct.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedProduct.Entity;
                    }
                }
            }

            return null;
        }
        #endregion

        #region Review

        public Review GetReviewById(int id)
        {
            var review = _context.Reviews.Find(id);
            return review;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            var listReviews = _context.Reviews;
            return listReviews;
        }

        public Review CreateReview(Review review)
        {
            if (review != null)
            {
                var newReview = _context.Reviews.Add(review);

                if (newReview != null && newReview.State == EntityState.Added)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return newReview.Entity;
                    }
                }
            }
            else
            {
                _logger.LogWarning($"Product is empty, couldn't be added.");
            }

            return null;
        }

        public Review EditReview(Review review)
        {
            var updatedReview = _context.Reviews.Update(review);

            if (updatedReview != null && updatedReview.State == EntityState.Modified)
            {
                var affectedRows = _context.SaveChanges();

                if (affectedRows > 0)
                {
                    return updatedReview.Entity;
                }
            }

            return null;
        }

        public Review DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);

            if (review != null)
            {
                var deletedReview = _context.Reviews.Remove(review);

                if (deletedReview != null && deletedReview.State == EntityState.Deleted)
                {
                    var affectedRows = _context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        return deletedReview.Entity;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
