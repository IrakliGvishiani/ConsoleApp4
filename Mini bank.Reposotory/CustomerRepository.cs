using System.Diagnostics.Metrics;
using System.Text;
using System.Threading.Tasks;
using Mini_bank.Reposotory.Interfaces;
namespace Mini_bank.Reposotory.Models
{
    public class CustomerRepository : ICustomerRepository
    {

        //private const string _filePath = @"C:\Users\user\source\repos\ConsoleApp4\Data\Customers.csv";
        //private readonly List<Customer> _customers = new List<Customer>();
        private readonly object _lock = new object();
        private readonly List<Customer> _customers;
        private readonly string _filePath;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        //public CustomerRepository()
        //{
        //   _customers = LoadData(_filePath).ToList();

        //}
        private CustomerRepository(string filePath, List<Customer> customers)
        {
            _customers = customers;
            _filePath = filePath;
        }

        

        public static async Task<CustomerRepository> CreateAsync(string filePath)
        {
            var customers = new List<Customer>();

           await foreach (var customer in LoadData(filePath))
            {
                customers.Add(customer);
            }

            return new CustomerRepository(filePath, customers);
        }

         public async Task<int> addCustomer (Customer newCustomer)
        {

            lock (_lock)
            {
                newCustomer.Id = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1;

                if (_customers.Any(c => c.Id == newCustomer.Id))
                {
                    throw new InvalidOperationException($"A customer with ID {newCustomer.Id} already exists.");
                }
                _customers.Add(newCustomer);

            }



            //File.AppendAllText(_filePath, $"\n{newCustomer.Id},{newCustomer.Name},{newCustomer.IdentityNumber},{newCustomer.PhoneNumber},{newCustomer.Email},{newCustomer.CustomerType}\n");
            await SaveDataAsync();

            return newCustomer.Id;
        }



        public Customer GetCustomer(int id)
        {
            lock (_lock)
            {
                return _customers.FirstOrDefault(c => c.Id == id);
            }
        }




        public List<Customer> GetAllCustomers()
            {
                lock (_lock)
                {
                    return _customers.ToList();
                }
             }




    
            public async Task<int> UpdateCustomer (Customer updatedCustomer)
            {
                var existingCustomer = _customers.FirstOrDefault(c => c.Id == updatedCustomer.Id);

            lock (_lock) {

                if (existingCustomer == null || existingCustomer.Id != updatedCustomer.Id)
                {
                    throw new InvalidOperationException($"Customer with ID {updatedCustomer.Id} does not exist.");
                }

                existingCustomer.Name = updatedCustomer.Name;
                existingCustomer.IdentityNumber = updatedCustomer.IdentityNumber;
                existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
                existingCustomer.Email = updatedCustomer.Email;
                existingCustomer.CustomerType = updatedCustomer.CustomerType;

            }
            await SaveDataAsync();

            return existingCustomer.Id;
        }





        public async Task<int> DeleteCustomer (int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            lock (_lock)
            {
                if (customer == null)
                {
                    throw new Exception();
                }

                _customers.Remove(customer);
            }
            await SaveDataAsync();
            return customer.Id;
        }


        #region HELPERS
        private static async IAsyncEnumerable<Customer> LoadData(string filePath)
        {
            //var customers = new List<Customer>();

            if (!File.Exists(filePath))
            {
               yield break;
            }

            using var fs = new FileStream(
                filePath, 
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 4096,
                useAsync: true
                );

            using var sr = new StreamReader(fs);

            bool headers = false;

            while (!sr.EndOfStream)
            {
                var line = await sr.ReadLineAsync();
                if (!headers)
                {
                    headers = true;
                    continue;
                }
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                var customer = ParseFromCsv(line);
                if (customer != null)
                {
                 yield return customer;
                }
            }

      
        }

        private static Customer ParseFromCsv(string lines)
        {
  
        
                var parts = lines.Split(',',StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 6)
                {
                    throw new FormatException($"Invalid line format: {lines}");
                }


                var customer = new Customer
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    IdentityNumber = parts[2],
                    PhoneNumber = parts[3],
                    Email = parts[4],
                    CustomerType = Enum.Parse<CustomerType>(parts[5])
                };
            return customer;
        }


        private async Task SaveDataAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                using var fs = new FileStream(
                    _filePath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    bufferSize: 4096,
                    useAsync: true
                );

                using var sw = new StreamWriter(fs, Encoding.UTF8);

                await sw.WriteLineAsync("Id,Name,IdentityNumber,PhoneNumber,Email,CustomerType");

                List<Customer> snapshot;
                lock (_lock)
                {
                    snapshot = _customers.ToList();
                }

                foreach (var item in snapshot)
                {
                    await sw.WriteLineAsync(toCsv(item));
                }

                await sw.FlushAsync();
            }
            finally
            {
                _semaphore.Release(); // ✔️ ყოველთვის გაეშვება
            }
        }



        private static string toCsv(Customer customer) => $"{customer.Id},{customer.Name},{customer.IdentityNumber},{customer.PhoneNumber},{customer.Email},{customer.CustomerType}";




        #endregion
    }
}
