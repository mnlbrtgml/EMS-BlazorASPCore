using EMS.Shared.Models;

namespace EMS.Business.DomainServices.Employees
{
	public interface IEGet
	{
		List<Employee> GetEmployeeList(string Filter, string Value);
	}
}
