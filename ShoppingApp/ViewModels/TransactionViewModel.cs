using ShoppingApp.Models;

namespace ShoppingApp.ViewModels
{
    public class TransactionViewModel
    {
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public string CashierName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
