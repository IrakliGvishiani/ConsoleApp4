using Mini_bank.Reposotory.Models;
using System;
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
            if (value is not string email)
                return;

            // Determine CustomerType from different possible instance types (Customer or DTOs)
            CustomerType? customerType = null;

            if (instance is Customer customer)
            {
                customerType = customer.CustomerType;
            }
            else if (instance != null)
            {
                var prop = instance.GetType().GetProperty("CustomerType");
                if (prop != null)
                {
                    var val = prop.GetValue(instance);
                    if (val is CustomerType ct) customerType = ct;
                    else if (val != null && Enum.TryParse<CustomerType>(val.ToString(), out var parsed))
                        customerType = parsed;
                }
            }

            
            if (customerType == null)
            {
                if (!Regex.IsMatch(email, _physicalUserEmailPattern) && !Regex.IsMatch(email, _legalUserEmailPattern))
                {
                    throw new ArgumentException($"The {propertyName} must be a valid Gmail address or end with .ge.");
                }

                return;
            }

            if (customerType == CustomerType.Physical)
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
