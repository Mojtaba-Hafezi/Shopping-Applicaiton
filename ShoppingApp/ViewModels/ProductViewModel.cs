using ShoppingApp.Models;

namespace ShoppingApp.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
