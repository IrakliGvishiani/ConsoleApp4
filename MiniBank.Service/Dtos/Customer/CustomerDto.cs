using Mini_bank.Reposotory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.Service.Dtos.Customer
{
    public class CustomerDto
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public CustomerType CustomerType { get; set; }

    }
}
