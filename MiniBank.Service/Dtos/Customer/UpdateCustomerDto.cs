
using System.ComponentModel.DataAnnotations;
using Mini_bank.Reposotory.Attributes;



namespace MiniBank.Service.Dtos.Customer
{
    public class UpdateCustomerDto
    {

        [MyRequired]
        [IsPositiveNumber]
        public int Id { get; set; }
        [MyRequired] [MyMaxLength(50)]
        public string Name { get; set; }
        [MyRequired] [MyIdentityNumber]
        public string IdentityNumber { get; set; }
        [ MyRequired] [MyPhoneNumber]
        public string PhoneNumber { get; set; }
        [MyRequired] [MyEmail]
        public string Email { get; set; }
    }
}
