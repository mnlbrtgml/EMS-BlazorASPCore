using EMS.Business.Models;

namespace EMS.Business.DomainServices.Employees
{
	public class Base : BaseDataInfo
	{
		public IDLEmployees DLEmployees { get { return dlMainEms.DLEmployees; } }

		public Base(List<IDataAccess> pDataAccess) : base(pDataAccess) { }

		public Base() { }
	}
}
