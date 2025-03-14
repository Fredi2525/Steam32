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
	}
}
