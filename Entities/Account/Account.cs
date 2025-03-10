using System.ComponentModel.DataAnnotations;
using Entities.Base;
using Entities.Enum;

namespace Entities.Account
{
	public class Account : BaseEntity
	{
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DoB { get; set; }
		public string Gender { get; set; }
		public Role Role { get; set; }
		public string Password { get; set; }
	}
}
