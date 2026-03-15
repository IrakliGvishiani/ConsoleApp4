
using Mini_bank.Reposotory.Models;
using System.Xml.Serialization;
using Mini_bank.Reposotory.Interfaces;
namespace Mini_bank.Reposotory
{
    public class OperationRepository : IOperationRepository
    {
        // 1.gadaricxva 2.shetana 3. gamotana
        List<Operation> operations = new List<Operation>();
        private const string _filePath = @"C:\Users\user\source\repos\ConsoleApp4\Data\Operations.xml";
        AccountRepository accountRepository = new AccountRepository();
        public OperationRepository()
        {
            operations = LoadOperations();
        }



      public Operation GetSingleOperation(int operationId)
        {
            return operations.FirstOrDefault(o => o.Id == operationId);
        }

       public List<Operation> GetOperationsOfAccount(int accountId)
        {
            return operations.Where(o => o.AccountId == accountId).ToList();
        }

        public int AddOperation(Operation newOperation)
        {
            newOperation.Id = operations.Any() ? operations.Max(o => o.Id) + 1 : 1;

            operations.Add(newOperation);
            return newOperation.Id;
        }

        public List<Operation> LoadOperations()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Operation>();
            }


            XmlSerializer serializer = new XmlSerializer(typeof(List<Operation>));
            using (StreamReader reader = new StreamReader(_filePath))
            {
                operations = (List<Operation>)serializer.Deserialize(reader);

            }
            return operations;
        }

        public void SaveOperations(List<Operation> operationsToSave)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Operation>));

            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                serializer.Serialize(writer, operationsToSave);
            }
        }

        public void Transfer(Account fromAccount, Account toAccount, decimal amount)
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

            accountRepository.UpdateAccountBalance(fromAccount.Id, updatedSender);
            accountRepository.UpdateAccountBalance(toAccount.Id, updatedReceiver);
            AddOperation(withdrawal);
            AddOperation(deposit);
            SaveOperations(operations);
        }

        public void Debit(Account account, decimal amount)
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
            accountRepository.UpdateAccountBalance(account.Id, updatedBalance);
            AddOperation(debit);
            SaveOperations(operations);
        }

        public void Credit(Account account, decimal amount)
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
            accountRepository.UpdateAccountBalance(account.Id, updatedBalance);
            AddOperation(credit);
            SaveOperations(operations);
        }


    }
}
