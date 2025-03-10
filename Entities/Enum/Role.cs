using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enum
{
	public enum Role
	{
		[Display(Name = "User")]
		User = 1,

		[Display(Name = "SystemAdmin")]
		SystemAdmin = 100
	}
}
