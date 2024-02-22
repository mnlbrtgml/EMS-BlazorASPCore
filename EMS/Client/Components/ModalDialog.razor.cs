using EMS.Client.Services;
using EMS.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EMS.Client.Components
{
	public partial class ModalDialog
	{
		[Inject]
		IJSRuntime JSRuntime { get; set; }

		[Inject]
		IService Service { get; set; }

		[Parameter]
		public Employee Model { get; set; }

		[Parameter]
		public string Action { get; set; }

		[Parameter]
		public EventCallback Refresher { get; set; }

		private bool isVisible;
		private string status = string.Empty;
		private string description = string.Empty;

		private void BindGenderToModel(ChangeEventArgs e)
		{
			Model.EmployeeGender = (string)e.Value;
		}

		private async Task DeleteEmployee()
		{
			var response = await Service.DeleteEmployee(Model.EmployeeID);

			status = response == "SUCCESS" ? "success" : "error";
			description = response == "SUCCESS" ? "Successfully deleted the record!" : "Error in deleting the record!";
			isVisible = !isVisible;

			await Refresher.InvokeAsync();
			await UnshowModal();
			await JSRuntime.InvokeAsync<object>("toggleToastNotification");
		}

		private async Task UnshowModal()
		{
			Action = "notFromTable";
			Model = new();
			await JSRuntime.InvokeVoidAsync("unshowModal");
		}
		private async Task HandleSaving()
		{
			if (Action == "fromTable")
			{
				await Service.UpdateEmployee(Model);

				status = ValidateModel() ? "success" : "error";
				description = ValidateModel() ? "Successfully updated the record!" : "Error in updating the record!";
			}
			else
			{
				await Service.InsertEmployee(Model);

				status = ValidateModel() ? "success" : "error";
				description = ValidateModel() ? "Successfully inserted new record!" : "Error in saving new record!";
			}

			await Refresher.InvokeAsync();
			await UnshowModal();
			await JSRuntime.InvokeAsync<object>("toggleToastNotification");
		}
		private bool ValidateModel()
		{
			return Model != null &&
		   !string.IsNullOrEmpty(Model.EmployeeName) &&
		   !string.IsNullOrEmpty(Model.EmployeeAge.ToString()) &&
		   !string.IsNullOrEmpty(Model.EmployeeGender) &&
		   !string.IsNullOrEmpty(Model.EmployeeStatus) &&
		   !string.IsNullOrEmpty(Model.EmployeeDateOfBirth.ToString());
		}
	}
}
