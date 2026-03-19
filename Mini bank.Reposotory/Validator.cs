using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Reflection;
using Mini_bank.Reposotory.Attributes;

namespace Mini_bank.Reposotory
{
    public static class Validator
    {
        public static void Validate(object instance)
        {
             Type instanceType = instance.GetType();
            var allprops = instanceType.GetProperties();


            foreach (var prop in allprops)
            {
                var value = prop.GetValue(instance);
                var ValidationAttributes = prop.GetCustomAttributes<MyValidationAttribute>();
                foreach (var item in ValidationAttributes) item.Validate(value, instance, prop.Name);
                
            }
        }
    }
}
