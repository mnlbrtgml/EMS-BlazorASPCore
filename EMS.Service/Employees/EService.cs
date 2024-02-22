using EMS.Business.DomainServices.Employees;
using EMS.Shared.Models;

namespace EMS.Service.Employees
{
	public class EService : BaseDataAccessFactory, IEService
	{
		private readonly IEGet getEmployees;
		private readonly IEInsert insertEmployee;
		private readonly IEUpdate updateEmployee;
		private readonly IEDelete deleteEmployee;

		public EService()
		{
			getEmployees = new EGet(DataAccesses);
			insertEmployee = new EInsert(DataAccesses);
			updateEmployee = new EUpdate(DataAccesses);
			deleteEmployee = new EDelete(DataAccesses);
		}

		public List<Employee> GetEmployees(string Filter, string Value) => getEmployees.GetEmployees(Filter, Value);

		public string InsertEmployee(Employee Model) => insertEmployee.InsertEmployee(Model);

		public string UpdateEmployee(Employee Model) => updateEmployee.UpdateEmployee(Model);

		public string DeleteEmployee(int EmployeeID) => deleteEmployee.DeleteEmployee(EmployeeID);
	}
}
