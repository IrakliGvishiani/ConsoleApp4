using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_bank.Reposotory.Attributes
{
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract void Validate(object value, object instance, string propertyName);
    }
}
