using Mini_bank.Reposotory.Models;
using Mini_bank.Reposotory;
using Mini_bank.Reposotory.Models;
using Mini_bank.Reposotory.Attributes;
namespace MiniBankUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerRepository customerRepository = new CustomerRepository();

            var customer1 = new Customer
            {
                Id = 20,
                Name = "Giorgi gobetylewia",
                Email = "idiotarseba@Otomotors.ge",
                IdentityNumber = "12345678911",
                PhoneNumber = "555123422",
                CustomerType = CustomerType.Legal
            };
            Validator.Validate(customer1);

            var result = customerRepository.addCustomer(customer1);


            var updatedCustomer = new Customer
            {
                Id = 20,
                Name = "John Doe Updated",
                Email = "updatedd@gmail.com",
                IdentityNumber = "12345678911",
                PhoneNumber = "+995 555 12 34 22",
                CustomerType = CustomerType.Physical
            };

            //customerRepository.UpdateCustomer(updatedCustomer);
            //customerRepository.DeleteCustomer(20);


            AccountRepository accountRepository = new AccountRepository();
            var account1 = new Account
            {
                Id = 10,
                Iban = "GE123456789",
                Currency = "USD",
                Balance = 1000,
                CustomerID = 5,
                name = "idk"
            };

            //    Validator.Validate(account1);
            //var result = accountRepository.addAccount(account1);

            //var updatedAcc = new Account
            //{
            //    Id = 30,
            //    Iban = "GE12345678912345",
            //    Currency = "USD",
            //    Balance = 67.00m,
            //    CustomerID = 5,
            //    name = null
            //};

            //accountRepository.UpdateAccount(updatedAcc);

            //accountRepository.DeleteAccount(30);

            //OperationRepository operationRepository = new OperationRepository();

            //var gurgena = accountRepository.getAccountById(2);

            //var iakob = accountRepository.getAccountById(1);

            //var user = accountRepository.getAccountById(6);

            //operationRepository.Transfer(gurgena, iakob, 200);
            //operationRepository.Debit(user, 3000);
            //operationRepository.Credit(user, 1000);

        }
    }
}
