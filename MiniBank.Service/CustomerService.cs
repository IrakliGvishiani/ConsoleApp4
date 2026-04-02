
using Mini_bank.Reposotory.Models;
using MiniBank.Service.Dtos.Customer;

namespace MiniBank.Service
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //public List<CustomerDto> GetAllCustomers()
        //{
        //    var customers = _customerRepository.GetAllCustomers();
            
        //    var customerDtos = customers.Select(c => new CustomerDto
        //    {
        //        Id = c.Id,
        //        Name = c.Name,
        //        IdentityNumber = c.IdentityNumber,
        //        PhoneNumber = c.PhoneNumber,
        //        Email = c.Email,
        //    }).ToList();
        //    return customerDtos;
        //}

        //public CustomerDto GetCustomerById(int id)
        //{
        //    var customer = _customerRepository.GetCustomer(id);
        //    if (customer == null)
        //        return null;
            
        //    var customerDto = new CustomerDto
        //    {
        //        Id = customer.Id,
        //        Name = customer.Name,
        //        IdentityNumber = customer.IdentityNumber,
        //        PhoneNumber = customer.PhoneNumber,
        //        Email = customer.Email,
        //    };
        //    return customerDto;
        //}


        public async Task<int> AddCustomer(CreateCustomerDto dto)
        {
            
            var customer = new Customer
            {
                Name = dto.Name,
                IdentityNumber = dto.IdentityNumber,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
            };

            
            return await _customerRepository.addCustomer(customer);
        }

        public async Task<int> updateCustomer(UpdateCustomerDto dto)
        {
            var customer = new Customer
            {
                Id = dto.Id,
                Name = dto.Name,
                IdentityNumber = dto.IdentityNumber,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
            };


            return await _customerRepository.UpdateCustomer(customer);
        }

        //public async Task<int> deleteCustomer(int id)
        //    {
        //        return await _customerRepository.DeleteCustomer(id);
        //}

    }
}
