using EMS.Business.Models;
using EMS.Shared.Models;

namespace EMS.Business.DomainServices.Employees
{
	public class EGet : Base, IEGet
	{
		private List<Employee> employeeList;
		private string _filter = string.Empty;
		private string _value = string.Empty;

		public EGet(List<IDataAccess> pDataAccess) : base(pDataAccess)
		{
			employeeList = new();
		}

		public List<Employee> GetEmployees(string Filter, string Value)
		{
			_filter = Filter;
			_value = Value;

			Validation();
			Initialize();

			return employeeList;
		}

		private void Validation()
		{
			IsValid = false;

			if (employeeList != null) IsValid = true;
		}

		private void Initialize()
		{
			if (!IsValid) return;

			employeeList = DLEmployees.GetEmployees(_filter, _value);
		}
	}
}
