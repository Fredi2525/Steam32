using Entities.Enum;

namespace Models.Accounts
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string UserName { get; set; }
	    public string FirstName { get; set; }
	    public string LastName { get; set; }
	    public DateTime DoB { get; set; }
	    public string Gender { get; set; }
	    public Role Role { get; set; }
	    public string Password { get; set; }
	}
}
