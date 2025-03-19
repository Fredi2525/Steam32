﻿using AutoMapper;
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
    }
}
