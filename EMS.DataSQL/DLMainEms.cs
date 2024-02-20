using EMS.Business.Models;
using EMS.DataSQL.Employees;

namespace EMS.DataSQL
{
	public class DLMainEms : IDataAccess, IDLMainEms
	{
		private IDLEmployees _dlEmployees = new DLEmployees();

		public IDLEmployees DLEmployees { get { return _dlEmployees; } }
	}
}
