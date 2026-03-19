using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Attributes
{
    
    [AttributeUsage(AttributeTargets.Property)]
    public class MyIbanAttribute : MyValidationAttribute
    {
        
           private int _ibanLength = 22;
        public override void Validate(object value, object instance, string propertyName)
        {
            if (value is string iban)
            {
                if (iban.Length != _ibanLength)
                {
                    throw new InvalidOperationException($"The {propertyName} field must be a valid IBAN.");
                }
            }
            else
            {
                throw new InvalidOperationException($"The {propertyName} field must be a string.");
            }
        }
    }
}
