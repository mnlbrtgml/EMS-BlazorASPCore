using EMS.Business.Models;

namespace EMS.Business.DomainServices.Employees
{
	public class EDelete : Base, IEDelete
	{
		private string _messageCode = string.Empty;
		private int _id;

		public EDelete(List<IDataAccess> pDataAccess) : base(pDataAccess) { }

		public string DeleteEmployee(int EmployeeID)
		{
			_id = EmployeeID;

			Validation();
			Initialize();

			return _messageCode;
		}

		private void Validation()
		{
			IsValid = false;

			if (_messageCode != null) IsValid = true;
		}

		private void Initialize()
		{
			if (!IsValid) return;

			_messageCode = DLEmployees.DeleteEmployee(_id);
		}
	}
}
