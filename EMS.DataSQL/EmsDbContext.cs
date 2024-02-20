using Microsoft.EntityFrameworkCore;

namespace EMS.DataSQL
{
	public class EmsDbContext : DbContext
	{
		public EmsDbContext(DbContextOptions<EmsDbContext> options) : base(options)
		{
			Database.SetCommandTimeout(TimeSpan.FromMinutes(30));
		}
	}
}
