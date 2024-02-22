using EMS.Business.Models;
using EMS.DataSQL.Employees;

namespace EMS.DataSQL
{
	public class DLMainEms : IDataAccess, IDLMainEms
	{
		public IDLEmployees DLEmployees { get; } = new DLEmployees();
	}
}
