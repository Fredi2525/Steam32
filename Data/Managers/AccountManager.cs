using Data.Managers.Interfaces;
using Entities.Account;
using Microsoft.Extensions.DependencyInjection;
using Models.Managers;

namespace Data.Managers
{
    public class AccountManager : IAccountManager
    {
	    private readonly IServiceProvider _service;

	    public AccountManager(IServiceProvider service)
	    {
			_service = service;
	    }

		public ManagerResult<Account> Add(Account account)
		{
			var result = new ManagerResult<Account>();
			try
			{
				var dbContext = _service.GetRequiredService<SteamDbContext>();

				account.Created = DateTime.Now;

				dbContext.Accounts.Add(account);
				dbContext.SaveChanges();
				result.Data = account;
				result.Success = true;
			}
			catch (Exception e)
			{
				result.Message = e.Message;
			}
			return result;
		}
        public ManagerResult<AccountAddress> Add(AccountAddress address)
        {
            var result = new ManagerResult<AccountAddress>();
            try
            {
                var dbContext = _service.GetRequiredService<SteamDbContext>();

                address.Created = DateTime.Now;

                dbContext.AccountAddresses.Add(address);
                dbContext.SaveChanges();
                result.Data = address;
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }

        public ManagerResult<Account> GetByUserName(string email)
		{
			var result = new ManagerResult<Account>();

            var dbContext = _service.GetRequiredService<SteamDbContext>();

			var account = dbContext.Accounts.FirstOrDefault(x=>x.UserName == email);
			if (account == null)
			{
				result.Message = "Account not foud";
				return result;
			}

			result.Data = account;
			result.Success = true;

            return result;


		}

        
    }
}
