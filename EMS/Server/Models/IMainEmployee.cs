using EMS.Shared.Models;

namespace EMS.Server.Models
{
	public interface IMainEmployee
	{
		Task<List<Employee>> GetEmployeeList();

		Task<List<Employee>> GetEmployeeBy(string Filter, string Value);

		Task<string> InsertEmployee(Employee Model);

		Task<string> UpdateEmployee(Employee Model);
		
		Task<string> DeleteEmployee(int EmployeeID);
	}
}
