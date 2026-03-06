using Mini_bank.Reposotory.Models;

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
                Name = "John Doe",
                Email = "john@gmail.com",
                IdentityNumber = "12345678911",
                PhoneNumber = "555123422",
                CustomerType = 0
            };
            //var result = customerRepository.addCustomer(customer1);


            var updatedCustomer = new Customer
            {
                Id = 20,
                Name = "John Doe Updated",
                Email = "updatedd@gmail.com",
                IdentityNumber = "12345678911",
                PhoneNumber = "555123422",
                CustomerType = 0
            };

            //customerRepository.UpdateCustomer(updatedCustomer);
            customerRepository.DeleteCustomer(20);
        }
    }
}
