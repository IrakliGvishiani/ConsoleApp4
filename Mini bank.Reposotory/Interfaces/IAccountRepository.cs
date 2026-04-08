using System;
using System.Collections.Generic;
using System.Text;
using Mini_bank.Reposotory.Models;
namespace Mini_bank.Reposotory.Interfaces
{
    public interface IAccountRepository
    {
        public List<Account> getAllAccount<T> ();

        Account getAccountById(int id);
        Task<int> addAccount(Account newAccoun);

        Task UpdateAccountBalance(int id, decimal newBalance);
        Task<int> UpdateAccount(Account updatedAccount);
        Task DeleteAccount(int id);

        public List<Account> getAccountsByCustomerId(int customerId);

        //void TransferFunds(int fromAccountId, int toAccountId, decimal amount);
    }
}
