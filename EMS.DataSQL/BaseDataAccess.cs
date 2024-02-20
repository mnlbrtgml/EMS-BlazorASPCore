using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EMS.DataSQL
{
	public class BaseDataAccess
	{
		public DbContextOptionsBuilder<EmsDbContext> builder = new();

		public IConfiguration configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		public BaseDataAccess()
		{
			builder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
		}
	}
}
