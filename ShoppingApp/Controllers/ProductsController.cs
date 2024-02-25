using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingApp.Models;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = ProductsRepository.GetProducts();
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.ActionName = "edit";
            ViewBag.SubmitButtonName = "Save";
            ProductViewModel productViewModel = new ProductViewModel
            {
                Product = ProductsRepository.GetProductById(id) ?? new Product(),
                Categories = CategoriesRepository.GetCategories()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "edit";
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Add()
        {
            ViewBag.ActionName = "add";
            ViewBag.SubmitButtonName = "Submit";
            ProductViewModel productViewModel = new ProductViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "add";
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Delete(int productId)
        {
            ProductsRepository.DeleteProduct(productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial (int categoryId)
        {
            List<Product> products = ProductsRepository.GetProductsByCategoryId(categoryId);
            return PartialView("_Products", products);
        }
    }
}
