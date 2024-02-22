namespace ShoppingApp.Models
{
    public class ProductsRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
            new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
            new Product { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
            new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
        };

        public static void AddProduct(Product product)
        {
            int maxId = 0;
            if (_products.Count() > 0)
            {
                maxId = _products.Max(x => x.ProductId);
            }
            product.ProductId = maxId + 1;
            _products.Add(product);
        }

        public static List<Product> GetProducts()
        {
            foreach (Product item in _products)
                {
                    item.Category = CategoriesRepository.GetCategories().Where(category => category.CategoryId == item.CategoryId).FirstOrDefault();
                }
                return _products;
        }

        public static Product? GetProductById(int productId)
        {
            Product? product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public static void UpdateProduct(int productId, Product product)
        {
            if (productId != product.ProductId) return;

            var productToUpdate = _products.FirstOrDefault(x => x.ProductId == productId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Price = product.Price;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Category = product.Category;
            }
        }

        public static void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
