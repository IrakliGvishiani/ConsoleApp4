using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyPhoneNumberAttribute : MyValidationAttribute
    {
        public override void Validate(object value, object instance, string propertyName)
        {
            if (value is string phoneNum)
            {
                if (phoneNum.Length != 9)
                {
                    throw new InvalidOperationException($"The {propertyName} field must be a valid phone number (9 digits).");
                }
            }
        }
    }
}
