using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Attributes
{
        [AttributeUsage(AttributeTargets.Property)]
    public class IsPositiveNumberAttribute : MyValidationAttribute
    {
        public override void Validate(object value, object instance, string propertyName)
        {
            if (value is int intValue)
            {
                if (intValue <= 0)
                {
                    throw new InvalidOperationException($"The {propertyName} field must be a positive number.");
                }
            }
            else
            {
                throw new InvalidOperationException($"The {propertyName} field must be a decimal number.");
            }
        }
    
    }
}
