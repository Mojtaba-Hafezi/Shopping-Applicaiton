using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Controllers;

public class SalesController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly ITransactionService _transactionService;
    public SalesController(ICategoryService categoryService, IProductService productService, ITransactionService transactionService)
    {
        _categoryService = categoryService;
        _productService = productService;
        _transactionService = transactionService;

    }
    public IActionResult Index()
    {
        SalesViewModel salesViewModel = new SalesViewModel
        {
            Categories = _categoryService.GetCategories()
        };
        return View(salesViewModel);
    }

    public IActionResult SellProductPartial(int productId)
    {
        Product product = _productService.GetProductById(productId) ?? new Product();
        return PartialView("_SellProduct", product);
    }

    public IActionResult Sell(SalesViewModel salesViewModel)
    {
        var product = _productService.GetProductById(salesViewModel.SelectedProductId);
        
        if (product != null && salesViewModel.QuantityToSell>0 && salesViewModel.QuantityToSell<= product.Quantity )
        {
            _transactionService.Add(
                "Cashier1",
                salesViewModel.SelectedProductId,
                product.Name,
                product.Price.HasValue ? product.Price.Value: 0,
                product.Quantity.HasValue ? product.Quantity.Value:0,
                salesViewModel.QuantityToSell
                ) ;

            product.Quantity -= salesViewModel.QuantityToSell;
            _productService.UpdateProduct(product);
        }
        
        product = _productService.GetProductById(salesViewModel.SelectedProductId);
        salesViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
        salesViewModel.Categories = _categoryService.GetCategories();
        return View(nameof(Index),salesViewModel);
    }
}
