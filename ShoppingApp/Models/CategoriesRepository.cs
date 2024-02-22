namespace ShoppingApp.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category{CategoryId = 1, Name="Beverage", Description="Beverage"},
            new Category{CategoryId = 2, Name="Bakery", Description="Bakery"},
            new Category{CategoryId = 3, Name="Meat", Description="Meat"}
        };

        public static void AddCategory(Category category)
        {
            int maxId = 0;
            if(_categories.Count() > 0)
            {
                maxId = _categories.Max(x => x.CategoryId);
            }
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories()
        {
            return _categories;
        }

        public static Category? GetCategoryById(int id)
        {
            Category? category = _categories.FirstOrDefault(x=>x.CategoryId == id);
            if(category != null)
            {
                return category;
            }

            return null;
        }

        public static void UpdateCategory(int categoryId,  Category category)
        {
            Category? categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if ( categoryToUpdate != null )
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            Category? category = _categories.FirstOrDefault( x => x.CategoryId == categoryId);
            if( category != null )
            {
                _categories.Remove(category);
            }
        }
    }
}
