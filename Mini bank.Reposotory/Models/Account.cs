
namespace Mini_bank.Reposotory.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }

        public int CustomerID { get; set; }
        public string? name { get; set; }
    }
}
