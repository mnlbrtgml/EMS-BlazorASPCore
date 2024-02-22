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
		private readonly IJEInsert insertJsonEmployee;
		private readonly IJEUpdate updateJsonEmployee;

		public EService()
		{
			getEmployees = new EGet(DataAccesses);
			insertEmployee = new EInsert(DataAccesses);
			updateEmployee = new EUpdate(DataAccesses);
			deleteEmployee = new EDelete(DataAccesses);
			insertJsonEmployee = new JEInsert(DataAccesses);
			updateJsonEmployee = new JEUpdate(DataAccesses);
		}

		public List<Employee> GetEmployees(string Filter, string Value) => getEmployees.GetEmployees(Filter, Value);

		public string InsertEmployee(Employee Model) => insertEmployee.InsertEmployee(Model);

		public string UpdateEmployee(Employee Model) => updateEmployee.UpdateEmployee(Model);

		public string DeleteEmployee(int EmployeeID) => deleteEmployee.DeleteEmployee(EmployeeID);

		public string InsertJsonEmployee(Employee Model) => insertJsonEmployee.InsertJsonEmployee(Model);

		public string UpdateJsonEmployee(Employee Model) => updateJsonEmployee.UpdateJsonEmployee(Model);
	}
}
