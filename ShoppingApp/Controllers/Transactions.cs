using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Models;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Controllers
{
    public class Transactions : Controller
    {
        public IActionResult Index(TransactionViewModel transactionViewModel)
        {
            return View(transactionViewModel);
        }

        public IActionResult Search(TransactionViewModel transactionViewModel)
        {
            transactionViewModel.Transactions = TransactionsRepository.Search(transactionViewModel.CashierName, transactionViewModel.StartDate, transactionViewModel.EndDate);

            return RedirectToAction(nameof(Index),transactionViewModel);
        }
    }
}
