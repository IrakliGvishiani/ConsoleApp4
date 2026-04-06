
using Mini_bank.Reposotory;
using Mini_bank.Reposotory.Interfaces;
using Mini_bank.Reposotory.Models;
using MiniBank.Service.Dtos.Customer;
using MiniBank.Service.Interfaces;
//using System.ComponentModel.DataAnnotations;

namespace MiniBank.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //public CustomerService()
        //{
        //}

        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();

            var customerDtos =  customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                IdentityNumber = c.IdentityNumber,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
                CustomerType = c.CustomerType
            }).ToList();

            return customerDtos;
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer == null)
                return null;

            var customerDto = new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                IdentityNumber = customer.IdentityNumber,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                CustomerType = customer.CustomerType
            };
            return customerDto;
        }


        public async Task<int> AddCustomer(CreateCustomerDto dto)
        {
            
            Validator.Validate(dto);

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
            Validator.Validate(dto);
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

        public async Task<int> deleteCustomer(int id)
        {
            return await _customerRepository.DeleteCustomer(id);
        }

    }
}
