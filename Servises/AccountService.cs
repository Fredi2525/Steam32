using Data.Managers.Interfaces;
using Entities.Account;
using Models.Accounts;
using Models.Managers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountManager _accountManager;

        public AccountService(IAccountManager accountManager )
        {
            _accountManager = accountManager;
        }
        public ManagerResult<AccountDto> Add(AccountDto account)
        {
            var result = new ManagerResult<AccountDto>();
            try
            {
                var dbResult = _accountManager.Add(new Account());

                ;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }
    }
}
