using System.Text.Json;
using Mini_bank.Reposotory.Models;
namespace Mini_bank.Reposotory
{
    public class AccountRepository
    {

      private const string _filePath = @"C:\Users\user\source\repos\ConsoleApp4\Data\Accounts.json";
        private readonly List<Account> _accounts = new List<Account>();

        public AccountRepository()
        {
            if (!File.Exists(_filePath))
            {
                _accounts = new List<Account>();
                return;
            }

            string jsonData = File.ReadAllText(_filePath);
            _accounts = JsonSerializer.Deserialize<List<Account>>(jsonData) ?? new List<Account>();
        }



        public List<Account> getAllAccount<T> ()
        {
                return _accounts;
        }

        public Account getAccountById (int id)
        {
            return _accounts.FirstOrDefault(a => a.Id == id);
        }



         public int addAccount (Account newAccount)
        {
            newAccount.Id = _accounts.Any() ? _accounts.Max(a => a.Id) + 1 : 1;
            if (_accounts.Any(a => a.Id == newAccount.Id))
            {
                throw new InvalidOperationException($"An account with ID {newAccount.Id} already exists.");
            }
            
            _accounts.Add(newAccount);
            string jsonData = JsonSerializer.Serialize(_accounts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
            return newAccount.Id;
        }


        public int UpdateAccount (Account updatedAccount)
        {
            var existingAccount = _accounts.FirstOrDefault(a => a.Id == updatedAccount.Id);
            if (existingAccount == null || existingAccount.Id != updatedAccount.Id)
            {
                throw new InvalidOperationException($"Account with ID {updatedAccount.Id} does not exist.");
            }
            existingAccount.Iban = updatedAccount.Iban;
            existingAccount.Currency = updatedAccount.Currency;
            existingAccount.Balance = updatedAccount.Balance;
            existingAccount.CustomerID = updatedAccount.CustomerID;
            existingAccount.name = updatedAccount.name;
            string jsonData = JsonSerializer.Serialize(_accounts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
            return existingAccount.Id;
        }

        public void DeleteAccount (int id)
        {
            var selectedAccount = _accounts.FirstOrDefault(a => a.Id == id);

            if (selectedAccount == null)
            {
                throw new InvalidOperationException($"Account with ID {id} does not exist.");
            }

            _accounts.Remove(selectedAccount);
            string jsonData = JsonSerializer.Serialize(_accounts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }
    }



    #region AccountRepositoryInterface

    


    #endregion
}
