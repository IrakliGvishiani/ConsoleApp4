using Mini_bank.Reposotory.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Models
{
    public class Customer
    {
        [MyRequired]
        [IsPositiveNumber]
        public int Id { get; set; }

        [MyRequired]
        [MyMaxLength(50)]
        public string Name { get; set; }

        [MyRequired]
            [MyIdentityNumber]
        public string IdentityNumber { get; set; }

            [MyRequired]
            [MyPhoneNumber]
        public string PhoneNumber { get; set; }

        [MyRequired]

            [MyEmail]
        public string Email { get; set; }
        public CustomerType CustomerType { get; set; }

    }
}
