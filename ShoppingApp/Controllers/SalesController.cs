using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Models;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            SalesViewModel salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(salesViewModel);
        }

        public IActionResult SellProductPartial(int productId)
        {
            Product product = ProductsRepository.GetProductById(productId) ?? new Product();
            return PartialView("_SellProduct", product);
        }

        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
            if (ModelState.IsValid)
            {
                //Sell the product
                if (product != null)
                {
                    TransactionsRepository.Add(
                        "Cashier1",
                        salesViewModel.SelectedProductId,
                        product.Name,
                        product.Price.HasValue ? product.Price.Value: 0,
                        product.Quantity.HasValue ? product.Quantity.Value:0,
                        salesViewModel.QuantityToSell
                        ) ;

                    product.Quantity -= salesViewModel.QuantityToSell;
                    ProductsRepository.UpdateProduct(salesViewModel.SelectedProductId, product);
                }
            }
            product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
            salesViewModel.Categories = CategoriesRepository.GetCategories();
            return View(nameof(Index),salesViewModel);
        }
    }
}
