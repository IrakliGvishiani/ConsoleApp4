using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mini_bank.Reposotory.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyPhoneNumberAttribute : MyValidationAttribute
    {
        private string _phoneNumberPattern = @"^(\+995?\s?)?5\d{2}(\s?\d{2}){3}$"; 
        public override void Validate(object value, object instance, string propertyName)
        {
            if (value is string phoneNum)
            {
                if (!Regex.IsMatch(phoneNum, _phoneNumberPattern))
                {
                    throw new InvalidOperationException($"The {propertyName} field must be a valid phone number (9 digits).");
                }
            }
        }
    }
}
