using EMS.Shared.Models;

namespace EMS.Business.Models
{
	public interface IDLEmployees
	{
		List<Employee> GetEmployees(string Filter, string Value);

		string InsertEmployee(Employee Model);

		string UpdateEmployee(Employee Model);

		string DeleteEmployee(int EmployeeID);

		string InsertJsonEmployee(string JData);

		string UpdateJsonEmployee(string JData);
	}
}
