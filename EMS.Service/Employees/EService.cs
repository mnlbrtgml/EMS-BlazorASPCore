using EMS.Business.DomainServices.Employees;
using EMS.Shared.Models;

namespace EMS.Service.Employees
{
	public class EService : BaseDataAccessFactory, IEService
	{
		private readonly IEGet employeeList;
		private readonly IEGet employeeBy;
		private readonly IEInsert insertEmployee;
		private readonly IEUpdate updateEmployee;
		private readonly IEDelete deleteEmployee;

		public EService()
		{
			employeeList = new EGet(DataAccesses);
			employeeBy = new EGet(DataAccesses);
			insertEmployee = new EInsert(DataAccesses);
			updateEmployee = new EUpdate(DataAccesses);
			deleteEmployee = new EDelete(DataAccesses);
		}

		public List<Employee> GetEmployeeList() => employeeList.GetEmployeeList(string.Empty, string.Empty);

		public List<Employee> GetEmployeeBy(string Filter, string Value) => employeeBy.GetEmployeeList(Filter, Value);

		public string InsertEmployee(Employee Model) => insertEmployee.InsertEmployee(Model);

		public string UpdateEmployee(Employee Model) => updateEmployee.UpdateEmployee(Model);

		public string DeleteEmployee(int EmployeeID) => deleteEmployee.DeleteEmployee(EmployeeID);
	}
}
