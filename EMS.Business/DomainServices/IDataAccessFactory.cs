using EMS.Business.Models;

namespace EMS.Business.DomainServices
{
	public interface IDataAccessFactory
	{
		List<IDataAccess> DataAccess { get; set; }

		T GetDL<T>();
	}
}
