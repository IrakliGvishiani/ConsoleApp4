

namespace MiniBank.Service.Dtos.Account
{
    public class GetAccountDto
    {

                private string _currency;

        
        public int Id { get; set; }


        public string Iban { get; set; }

        public string Currency {
            get => _currency;
            set => _currency = value.ToUpper();
        }



        public decimal Balance { get; set; }



        public override string ToString() => $" IBAN: {Iban}, Currency: {Currency}, Balance: {Balance}";




    }
}
