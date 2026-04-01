
using Mini_bank.Reposotory.Interfaces;
using Mini_bank.Reposotory.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace Mini_bank.Reposotory
{
    public class OperationRepository : IOperationRepository
    {
        // 1.gadaricxva 2.shetana 3. gamotana
        //List<Operation> operations = new List<Operation>();
        private readonly List<Operation> operations;
        //private const string _filePath = @"C:\Users\user\source\repos\ConsoleApp4\Data\Operations.xml";
        private readonly string _filePath;
        AccountRepository accountRepository = new AccountRepository();
        private readonly object _lock = new object();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        private readonly AccountRepository _accountRepository;
        //public OperationRepository()
        //{
        //    operations = LoadOperations();
        //}

        public OperationRepository()
        {
            operations = new List<Operation>();
        }


        public OperationRepository(string filePath, List<Operation> operations, AccountRepository accountRepository)
        {
            this.operations = operations;
            _filePath = filePath;
            this.accountRepository = accountRepository;
        }


        public static async Task<OperationRepository> CreateAsync(string filePath, AccountRepository accountRepository)
        {
            var operations = new List<Operation>();
            await foreach (var operation in LoadDataAsync(filePath))
            {
                operations.Add(operation);
            }
            return new OperationRepository(filePath, operations, accountRepository);
        }

        public Operation GetSingleOperation(int operationId)
        {
            lock (_lock)
            {
                return operations.FirstOrDefault(o => o.Id == operationId);
            }
        }

        public List<Operation> GetOperationsOfAccount(int accountId)
        {
            lock (_lock)
            {
                return operations.Where(o => o.AccountId == accountId).ToList();
            }
        }

        public async Task<int> AddOperation(Operation newOperation)
        {
            lock (_lock)
            {
                newOperation.Id = operations.Any() ? operations.Max(o => o.Id) + 1 : 1;

                operations.Add(newOperation);
            }
           await SaveDataAsync();
            return newOperation.Id;

        }

        //public List<Operation> LoadOperations()
        //{
        //    if (!File.Exists(_filePath))
        //    {
        //        return new List<Operation>();
        //    }


        //    XmlSerializer serializer = new XmlSerializer(typeof(List<Operation>));
        //    using (StreamReader reader = new StreamReader(_filePath))
        //    {
        //        operations = (List<Operation>)serializer.Deserialize(reader);

        //    }
        //    return operations;
        //}

        //public void SaveOperations(List<Operation> operationsToSave)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<Operation>));

        //    using (StreamWriter writer = new StreamWriter(_filePath))
        //    {
        //        serializer.Serialize(writer, operationsToSave);
        //    }
        //}

        public async Task Transfer(Account fromAccount, Account toAccount, decimal amount)
        {
            var fromAccountOperations = GetOperationsOfAccount(fromAccount.Id);
            var toAccountOperations = GetOperationsOfAccount(toAccount.Id);
            if (fromAccount.Balance < amount)
            {
                throw new InvalidOperationException("Not enough funds in the source account.");
            }
            Operation withdrawal = new Operation
            {
                Id = operations.Any() ? operations.Max(o => o.Id) + 1 : 1,
                AccountId = fromAccount.Id,
                Amount = -amount,
                OperationType = OperationType.Credit,

            };
            Operation deposit = new Operation
            {
                Id = operations.Any() ? operations.Max(o => o.Id) + 1 : 1,
                AccountId = toAccount.Id,
                Amount = amount,
                OperationType = OperationType.Debit
            };
            var updatedSender = fromAccount.Balance -= amount;
            var updatedReceiver = toAccount.Balance += amount;

         await  accountRepository.UpdateAccountBalance(fromAccount.Id, updatedSender);
          await  accountRepository.UpdateAccountBalance(toAccount.Id, updatedReceiver);
           await AddOperation(withdrawal);
          await AddOperation(deposit);
            await SaveDataAsync();
        }

        public async Task Debit(Account account, decimal amount)
        {
            if (account.Balance < amount)
            {
                throw new InvalidOperationException("Not enough funds in the account.");
            }
            Operation debit = new Operation
            {
                Id = operations.Any() ? operations.Max(o => o.Id) + 1 : 1,
                AccountId = account.Id,
                Amount = -amount,
                OperationType = OperationType.Debit,

            };
            var updatedBalance = account.Balance -= amount;
           await accountRepository.UpdateAccountBalance(account.Id, updatedBalance);
           await AddOperation(debit);
            await SaveDataAsync();
        }

        public async Task Credit(Account account, decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Amount must be greater than zero.");
            }
 
            Operation credit = new Operation
            {
                Id = operations.Any() ? operations.Max(o => o.Id) + 1 : 1,
                AccountId = account.Id,
                Amount = amount,
                OperationType = OperationType.Credit,

            };
            var updatedBalance = account.Balance += amount;
            await accountRepository.UpdateAccountBalance(account.Id, updatedBalance);
            await AddOperation(credit);
            await SaveDataAsync();
        }


    

    #region

            private static async IAsyncEnumerable<Operation> LoadDataAsync(string filePath)
        {
            if (!File.Exists(filePath))
                yield break;

            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192, useAsync: true);
            using var ms = new MemoryStream();
            await fs.CopyToAsync(ms);
            ms.Position = 0;

            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load(ms);
            }
            catch
            {
                yield break; 
            }

            foreach (var el in xdoc.Root?.Elements("Operation") ?? Enumerable.Empty<XElement>())
            {
                var operation = new Operation
                {
                    Id = (int)el.Element("Id")!,
                    OperationType = Enum.Parse<OperationType>((string)el.Element("OperationType")),
                    AccountId = (int)el.Element("AccountId"),
                    Amount = (decimal)el.Element("Amount"),
                    Date = (DateTime)el.Element("Date")
                };

                yield return operation;
            }
        }


        private async Task SaveDataAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                List<Operation> snapshot;

                lock (_lock)
                {
                    snapshot = operations.ToList(); 
                }

                var xdoc = new XDocument(
                    new XElement("Operations",
                        snapshot.Select(o =>
                            new XElement("Operation",
                                new XElement("Id", o.Id),
                                new XElement("OperationType", o.OperationType),
                                new XElement("AccountId", o.AccountId),
                                new XElement("Amount", o.Amount),
                                new XElement("Date", o.Date)
                            ))
                    )
                );

                using var ms = new MemoryStream();
                xdoc.Save(ms);
                ms.Position = 0;

                using var fs = new FileStream(
                    _filePath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    8192,
                    useAsync: true);

                await ms.CopyToAsync(fs);
                await fs.FlushAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
        #endregion
    }
