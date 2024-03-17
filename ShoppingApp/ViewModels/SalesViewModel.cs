using ShoppingApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ShoppingApp.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public int SelectedProductId { get; set; }

        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue)]
        public int QuantityToSell { get; set; }
    }
}