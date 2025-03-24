using Entities.Account;
using Models.Managers;

namespace Data.Managers.Interfaces
{
    public interface IAccountManager
    {
	    ManagerResult<Account> Add(Account account);
        ManagerResult<Account> GetByUserName(string email);
    }
}
