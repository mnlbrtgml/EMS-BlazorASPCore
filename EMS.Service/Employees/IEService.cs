using EMS.Shared.Models;

namespace EMS.Service.Employees
{
	public interface IEService
	{
		List<Employee> GetEmployees(string Filter, string Value);

		string InsertEmployee(Employee Model);

		string UpdateEmployee(Employee Model);

		string DeleteEmployee(int EmployeeID);

		string InsertJsonEmployee(Employee Model);

		string UpdateJsonEmployee(Employee Model);
	}
}
