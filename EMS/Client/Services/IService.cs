using EMS.Shared.Models;

namespace EMS.Client.Services
{
	public interface IService
	{
		Task<List<Employee>?> GetEmployeeList();

		Task<List<Employee>?> GetEmployeeBy(string Filter, string Value);

		Task<string> InsertEmployee(Employee Model);

		Task<string> UpdateEmployee(Employee Model);

		Task<string> DeleteEmployee(int EmployeeID);
	}
}
