using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShoppingApp.Models
{
    public class TransactionsRepository
    {
        private static List<Transaction> transactions = new List<Transaction>();
        
        public static List<Transaction> GetByDayAndCashier(string chashierName, DateTime date)
        {
            if(string.IsNullOrWhiteSpace(chashierName))
                return transactions.Where(x=>x.TimeStamp.Date == date.Date).ToList();
            else return transactions.Where(x=>x.CashierName.ToLower().Contains(chashierName.ToLower()) &&
            x.TimeStamp.Date == date.Date).ToList();
        }

        public static List<Transaction> Search(string  chashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(chashierName))
                return transactions.Where(x=>x.TimeStamp >=  startDate.Date && x.TimeStamp <= endDate.AddDays(1).Date).ToList();
            else return transactions.Where(x => x.CashierName.ToLower().Contains(chashierName.ToLower()) &&
            x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date).ToList();
        }

        public static void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            };

            if (transactions != null && transactions.Count > 0)
            {
                var maxId = transactions.Max(x => x.TransactionId);
                transaction.TransactionId = maxId + 1;
            }
            else
            {
                transaction.TransactionId = 1;
            }

            transactions?.Add(transaction);
        }
    }
}
