using Mini_bank.Reposotory.Models;
using MiniBank.Service;
using MiniBank.Service.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mini_bank.Reposotory.Interfaces;
namespace MiniBankWindowsFormUi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();


            //var customerRepository = await CustomerRepository.CreateAsync(@"C:\Users\user\source\repos\ConsoleApp4\Data\Customers.csv");
            //ICustomerService customerService = new CustomerService(customerRepository);
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainForm = ServiceProvider.GetRequiredService<Form1>();
            Application.Run(mainForm);
        }
    


    private static void ConfigureServices(IServiceCollection services)
        {
            string customerFilePath = @"C:\Users\user\source\repos\ConsoleApp4\Data\Customers.csv";

            services.AddSingleton<ICustomerRepository>(provider =>
            {
                return CustomerRepository.CreateAsync(customerFilePath).GetAwaiter().GetResult();
            });

            services.AddTransient<ICustomerService, CustomerService>();

            services.AddTransient<Form1>();
        }
    }
}