
namespace Mini_bank.Reposotory.Models
{
    public class Operation
    {
        public int Id { get; set; }
    
        public OperationType OperationType { get; set; }

        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
