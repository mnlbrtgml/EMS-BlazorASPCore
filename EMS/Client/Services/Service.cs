using EMS.Shared.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;

namespace EMS.Client.Services
{
	public class Service : BaseService, IService
	{
		private const string baseUri = "api/employees";

		public Service(HttpClient pHttpClient) : base(pHttpClient) { }

		public async Task<List<Employee>?> GetEmployeeList()
		{
			var response = await httpClient.GetAsync($"{baseUri}/getEmployeeList");

			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<Employee>?>(result);
		}

		public async Task<List<Employee>?> GetEmployeeBy(string Filter, string Value)
		{
			var response = await httpClient.GetAsync($"{baseUri}/getEmployeeBy/{Filter}/{Value}");

			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<Employee>?>(result);
		}

		public async Task<string> InsertEmployee(Employee Model)
		{
			var serialized = JsonConvert.SerializeObject(Model);
			var data = new StringContent(serialized, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync($"{baseUri}/insertEmployee", data);

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsStringAsync();
		}

		public async Task<string> UpdateEmployee(Employee Model)
		{
			var serialized = JsonConvert.SerializeObject(Model);
			var data = new StringContent(serialized, Encoding.UTF8, "application/json");
			var response = await httpClient.PutAsync($"{baseUri}/updateEmployee/{Model.EmployeeID}", data);

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsStringAsync();
		}

		public async Task<string> DeleteEmployee(int EmployeeID)
		{
			var response = await httpClient.DeleteAsync($"{baseUri}/deleteEmployee/{EmployeeID}");

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsStringAsync();
		}

		public async Task<string> InsertJsonEmployee(Employee Model)
		{
			var serialized = JsonConvert.SerializeObject(Model);
			var data = new StringContent(serialized, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync($"{baseUri}/insertJsonEmployee", data);

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsStringAsync();
		}
	}
}
