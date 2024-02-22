using Microsoft.AspNetCore.Components;

namespace EMS.Client.Components
{
	public partial class ToastNotification
	{
		[Parameter]
		public bool Trigger { get; set; }

		[Parameter]
		public string Status { get; set; } = string.Empty;

		[Parameter]
		public string Description { get; set; } = string.Empty;

		private static readonly string[] StatusType = { "info", "success", "warning", "error" };

		private bool IsStatusValid() => StatusType.Contains(Status);

		protected override void OnInitialized()
		{
			Task.Run(async () =>
			{
				await Task.Delay(1000);
				Trigger = false;
				StateHasChanged();
			});
		}
	}
}
