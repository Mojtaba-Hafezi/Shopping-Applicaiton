using ShoppingApp.Models;

namespace ShoppingApp.Interfaces
{
    public interface ITransactionService
    {
        List<Transaction> GetByDayAndCashier(string cashierName, DateTime date);
        List<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
        void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty);
    }
}
