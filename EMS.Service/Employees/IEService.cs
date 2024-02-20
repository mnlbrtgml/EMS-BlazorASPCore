using EMS.Shared.Models;

namespace EMS.Service.Employees
{
	public interface IEService
	{
		List<Employee> GetEmployeeList();

		List<Employee> GetEmployeeBy(string Filter, string Value);

		string InsertEmployee(Employee Model);

		string UpdateEmployee(Employee Model);

		string DeleteEmployee(int EmployeeID);
	}
}
