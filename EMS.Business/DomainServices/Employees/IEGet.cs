using EMS.Shared.Models;

namespace EMS.Business.DomainServices.Employees
{
	public interface IEGet
	{
		List<Employee> GetEmployees(string Filter, string Value);
	}
}
