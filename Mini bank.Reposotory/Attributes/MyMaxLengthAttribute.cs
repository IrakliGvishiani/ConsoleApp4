using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyMaxLengthAttribute : MyValidationAttribute
    {
        private int _maxLength;
        public MyMaxLengthAttribute(int length)
        {
            _maxLength = length;
        }
        public override void Validate(object value, object instance, string propertyName)
        {
            if (value is string name)
            {
                if (name.Length > _maxLength)
                {
                    throw new InvalidOperationException($"The {propertyName} field must not exceed 50 characters.");
                }
            }
        }
    }
}
