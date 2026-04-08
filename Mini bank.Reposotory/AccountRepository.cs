using Mini_bank.Reposotory.Interfaces;
using Mini_bank.Reposotory.Models;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Mini_bank.Reposotory
{
    public class AccountRepository : IAccountRepository
    {
        //private const string _filePath = @"C:\Users\user\source\repos\ConsoleApp4\Data\Accounts.json";
        private readonly string _filePath;
        private readonly List<Account> _accounts;
        private readonly object _lock = new object();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);


        public AccountRepository()
        {
            //if (!File.Exists(_filePath))
            //{
            //    _accounts = new List<Account>();
            //    return;
            //}

            //string jsonData = File.ReadAllText(_filePath);
            //_accounts = JsonSerializer.Deserialize<List<Account>>(jsonData) ?? new List<Account>();
            _accounts = new List<Account>();
        }


        private AccountRepository(string filePath, List<Account> accounts)
        {
            _accounts = accounts;
            _filePath = filePath;
        }

        public static async Task<AccountRepository> CreateAsync(string filePath)
        {
            var account = new List<Account>();

            await foreach (var acc in LoadData(filePath))
            {
                account.Add(acc);
            }

            return new AccountRepository(filePath, account);
        }

        public List<Account> getAllAccount<T>()
        {
            lock (_lock)
            {
                return _accounts.ToList();
            }
        }

        public Account getAccountById(int id)
        {
            lock (_lock)
            {
                return _accounts.FirstOrDefault(a => a.Id == id);
            }
        }

        public List<Account> getAccountsByCustomerId(int customerId)
        {
            lock (_lock)
            {
                return _accounts.Where(a => a.CustomerId == customerId).ToList();
            }
        }



        public async Task<int> addAccount(Account newAccount)
        {

            lock (_lock)
            {
                newAccount.Id = _accounts.Any() ? _accounts.Max(a => a.Id) + 1 : 1;
                if (_accounts.Any(a => a.Id == newAccount.Id))
                {
                    throw new InvalidOperationException($"An account with ID {newAccount.Id} already exists.");
                }

                _accounts.Add(newAccount);
            }
            //string jsonData = JsonSerializer.Serialize(_accounts, new JsonSerializerOptions { WriteIndented = true });

            //await File.WriteAllTextAsync(_filePath, jsonData);
            await SaveDataAsync();
            return newAccount.Id;
        }


        public async Task<int> UpdateAccount(Account updatedAccount)
        {
            var existingAccount = _accounts.FirstOrDefault(a => a.Id == updatedAccount.Id);
            lock (_lock)
            {
                if (existingAccount == null)
                {
                    throw new InvalidOperationException($"Account with ID {updatedAccount.Id} does not exist.");
                }
                existingAccount.Iban = updatedAccount.Iban;
                existingAccount.Currency = updatedAccount.Currency;
                existingAccount.Balance = updatedAccount.Balance;
                existingAccount.CustomerId = updatedAccount.CustomerId;
                existingAccount.Name = updatedAccount.Name;
            }
            //string jsonData = JsonSerializer.Serialize(_accounts, new JsonSerializerOptions { WriteIndented = true });
            //await File.WriteAllTextAsync(_filePath, jsonData);
            await SaveDataAsync();
            return existingAccount.Id;
        }

        public async Task UpdateAccountBalance(int id, decimal newBalance)
        {
            lock (_lock)
            {
                var existingAccount = _accounts.FirstOrDefault(a => a.Id == id);
                if (existingAccount == null)
                {
                    throw new InvalidOperationException($"Account with ID {id} does not exist.");
                }
                existingAccount.Balance = newBalance;
            }
            //string jsonData = JsonSerializer.Serialize(_accounts, new JsonSerializerOptions { WriteIndented = true });
            //await File.WriteAllTextAsync(_filePath, jsonData);
            await SaveDataAsync();
        }

        public async Task DeleteAccount(int id)
        {
            lock (_lock)
            {
                var accountToRemove = _accounts.FirstOrDefault(a => a.Id == id);
                if (accountToRemove == null)
                {
                    throw new InvalidOperationException($"Account with ID {id} does not exist.");
                }
                _accounts.Remove(accountToRemove);
            }
            //string jsonData = JsonSerializer.Serialize(_accounts, new JsonSerializerOptions { WriteIndented = true });
            //await File.WriteAllTextAsync(_filePath, jsonData);
            await SaveDataAsync();
        }







        #region AccountRepositoryInterface


        private async Task SaveDataAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                List<Account> snapshot;

                lock (_lock)
                {
                    snapshot = _accounts.ToList(); // avoid long lock
                }

                var jsonPayload = JsonSerializer.Serialize(snapshot, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                using var fs = new FileStream(
                    _filePath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    8192,
                    useAsync: true);

                var bytes = Encoding.UTF8.GetBytes(jsonPayload);
                await fs.WriteAsync(bytes, 0, bytes.Length);
                await fs.FlushAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }
        private static async IAsyncEnumerable<Account> LoadData(string filePath)
        {
            if (!File.Exists(filePath))
                yield break;
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192, useAsync: true);
            using var ms = new MemoryStream();
            await fs.CopyToAsync(ms);
            ms.Position = 0;
            List<Account> accounts;
            try
            {
                accounts = JsonSerializer.Deserialize<List<Account>>(ms) ?? new List<Account>();
            }
            catch
            {
                yield break;
            }
            foreach (var account in accounts)
            {
                yield return account;
            }
        }
    }

}

        #endregion
    
