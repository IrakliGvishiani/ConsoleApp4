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
        int addAccount(Account newAccoun);

        void UpdateAccountBalance(int id, decimal newBalance);
        int UpdateAccount(Account updatedAccount);
        void DeleteAccount(int id);

        //void TransferFunds(int fromAccountId, int toAccountId, decimal amount);
    }
}
