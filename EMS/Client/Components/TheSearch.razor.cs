namespace EMS.Client.Components
{
	public partial class TheSearch
	{
		private bool isVisible = false;
		private string selected = "Name";

		private void ToggleDropdown()
		{
			isVisible = !isVisible;
		}

		private void SelectItem(string Item)
		{
			selected = Item;
			ToggleDropdown();
		}
	}
}
