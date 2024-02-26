using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Models;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            TransactionViewModel transactionsViewModel = new TransactionViewModel();
            return View(transactionsViewModel);
        }

        public IActionResult Search(TransactionViewModel transactionViewModel)
        {
            transactionViewModel.Transactions = TransactionsRepository.Search(transactionViewModel.CashierName ?? string.Empty, transactionViewModel.StartDate, transactionViewModel.EndDate);

            return View("Index",transactionViewModel);
        }
    }
}
