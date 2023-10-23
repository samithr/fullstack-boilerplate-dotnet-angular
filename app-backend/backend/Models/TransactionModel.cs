
namespace backend.Models
{
    public class TransactionModel
    {
        public string AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}