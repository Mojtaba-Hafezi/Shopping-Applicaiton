using ShoppingApp.Models;

namespace ShoppingApp.Interfaces;

public interface ICategoryService
{
    void AddCategory(Category category);
    List<Category> GetCategories();
    Category? GetCategoryById(int id);
    void UpdateCategory(Category category);
    void DeleteCategory(int categoryId);
}
