using ShoppingApp.Data;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;

namespace ShoppingApp.Services;

public class TransactionService : ITransactionService
{
    private readonly AppDbContext _appDbContext;

    public TransactionService(AppDbContext appDbContext) => _appDbContext = appDbContext;
    

    public void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
    {
        Transaction transaction = new Transaction
        {
            ProductId = productId,
            ProductName = productName,
            TimeStamp = DateTime.Now,
            Price = price,
            BeforeQty = beforeQty,
            SoldQty = soldQty,
            CashierName = cashierName
        };
        _appDbContext.Transactions.Add(transaction);
        _appDbContext.SaveChanges();
    }

    public List<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(cashierName.ToLower()))
        {
            return _appDbContext.Transactions.Where(t=>t.TimeStamp.Date ==  date).ToList();
        }
        else
        {
            return _appDbContext.Transactions.Where(t => t.CashierName.ToLower().Contains(cashierName.ToLower()) && t.TimeStamp.Date == date).ToList();
        }
    }

    public List<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
        {
            return _appDbContext.Transactions.Where(t=>t.TimeStamp.Date >= startDate.Date && t.TimeStamp<=endDate.AddDays(1).Date).ToList();
        }
        else
        {
            return _appDbContext.Transactions.Where(t=>t.CashierName.ToLower().Contains(cashierName.ToLower()) && t.TimeStamp.Date >= startDate.Date && t.TimeStamp <= endDate.AddDays(1).Date).ToList();
        }
    }
}
