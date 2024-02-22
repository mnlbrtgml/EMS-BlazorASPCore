using EMS.Shared.Models;

namespace EMS.Business.DomainServices.Employees
{
	public interface IJEInsert
	{
		string InsertJsonEmployee(Employee Model);
	}
}
