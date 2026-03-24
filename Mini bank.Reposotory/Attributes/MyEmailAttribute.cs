using Mini_bank.Reposotory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace Mini_bank.Reposotory.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class MyEmailAttribute : MyValidationAttribute
    {
        private string _physicalUserEmailPattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$"; 
        private string _legalUserEmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.ge$"; 
        public override void Validate(object value, object instance, string propertyName)
        {
            var customer = instance as Customer;
            if (value is string email)
            {
                if (customer.CustomerType == CustomerType.Physical)
                {
                    if (!Regex.IsMatch(email, _physicalUserEmailPattern))
                    {
                        throw new ArgumentException($"The {propertyName} must be a valid Gmail address for Physical Users.");
                    }
                }
                else 
                {
                    if (!Regex.IsMatch(email, _legalUserEmailPattern))
                    {
                        throw new ArgumentException($"The {propertyName} must be a valid email address ending with .ge for Legal Users.");
                    }
                }
            }
        }
    } 
    }
