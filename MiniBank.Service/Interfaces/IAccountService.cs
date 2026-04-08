

using MiniBank.Service.Dtos.Account;

namespace MiniBank.Service.Interfaces
{
    public interface IAccountService
    {
        public List<GetAccountDto> GetAllAccounts(int customerId);
    }
}
