using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override void Validate(object value, object instance, string propertyName)
        {
            if (value is null)
            {
                throw new InvalidOperationException($"The {propertyName} field is required.");
            }
        }
    }
}
