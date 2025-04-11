using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Accounts
{
    public class AccountAddressDto
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string BuildingNumber {  get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
