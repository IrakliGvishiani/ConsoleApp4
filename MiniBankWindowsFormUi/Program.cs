using Mini_bank.Reposotory.Models;
using MiniBank.Service;
using MiniBank.Service.Interfaces;
using System.Threading.Tasks;

namespace MiniBankWindowsFormUi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var customerRepository = await CustomerRepository.CreateAsync(@"C:\Users\user\source\repos\ConsoleApp4\Data\Customers.csv");
            ICustomerService customerService = new CustomerService(customerRepository);

            Application.Run(new Form1(customerService));
        }
    }
}