using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Models.Attributes
{
    public class PasswordValidationAttribute : ValidationAttribute 
    {
        public PasswordValidationAttribute(int minLengths, int maxLengths)
        {
            MaxLengths = maxLengths;
            MinLengths = minLengths;
        }

        public int MaxLengths { get; set; }
        public int MinLengths { get; set; }

        public string GetErrorMassage(string message)
        {
            return message;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string pass = (string)value;

            if (string.IsNullOrEmpty(pass))
            {
                return new ValidationResult(GetErrorMassage("Pass is Required"));
            }
            if (pass.Length > this.MaxLengths)
            {
                return new ValidationResult(GetErrorMassage($"Дуже довгий пароль. Макимальна довжина {MaxLengths}"));
            }
            if (pass.Length <  this.MinLengths)
            {
                return new ValidationResult(GetErrorMassage($"Дуже короткий пароль. Мінімальна довжина {MinLengths}"));
            }
            if (!(ContainsLowercase(pass) && ContainsUppercase(pass)))
            {
                return new ValidationResult(GetErrorMassage($"Пароль має містити хочаб і велику і одну маленьки букви"));
            }

            return ValidationResult.Success;
        }
        static bool ContainsUppercase(string input)
        {
            return input.Any(char.IsUpper);
        }
        static bool ContainsLowercase (string input)
        {
            return input.Any(char.IsLower);
        }

    }
}
