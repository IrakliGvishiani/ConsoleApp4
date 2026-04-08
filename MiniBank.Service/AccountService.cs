

using Mini_bank.Reposotory.Interfaces;
using MiniBank.Service.Dtos.Account;
using MiniBank.Service.Interfaces;
using System.Threading.Tasks;

namespace MiniBank.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountService;

        public AccountService(IAccountRepository accountService)
        {
            _accountService = accountService;
        }

        public List<GetAccountDto> GetAllAccounts(int customerId)
        {

            var accounts = _accountService.getAccountsByCustomerId(customerId);

            return accounts.Select(a => new GetAccountDto
            {
                Id = a.Id,
                Iban = a.Iban,
                Currency = a.Currency,
                Balance = a.Balance
            }).ToList();

        }
    }
}
