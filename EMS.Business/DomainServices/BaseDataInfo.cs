using EMS.Business.Models;

namespace EMS.Business.DomainServices
{
	public class BaseDataInfo
	{
		public bool IsValid { get; set; }

		private List<IDataAccess> DataAccess { get; set; }

		private IDataAccessFactory DataAccessFactory { get; set; }

		public IDLMainEms dlMainEms;

		public BaseDataInfo(List<IDataAccess> pDataAccess)
		{
			DataAccess = pDataAccess;
			DataAccessFactory = new DataAccessFactory(DataAccess);
			dlMainEms = DataAccessFactory.GetDL<IDLMainEms>();
		}

		public BaseDataInfo(IDataAccessFactory pDataFactory)
		{
			DataAccessFactory = pDataFactory;
			DataAccess = DataAccessFactory.DataAccess;
			dlMainEms = DataAccessFactory.GetDL<IDLMainEms>();
		}

		public BaseDataInfo() { }
	}
}
