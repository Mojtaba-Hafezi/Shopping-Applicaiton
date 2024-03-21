using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;
using ShoppingApp.Services;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Controllers;

public class ProductsController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    public ProductsController(ICategoryService categoryService, IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;

    }
    public IActionResult Index()
    {
        List<Product> products = _productService.GetProducts();
        return View(products);
    }

    public IActionResult Edit(int id)
    {
        ViewBag.ActionName = "edit";
        ViewBag.SubmitButtonName = "Save";
        ProductViewModel productViewModel = new ProductViewModel
        {
            Product = _productService.GetProductById(id) ?? new Product(),
            Categories = _categoryService.GetCategories()
        };

        return View(productViewModel);
    }

    [HttpPost]
    public IActionResult Edit(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            _productService.UpdateProduct(productViewModel.Product);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.ActionName = "edit";
        productViewModel.Categories = _categoryService.GetCategories();
        return View(productViewModel);
    }

    public IActionResult Add()
    {
        ViewBag.ActionName = "add";
        ViewBag.SubmitButtonName = "Submit";
        ProductViewModel productViewModel = new ProductViewModel
        {
            Categories = _categoryService.GetCategories()
        };
        return View(productViewModel);
    }

    [HttpPost]
    public IActionResult Add(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            _productService.AddProduct(productViewModel.Product);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.ActionName = "add";
        productViewModel.Categories = _categoryService.GetCategories();
        return View(productViewModel);
    }

    public IActionResult Delete(int productId)
    {
        _productService.DeleteProduct(productId);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult ProductsByCategoryPartial (int categoryId)
    {
        List<Product> products = _productService.GetProductsByCategoryId(categoryId);
        return PartialView("_Products", products);
    }
}
