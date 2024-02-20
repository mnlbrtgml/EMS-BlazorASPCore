using EMS.Shared.Models;

namespace EMS.Server.Services
{
	public interface IService
	{
		Task<Response<List<Employee>>> GetEmployeeList();

		Task<Response<List<Employee>>> GetEmployeeBy(string Filter, string Value);

		Task<Response<string>> InsertEmployee(Employee Model);

		Task<Response<string>> UpdateEmployee(Employee Model);

		Task<Response<string>> DeleteEmployee(int EmployeeID);
	}
}
