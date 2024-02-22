using System.ComponentModel.DataAnnotations;

namespace EMS.Shared.Models
{
	public class Employee
	{
		public int EmployeeID { get; set; }

		[Required]
		public string EmployeeName { get; set; } = string.Empty;

		[Required]
		public int EmployeeAge { get; set; } = 18;

		[Required]
		public string EmployeeGender { get; set; } = "Male";

		[Required]
		public string EmployeeStatus { get; set; } = "Active";

		[Required]
		//public DateOnly? EmployeeDateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public DateTime EmployeeDateOfBirth { get; set; } = DateTime.Now;
	}
}
