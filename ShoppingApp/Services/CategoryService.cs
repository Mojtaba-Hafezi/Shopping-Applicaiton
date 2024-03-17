using ShoppingApp.Data;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;

namespace ShoppingApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;
        public CategoryService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            Category? categoryToRemove = _dbContext.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
            if(categoryToRemove != null)
            {
                _dbContext.Categories.Remove(categoryToRemove);
                _dbContext.SaveChanges();
            }
            
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = _dbContext.Categories.ToList();
            if(categories.Count > 0)
            {
                return categories;
            }
            return new List<Category>();
        }

        public Category? GetCategoryById(int id)
        {
            return _dbContext.Categories.Where(c => c.CategoryId==id).FirstOrDefault();
        }

        public void UpdateCategory(Category category)
        {
            Category? categoryToUpdate = _dbContext.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();
            if( categoryToUpdate != null )
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
                _dbContext.SaveChanges();
            }
        }
    }
}
