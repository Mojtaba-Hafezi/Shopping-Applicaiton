using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;

namespace ShoppingApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            List<Category> categories= _categoryService.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.ActionName = "edit";
            ViewBag.SubmitButtonName = "Save";
            Category? category = _categoryService.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "edit";
            return View(category);
        }

        public IActionResult Add()
        {
            ViewBag.ActionName = "add";
            ViewBag.SubmitButtonName = "Submit";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if(ModelState.IsValid)
            {
                _categoryService.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "add";
            return View(category);
        }

        
        public IActionResult Delete(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            return RedirectToAction(nameof (Index));
        }
    }
}
