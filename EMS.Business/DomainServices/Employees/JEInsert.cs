using EMS.Business.Models;
using EMS.Shared.Models;
using System.Text.Json;

namespace EMS.Business.DomainServices.Employees
{
	public class JEInsert : Base, IJEInsert
	{
		private string _messageCode = string.Empty;
		private string _json;

		public JEInsert(List<IDataAccess> pDataAccess) : base(pDataAccess)
		{
			_json = string.Empty;
		}

		public string InsertJsonEmployee(Employee Model)
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

			_messageCode = DLEmployees.InsertJsonEmployee(_json);
		}
	}
}
