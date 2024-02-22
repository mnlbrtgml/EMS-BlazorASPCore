using EMS.Client.Services;
using EMS.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EMS.Client.Pages
{
	public partial class Index
	{
		[Inject]
		IService Service { get; set; }

		[Inject]
		IJSRuntime JSRuntime { get; set; }

		public List<Employee> Employees { get; set; } = new();

		public bool IsProceed { get; set; } = false;

		public string MessageCode { get; set; } = string.Empty;

		private async Task ShowModal()
		{
			await JSRuntime.InvokeVoidAsync("showModal");
		}

		//protected override async Task OnInitializedAsync()
		//{
		//	await GetEmployeeList();
		//}

		//private async Task GetEmployeeList()
		//{
		//	Employees = await Service.GetEmployeeList();
		//}

		//private async Task GetEmployeeBy(string Filter, string Value)
		//{
		//	Employees = await Service.GetEmployeeBy(Filter, Value);
		//}

		//private void InsertEmployee()
		//{
		//	isSuccess = !isSuccess;
		//}
	}
}
