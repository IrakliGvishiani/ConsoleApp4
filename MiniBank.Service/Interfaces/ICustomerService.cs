

using MiniBank.Service.Dtos.Customer;

namespace MiniBank.Service.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<CustomerDto>> GetAllCustomers();
        public Task<CustomerDto> GetCustomerById(int id);

        public Task<int> AddCustomer(CreateCustomerDto dto);

        public Task<int> updateCustomer(UpdateCustomerDto dto);

        public Task<int> deleteCustomer(int id);

    }
}
