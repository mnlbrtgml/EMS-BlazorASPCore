using EMS.Business.Models;
using EMS.DataSQL;
using Microsoft.Extensions.Configuration;

namespace EMS.Service
{
	public class BaseDataAccessFactory
	{
		private List<IDataAccess> _dataAccesses;

		public List<IDataAccess> DataAccesses { get { return _dataAccesses; } }

		public IConfiguration configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		private void RegisterDataAccesses()
		{
			_dataAccesses = new List<IDataAccess>();

			_dataAccesses.Add(new DLMainEms());
		}

		public BaseDataAccessFactory()
		{
			RegisterDataAccesses();
		}
	}
}
