using Mini_bank.Reposotory;
using Mini_bank.Reposotory.Attributes;
using Mini_bank.Reposotory.Interfaces;
using Mini_bank.Reposotory.Models;
using Mini_bank.Reposotory.Models;
using MiniBank.Service;
using MiniBank.Service.Dtos.Account;
using MiniBank.Service.Dtos.Customer;
using System.Threading.Tasks;
namespace MiniBankUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //CustomerRepository customerRepository = new CustomerRepository();

            var customer1 = new Customer
            {
                Id = 20,
                Name = "Giorgi gobetylewia",
                Email = "idiotarseba@Otomotors.ge",
                IdentityNumber = "12345678911",
                PhoneNumber = "555123422",
                CustomerType = CustomerType.Legal
            };

            //var result = customerRepository.addCustomer(customer1);


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


            //AccountRepository accountRepository = new AccountRepository();
            var accountRepository = await AccountRepository.CreateAsync(@"C:\Users\user\source\repos\ConsoleApp4\Data\Accounts.json");
            var accountService = new AccountService(accountRepository);

            var account1 = new CreateAccountDto
            {
                Currency = "USD",
                CustomerId = 5,
                Name = null
            };

            Validator.Validate(account1);
            var result =  accountService.DeleteAccount(30);

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
            //AccountRepository accountRepository1 = new AccountRepository();
            //var accountRepository1 = await AccountRepository.CreateAsync(@"C:\Users\user\source\repos\ConsoleApp4\Data\Accounts.json");


            //var user =  accountRepository1.getAccountById(1);

            //var operationRepository = await OperationRepository.CreateAsync(@"C:\Users\user\source\repos\ConsoleApp4\Data\Operations.xml", accountRepository1);
            var customerRepository = await CustomerRepository.CreateAsync(@"C:\Users\user\source\repos\ConsoleApp4\Data\Customers.csv");

            //await operationRepository.Credit(user, 1000);


            var customerService = new CustomerService(customerRepository);

            var createDto = new CreateCustomerDto
            {
                
                Name = "Irakli",
                IdentityNumber = "12345678911",
                PhoneNumber = "555123456",
                Email = "irakli@gmail.com"
            };

            var updatedDto = new UpdateCustomerDto
            {
                Id = 12,
                Name = "jajo",
                IdentityNumber = "123456789",
                PhoneNumber = "555123456",
                Email = "irakli@gmail.com"
            };
            //Validator.Validate(customer1);


            //var addResult = await customerService.AddCustomer(createDto);

            //CustomerService getCustomers = new CustomerService(customerRepository);

            //    var customers = await getCustomers.GetAllCustomers();

            //    var customerById = await getCustomers.GetCustomerById(12);
        }
    }
}
