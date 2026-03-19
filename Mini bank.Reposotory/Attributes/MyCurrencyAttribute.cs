using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyCurrencyAttribute : MyValidationAttribute
    {
        public override void Validate(object value, object instance, string propertyName)
        {
            if (value is string currency)
            {
                if (currency.Length != 3) {
                throw new InvalidOperationException($"The {propertyName} field must be a valid currency code (3 letters).");
                }
            }
        }
    }
}
