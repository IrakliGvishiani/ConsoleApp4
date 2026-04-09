

using Mini_bank.Reposotory.Interfaces;
using MiniBank.Service.Dtos.Account;
using MiniBank.Service.Interfaces;
//using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Mini_bank.Reposotory;
using Mini_bank.Reposotory.Interfaces;
using Mini_bank.Reposotory.Models;
using MiniBank.Service.Dtos.Customer;
using MiniBank.Service.Interfaces;

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

        public async Task<int> AddAccount(CreateAccountDto dto)
        {
            Validator.Validate(dto);

            var account = new Account
            {

                Currency = dto.Currency,
                Balance = 0,
                Name = dto.Name,
                CustomerId = dto.CustomerId,

            };

            return await _accountService.addAccount(account);
        }


        public async Task DeleteAccount(int id) => await _accountService.DeleteAccount(id);


        //public UpdateAccountDto getSingleAccount(int id)
        //{
        //    var account = _accountService.getAccountById(id);
        //    return new UpdateAccountDto
        //    {
        //        Id = account.Id,
        //        Currency = account.Currency,
        //        Name = account.Name,
        //    };
        //}



    }
}
