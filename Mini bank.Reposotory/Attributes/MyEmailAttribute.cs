using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyEmailAttribute : MyValidationAttribute
    {
        public override void Validate(object value, object instance, string propertyName)
        {
            if (value is string email)
            {
                if (!email.Contains("@") || !email.Contains("."))
                {
                    throw new InvalidOperationException($"The {propertyName} field must be a valid email address.");
                }
            }
        }
    }
}
