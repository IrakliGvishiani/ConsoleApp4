using System.Text;

namespace Mini_bank.Reposotory.Models
{
    public class CustomerRepository
    {

        private const string _filePath = @"C:\Users\user\source\repos\ConsoleApp4\Data\Customers.csv";
        private readonly List<Customer> _customers = new List<Customer>();

        public CustomerRepository()
        {
           _customers = LoadData(_filePath).ToList();

        }


         public int addCustomer (Customer newCustomer)
        {
            newCustomer.Id = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1;

            if (_customers.Any(c => c.Id == newCustomer.Id))
            {
                throw new InvalidOperationException($"A customer with ID {newCustomer.Id} already exists.");
            }

              
                         _customers.Add(newCustomer);

            File.AppendAllText(_filePath, $"\n{newCustomer.Id},{newCustomer.Name},{newCustomer.IdentityNumber},{newCustomer.PhoneNumber},{newCustomer.Email},{newCustomer.CustomerType}{Environment.NewLine}\n");

                return newCustomer.Id;
        }



        public Customer GetCustomer(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }




        public List<Customer> GetAllCustomers()
            {
                return _customers;
        }




    
            public int UpdateCustomer (Customer updatedCustomer)
            {
                var existingCustomer = _customers.FirstOrDefault(c => c.Id == updatedCustomer.Id);

            if (existingCustomer == null || existingCustomer.Id != updatedCustomer.Id)
            {
                throw new InvalidOperationException($"Customer with ID {updatedCustomer.Id} does not exist.");
            }

            existingCustomer.Name = updatedCustomer.Name;
            existingCustomer.IdentityNumber = updatedCustomer.IdentityNumber;
            existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.CustomerType = updatedCustomer.CustomerType;

            SaveDataAsync();

            return existingCustomer.Id;
        }





        public int DeleteCustomer (int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new Exception();
            }

            _customers.Remove(customer);
            SaveDataAsync();
            return customer.Id;
        }


        #region HELPERS
        private static IEnumerable<Customer> LoadData(string filePath)
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
                useAsync: false
                );

            using var sr = new StreamReader(fs);

            bool headers = false;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
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


        private void SaveDataAsync()
        {

            //"Id,Name,IdentityNumber,PhoneNumber,Email,CustomerType"
                using var fs = new FileStream(
                    _filePath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    bufferSize: 4096,
                    useAsync: false
                    );

            using var sw = new StreamWriter(fs, Encoding.UTF8);

            sw.WriteLine("Id,Name,IdentityNumber,PhoneNumber,Email,CustomerType");

            foreach (var item in _customers)
            {
               sw.WriteLine($"{item.Id},{item.Name},{item.IdentityNumber},{item.PhoneNumber},{item.Email},{item.CustomerType}");
            }

            sw.Flush();
        }

        #endregion
    }
}
