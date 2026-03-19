
using Mini_bank.Reposotory.Attributes;

namespace Mini_bank.Reposotory.Models
{
    public class Operation
    {
        [MyRequired]
        [IsPositiveNumber]
        public int Id { get; set; }
    
        public OperationType OperationType { get; set; }

        [MyRequired]
        public int AccountId { get; set; }
        [MyRequired]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
