

using MiniBank.Service.Dtos.Account;

namespace MiniBank.Service.Interfaces
{
    public interface IAccountService
    {
        public List<GetAccountDto> GetAllAccounts(int customerId);

        Task<int> AddAccount(CreateAccountDto dto);

        public Task DeleteAccount (int id);

        //public UpdateAccountDto getSingleAccount(int id);

        //public Task<int> UpdateAccount(UpdateAccountDto dto);
    }
}
