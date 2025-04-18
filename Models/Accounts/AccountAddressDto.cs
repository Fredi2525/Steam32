using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Accounts
{
    public class AccountAddressDto
    {
        [Required(ErrorMessage = "Please enter the address in this field.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City not found")]
        public string City { get; set; }

        [Required(ErrorMessage = "")]
        public string BuildingNumber {  get; set; }

        [Required(ErrorMessage = "")]
        public string Country { get; set; }
      
        [Required(ErrorMessage = "ZipCode not found")]
        public string ZipCode { get; set; }
        
    }
}
