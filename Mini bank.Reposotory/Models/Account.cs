
using Mini_bank.Reposotory.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Mini_bank.Reposotory.Models
{
    public class Account
    {
        private string _currency;
        [Required] [IsPositiveNumber]
        
        public int Id { get; set; }

        [Required]
        [MyIban]
        public string Iban { get; set; }

        [Required]
        [MyCurrency]
        public string Currency {
            get => _currency;
            set => _currency = value.ToUpper();
        }


        [Required]
        public decimal Balance { get; set; }


        [Required]
        public int CustomerId { get; set; }


        [Required]
        public string? Name { get; set; }
    }
}
