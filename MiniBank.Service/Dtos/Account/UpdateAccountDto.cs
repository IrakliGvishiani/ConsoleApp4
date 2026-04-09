using Mini_bank.Reposotory.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniBank.Service.Dtos.Account
{
    public class UpdateAccountDto
    {
        public int Id { get; set; }

        [MyRequired]
        [MyCurrency]
        public string Currency { get; set; }
        [MyRequired]
        public string Name { get; set; }
    }
}
