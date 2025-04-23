using AutoMapper;
using Data.Managers.Interfaces;
using Entities.Account;
using Microsoft.Identity.Client;
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
        private readonly IMapper _maper;


        public AccountService(IAccountManager accountManager, IMapper maper  )
        {
            _accountManager = accountManager;
            _maper = maper; 
        }

        public ManagerResult<AccountDto> Add(AccountDto account)
        {
            var result = new ManagerResult<AccountDto>();
            try
            {
                if(string.IsNullOrEmpty(account.UserName))
                {
                    result.Message = "User Name is null or empty";
                    return result;

                }
                var dbUserResult = _accountManager.GetByUserName(account.UserName);
                if(dbUserResult.Success)
                {
                    result.Message = $"User with this {account.UserName} is alredy exist.";
                    return result; 
                }

                if (account.Password != account.ConfirmPassword)
                {
                    result.Message = $"Паролі не співпадають";
                    return result;
                }

                var dbResult = _accountManager.Add(_maper.Map<Account>(account));
                
                result.Success = dbResult.Success;
                result.Data = _maper.Map<AccountDto>(dbResult.Data);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }

        public ManagerResult<AccountAddressDto> Add(AccountAddressDto address)
        {
            var result = new ManagerResult<AccountAddressDto>();
            try
            {                

                var dbResult = _accountManager.Add(_maper.Map<AccountAddress>(address));

                result.Success = dbResult.Success;
                result.Data = _maper.Map<AccountAddressDto>(dbResult.Data);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }

    }
}
