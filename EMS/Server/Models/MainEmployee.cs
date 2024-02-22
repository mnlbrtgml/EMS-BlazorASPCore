using EMS.Service.Employees;
using EMS.Shared.Models;

namespace EMS.Server.Models
{
	public class MainEmployee : BaseEmployee, IMainEmployee
	{
		private readonly IEService employeeService;

		public MainEmployee() => employeeService = new EService();

		public async Task<List<Employee>> GetEmployees(string Filter, string Value) => employeeService.GetEmployees(Filter, Value);

		public async Task<string> InsertEmployee(Employee Model) => employeeService.InsertEmployee(Model);

		public async Task<string> UpdateEmployee(Employee Model) => employeeService.UpdateEmployee(Model);

		public async Task<string> DeleteEmployee(int EmployeeID) => employeeService.DeleteEmployee(EmployeeID);
	}
}
