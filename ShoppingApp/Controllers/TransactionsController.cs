using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;
using ShoppingApp.ViewModels;

namespace ShoppingApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            TransactionViewModel transactionsViewModel = new TransactionViewModel();
            return View(transactionsViewModel);
        }

        public IActionResult Search(TransactionViewModel transactionViewModel)
        {
            transactionViewModel.Transactions = _transactionService.Search(transactionViewModel.CashierName ?? string.Empty, transactionViewModel.StartDate, transactionViewModel.EndDate);

            return View("Index",transactionViewModel);
        }
    }
}
