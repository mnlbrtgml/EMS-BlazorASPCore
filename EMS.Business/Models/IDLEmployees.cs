﻿using EMS.Shared.Models;

namespace EMS.Business.Models
{
	public interface IDLEmployees
	{
		List<Employee> GetEmployeeList();

		List<Employee> GetEmployeeBy(string Filter, string Value);

		string InsertEmployee(Employee Model);

		string UpdateEmployee(Employee Model);

		string DeleteEmployee(int Id);
	}
}
