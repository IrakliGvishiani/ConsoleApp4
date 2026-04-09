

using Mini_bank.Reposotory.Attributes;

namespace MiniBank.Service.Dtos.Account
{
    public class CreateAccountDto
    {
        [MyRequired] 
        public decimal Balance { get; set; }

        [MyRequired]
        [MyCurrency]
         public string Currency {  get; set; }

        [MyRequired]
        public int CustomerId { get; set; }
        public string? Name { get; set; }
    }
}
