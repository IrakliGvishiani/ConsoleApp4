using Mini_bank.Reposotory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Interfaces
{
    public interface ICustomerRepository
    {
        int addCustomer(Customer newCustomer);
        Customer GetCustomer(int id);
        List<Customer> GetAllCustomers();
        int UpdateCustomer(Customer updatedCustomer);
        int DeleteCustomer(int id);

    }
}
