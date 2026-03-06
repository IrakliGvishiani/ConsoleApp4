namespace Mini_bank.Reposotory.Models
{
    public class CustomerRepository
    {

        private const string _filePath = @"C:\Users\user\source\repos\ConsoleApp4\Data\Customers.csv";
        private readonly List<Customer> _customers = new List<Customer>();

        public CustomerRepository()
        {
           _customers = LoadData(_filePath);

        }


         public int addCustomer (Customer newCustomer)
        {
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
        private static List<Customer> LoadData(string filePath)
        {
            var lines = File.ReadAllLines(_filePath);
            var customers = new List<Customer>();

            if (!File.Exists(filePath))
            {
                return customers;
            }

            foreach (var line in lines.Skip(1))
                {
                    if(string.IsNullOrWhiteSpace(line))
                    {
                        continue; 
                     }
                var customer = ParseFromCsv(line);

                if (customer != null)
                {
                    customers.Add(customer);
                }
             
            }
            return customers;
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
                    CustomerType = Convert.ToByte(parts[5])
                };
            return customer;
        }


        private void SaveDataAsync()
        {
            var lines = new List<string>();

            lines.Add("Id,Name,IdentityNumber,PhoneNumber,Email,CustomerType");

            foreach (var c in _customers)
            {
                lines.Add($"{c.Id},{c.Name},{c.IdentityNumber},{c.PhoneNumber},{c.Email},{c.CustomerType}");
            }

            File.WriteAllLines(_filePath, lines);
        }




        #endregion
    }
}
