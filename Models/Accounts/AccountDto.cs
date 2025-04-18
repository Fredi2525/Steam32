using System.ComponentModel.DataAnnotations;
using Entities.Enum;
using Models.Attributes;

namespace Models.Accounts
{
    public class AccountDto
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9.'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Email not valid")]
        [Required(ErrorMessage = "User Name is required field")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First Name is required field")]
        public string FName { get; set; }


        [Required(ErrorMessage = "Last Name is required field")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Dob is required field")]
        public DateTime DoB { get; set; }


        public string Gender { get; set; }


        public Role Role { get; set; }


        [PasswordValidationAttribute(6, 32)]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Паролі не співпадають (атрибут)")]
        public string ConfirmPassword { get; set; }
    }
}
