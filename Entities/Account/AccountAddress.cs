using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Base;

namespace Entities.Account
{
    public class AccountAddress : BaseEntity
    {
        [ForeignKey("Account")]
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public string Address { get; set; } 
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
