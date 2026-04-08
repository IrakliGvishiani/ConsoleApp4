using Mini_bank.Reposotory.Models;
using MiniBank.Service;
using MiniBank.Service.Dtos.Customer;
using MiniBank.Service.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace MiniBankWindowsFormUi
{
    public partial class Form1 : Form
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;
        public Form1(ICustomerService customerService, IAccountService accountService)
        {
            InitializeComponent();
            _customerService = customerService;
            _accountService = accountService;

            this.Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var customers = await _customerService.GetAllCustomers();
            listBox1.DataSource = customers;
            listBox1.DisplayMember = "Name";

            CustomerTypeCombo.DataSource = Enum.GetValues(typeof(CustomerType));

        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectedCustomer = listBox1.SelectedItem as CustomerDto;
            if (selectedCustomer != null)
            {
                var customerDetails = await _customerService.GetCustomerById(selectedCustomer.Id);
                //MessageBox.Show($"Name: {customerDetails.Name}\nIdentity Number: {customerDetails.IdentityNumber}\nPhone: {customerDetails.PhoneNumber}\nEmail: {customerDetails.Email}");

                NameValue.Text = $"{customerDetails.Name}";
                IdentityValue.Text = $"{customerDetails.IdentityNumber}";
                PhoneNumValue.Text = $"{customerDetails.PhoneNumber}";
                EmailValue.Text = $"{customerDetails.Email}";
                CustomerTypeCombo.DataSource = Enum.GetValues(typeof(CustomerType));
            }

            var accounts = _accountService.GetAllAccounts(selectedCustomer.Id);

            AccountsOfCustomer.DataSource = accounts;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void ClearBtn_Click(object sender, EventArgs e)
        {
            NameValue.Text = "";
            IdentityValue.Text = "";
            PhoneNumValue.Text = "";
            EmailValue.Text = "";
            CustomerTypeCombo.SelectedIndex = -1;
        }

        private async void AddBtn_Click(object sender, EventArgs e)
        {

            var newCustomer = new CreateCustomerDto
            {
                Name = NameValue.Text,
                IdentityNumber = IdentityValue.Text,
                PhoneNumber = PhoneNumValue.Text,
                Email = EmailValue.Text,
                CustomerType = (CustomerType)CustomerTypeCombo.SelectedIndex
            };




            await _customerService.AddCustomer(newCustomer);
            MessageBox.Show("Customer added successfully!");
            // customer-ის ლისტის რეფრეში
            Form1_Load(sender, e);
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {

            var selectedCustomer = listBox1.SelectedItem as CustomerDto;

            if (selectedCustomer == null)
            {
                MessageBox.Show($"Selected Customer ID: {selectedCustomer.Id}");
                return;
            }


            var newCustomer = new UpdateCustomerDto
            {
                Id = selectedCustomer.Id,
                Name = NameValue.Text,
                IdentityNumber = IdentityValue.Text,
                PhoneNumber = PhoneNumValue.Text,
                Email = EmailValue.Text,
            };

            await _customerService.updateCustomer(newCustomer);
            MessageBox.Show("Customer updated successfully!");
            Form1_Load(sender, e);
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            var selectedCustomer = listBox1.SelectedItem as CustomerDto;

            if (selectedCustomer == null)
            {
                MessageBox.Show($"Selected Customer ID: {selectedCustomer.Id}");
                return;
            }

            await _customerService.deleteCustomer(selectedCustomer.Id);
            MessageBox.Show("Customer deleted successfully!");
            Form1_Load(sender, e);
        }

        private void AccountsOfCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
