using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public byte CustomerType { get; set; }

    }
}
