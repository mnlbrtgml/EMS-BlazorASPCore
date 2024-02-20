using EMS.Business.Models;
using EMS.Shared.Models;

namespace EMS.Business.DomainServices.Employees
{
	public class EUpdate : Base, IEUpdate
	{
		private string _messageCode = string.Empty;

		private Employee? _model;

		public EUpdate(List<IDataAccess> pDataAccess) : base(pDataAccess)
		{
			_model = new();
		}

		public string UpdateEmployee(Employee Model)
		{
			_model = Model;

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

			_messageCode = DLEmployees.UpdateEmployee(_model);
		}
	}
}
