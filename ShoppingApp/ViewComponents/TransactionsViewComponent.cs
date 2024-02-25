using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Models;
namespace ShoppingApp.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transaction = TransactionsRepository.GetByDayAndCashier("Cashier1", DateTime.Now);
            return  View (transaction);
        }
    }
}
