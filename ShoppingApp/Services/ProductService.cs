using Microsoft.EntityFrameworkCore.Query.Internal;
using ShoppingApp.Data;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;

namespace ShoppingApp.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICategoryService _categoryService;

        public ProductService(AppDbContext appDbContext, ICategoryService categoryService)
        {
            _appDbContext = appDbContext;
            _categoryService = categoryService;

        }
        public void AddProduct(Product product)
        {
            Category? productCategory = _categoryService.GetCategoryById(product.CategoryId.HasValue?product.CategoryId.Value:0);
            if(productCategory != null) 
            {
                _appDbContext.Products.Add(product);
                _appDbContext.SaveChanges();
            }
            else
            {
                throw new Exception("The product category was null");
            }
        }

        public void DeleteProduct(int productId)
        {
            Product? productToRemove = _appDbContext.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            if (productToRemove != null)
            {
                _appDbContext.Products.Remove(productToRemove);
                _appDbContext.SaveChanges();
            }
        }

        public Product? GetProductById(int productId)
        {
            return _appDbContext.Products.Where(p => p.ProductId == productId).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            List<Product> products = _appDbContext.Products.ToList();
            if(products.Count > 0)
            {
                foreach(Product product in products)
                {
                    product.Category = _categoryService.GetCategoryById(product.CategoryId.HasValue?product.CategoryId.Value:0);
                }
                return products;
            }
            return new List<Product>();
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            List<Product> products = _appDbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
            if( products.Count > 0)
            {
                return products;
            }
            return new List<Product>();
        }

        public void UpdateProduct(Product product)
        {
            Category? productCategory = _categoryService.GetCategoryById(product.CategoryId.HasValue ? product.CategoryId.Value : 0);
            if (productCategory != null)
            {
                Product? productToUpdate = _appDbContext.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
                if (productToUpdate != null)
                {
                    productToUpdate.Name = product.Name;
                    productToUpdate.Price = product.Price;
                    productToUpdate.Quantity = product.Quantity;
                    productToUpdate.Category = product.Category;
                    productToUpdate.CategoryId = product.CategoryId;
                    _appDbContext.SaveChanges();
                }
            }
            else
            {
                throw new Exception("The product category was null");
            }
        }
    }
}
