using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyIdentityNumberAttribute : MyValidationAttribute
    {

        public override void Validate(object value, object instance, string propertyName)
        {
            if (value is string identityNum)
            {
                if (identityNum.Length != 11)
                {
                    throw new InvalidOperationException($"The {propertyName} field must be a valid identity number (11 digits).");
                }
            }
        }
    }
}
