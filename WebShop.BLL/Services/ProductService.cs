using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebShop.BLL.DTOs.Products;
using WebShop.BLL.Mappers.ProductMapper;
using WebShop.BOL.Entities;
using WebShop.DAL.Repositories;

namespace WebShop.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductMapper _productMapper;

        public ProductService(
            IProductRepository productRepository,
            IWebHostEnvironment webHostEnvironment,
            IProductMapper productMapper)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
            _productMapper = productMapper;
        }

        #region Product
        public ProductDTO GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);

            var dto = _productMapper.MapFromEntityToDTO(product);

            return dto;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var productList = _productRepository.GetAllProducts();
            return productList;
        }

        public IEnumerable<Product> GetAllProductsByCategory(string category)
        {
            var productList = _productRepository.GetAllProducts();

            var productByCategoryList = productList.Where(e => e.Category.ToString() == category);

            return productByCategoryList;
        }

        public Product CreateProduct(ProductCreateDTO model)
        {
            if (model.Photo != null)
            {
                model.PhotoPath = ProcessUploadFile(model);
            }

            var oldProduct = _productMapper.MapFromDTOToEntity(model);

            var newProduct = _productRepository.CreateProduct(oldProduct);

            return newProduct;
        }

        public Product EditProduct(ProductEditDTO model)
        {
            if (model.Photo != null)
            {
                var photoExist = DeleteImage(model.ExistingPhotoPath);

                if (!photoExist)
                {
                    model.PhotoPath = ProcessUploadFile(model);
                }
            }

            var product = _productMapper.MapFromDTOToEntity(model);

            var response = _productRepository.EditProduct(product);

            return response;
        }

        public Product DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);

            if (product != null && product.ProductId >= 0)
            {
                var photoExist = DeleteImage(product.PhotoPath);

                if (!photoExist)
                {
                    var response = _productRepository.DeleteProduct(id);

                    return response;
                }
            }

            return null;
        }
        #endregion

        #region Review
        public IEnumerable<Review> GetAllReviewsByCustomer(int id)
        {
            var reviewsList = _productRepository.GetAllReviews();
            var reviewsListByCustomer = reviewsList.Where(l => l.CustomerId == id);

            return reviewsListByCustomer;
        }

        public IEnumerable<Review> GetAllReviewsByProduct(int id)
        {
            var reviewsList = _productRepository.GetAllReviews();
            var reviewsListByCustomer = reviewsList.Where(l => l.ProductId == id);

            return reviewsListByCustomer;
        }

        public Review CreateReview(ReviewDTO model)
        {
            var oldReview = _productMapper.MapFromDTOToEntity(model);

            var newReview = _productRepository.CreateReview(oldReview);

            return newReview;
        }

        public Review DeleteMyReview(int reviewId)
        {

            var review = _productRepository.GetReviewById(reviewId);

            if (review != null && review.CustomerId >= 0)
            {
                var response = _productRepository.DeleteReview(reviewId);

                return response;

            }

            return null;
        }
        #endregion

        #region Extra methods
        private bool DeleteImage(string photoPath)
        {
            if (photoPath != null)
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", photoPath);
                System.IO.File.Delete(filePath);

                return System.IO.File.Exists(filePath);
            }

            return false;
        }

        private string ProcessUploadFile(ProductCreateDTO model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.Photo.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
        #endregion
    }
}