using MiniBank.Service.Dtos.Account;
using MiniBank.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniBankWindowsFormUi
{
    public partial class Form2 : Form
    {

        private int _customerId;
        private readonly IAccountService _accountService;
        //private int _accountId;
        public Form2(int customerId, IAccountService accountService)
        {
            InitializeComponent();
            _customerId = customerId;
            _accountService = accountService;
            //this.Load += Form2_Load;
        }
        //public Form2(int customerId, int accountId, IAccountService accountService)
        //{
        //    InitializeComponent();
        //    _customerId = customerId;
        //    _accountId = accountId;
        //    _accountService = accountService;
        //}

        //private async void Form2_Load(object sender, EventArgs e)
        //{

        //}





        private async void CreateAccountBtn_Click(object sender, EventArgs e)
        {



            if (NameValue.Text == "")
            {
                var newAccount = new CreateAccountDto
                {
                    CustomerId = _customerId,
                    Currency = CurrencyValue.Text,
                    Name = null,
                };

                await _accountService.AddAccount(newAccount);
                MessageBox.Show("Account created successfully!");
            }
            else
            {
                var newAccount = new CreateAccountDto
                {
                    CustomerId = _customerId,
                    Currency = CurrencyValue.Text,
                    Name = NameValue.Text,
                };

                await _accountService.AddAccount(newAccount);
                MessageBox.Show("Account created successfully!");
            }



       
        }
    }
}
