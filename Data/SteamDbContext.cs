using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class SteamDbContext : DbContext
	{
		public SteamDbContext(DbContextOptions<SteamDbContext> options) : base(options)
		{ }

		//public virtual DbSet<Account> Accounts { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}
	}
}
