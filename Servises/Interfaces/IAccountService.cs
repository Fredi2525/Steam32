using Models.Accounts;
using Models.Managers;

namespace Services.Interfaces
{
    public interface IAccountService
    {
	    ManagerResult<AccountDto> Add(AccountDto account);
      
    }
}
