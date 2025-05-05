using Entities.Account;
using Models.Accounts;
using Models.Managers;

namespace Data.Managers.Interfaces
{
    public interface IAccountManager
    {
	    ManagerResult<Account> Add(Account account);
        ManagerResult<AccountAddress> Add(AccountAddress address);
        ManagerResult<Account> GetByUserName(string email);
        ManagerResult<Account> GetAccountByUserNameAndPassword(string userName, string password);
    }
}
