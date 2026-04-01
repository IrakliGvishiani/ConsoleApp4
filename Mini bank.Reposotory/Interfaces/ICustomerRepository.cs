using Mini_bank.Reposotory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> addCustomer(Customer newCustomer);
        Customer GetCustomer(int id);
        List<Customer> GetAllCustomers();
        Task<int> UpdateCustomer(Customer updatedCustomer);
        Task<int> DeleteCustomer(int id);

    }
}
