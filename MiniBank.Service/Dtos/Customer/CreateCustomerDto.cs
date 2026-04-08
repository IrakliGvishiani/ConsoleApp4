using Mini_bank.Reposotory.Attributes;
using Mini_bank.Reposotory.Models;
using System.ComponentModel.DataAnnotations;

namespace MiniBank.Service.Dtos.Customer
{
    public class CreateCustomerDto

    {
        [MyRequired]
        [MyMaxLength(50)]
        public string Name { get; set; }

        [MyRequired]
        [MyIdentityNumber]
        public string IdentityNumber { get; set; }
        [MyRequired] [MyPhoneNumber]
        public string PhoneNumber { get; set; }

            [MyRequired] [MyEmail]
        public string Email { get; set; }

        [MyRequired] 
        public CustomerType CustomerType { get; set; }

    }
}
