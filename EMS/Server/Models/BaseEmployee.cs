namespace EMS.Server.Models
{
	public class BaseEmployee
	{
		public IConfiguration configuration = new ConfigurationBuilder()
			.SetBasePath(Directory
			.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		public bool IsValid { get; set; }

		public BaseEmployee() { }
	}
}
