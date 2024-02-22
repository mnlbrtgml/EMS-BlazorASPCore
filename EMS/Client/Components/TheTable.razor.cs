using EMS.Client.Services;
using EMS.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EMS.Client.Components
{
	public partial class TheTable
	{
		[Inject]
		IService Service { get; set; }

		[Inject]
		IJSRuntime JSRuntime { get; set; }

		private List<Employee> Employees { get; set; } = new();

		private Employee Employee { get; set; } = new();

		private bool isFromTable = false;

		protected override async Task OnInitializedAsync() => await GetEmployeeList();

		private async Task GetEmployeeList() => Employees = await Service.GetEmployeeList();

		private async Task ShowModal(Employee Model)
		{
			Employee = Model;
			isFromTable = true;

			await JSRuntime.InvokeVoidAsync("showModal");
		}
	}
}
