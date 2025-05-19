using Entities.Account;
using Entities.Games;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class SteamDbContext : DbContext
	{
		public SteamDbContext(DbContextOptions<SteamDbContext> options) : base(options)
		{ }

		 public virtual DbSet<Account> Accounts { get; set; }       
         public virtual DbSet<AccountAddress> AccountAddresses { get; set; }
        public virtual DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}
	}
}
