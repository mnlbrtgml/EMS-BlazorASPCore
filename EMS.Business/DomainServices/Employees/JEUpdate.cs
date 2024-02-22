using EMS.Business.Models;
using EMS.Shared.Models;
using System.Text.Json;

namespace EMS.Business.DomainServices.Employees
{
	public class JEUpdate : Base, IJEUpdate
	{
		private string _messageCode = string.Empty;
		private string _json;

		public JEUpdate(List<IDataAccess> pDataAccess) : base(pDataAccess)
		{
			_json = string.Empty;
		}

		public string UpdateJsonEmployee(Employee Model)
		{
			_json = JsonSerializer.Serialize(Model);

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

			_messageCode = DLEmployees.UpdateJsonEmployee(_json);
		}
	}
}
