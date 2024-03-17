using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ShoppingApp.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public double Price { get; set; }
        public int BeforeQty { get; set; }
        public int SoldQty { get; set; }
        public string CashierName { get; set; } = "";
    }
}
