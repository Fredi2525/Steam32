using Models.Accounts;
using Models.Managers;

namespace Services.Interfaces
{
    public interface IAccountService
    {
	    ManagerResult<AccountDto> Add(AccountDto account);
        ManagerResult<AccountAddressDto> Add(AccountAddressDto address);
        ManagerResult<AccountDto> GetAccountByUserNameAndPassword(string userName, string password);


    }
}
