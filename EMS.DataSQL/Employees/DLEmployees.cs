using BlazorCrudPractice.DataSQL;
using EMS.Business.Models;
using EMS.Shared.Models;
using System.Data;
using System.Data.Common;

namespace EMS.DataSQL.Employees
{
	public class DLEmployees : BaseDataAccess, IDLEmployees
	{
		const string SP_GetEmployees = "sp_GetEmployees";
		const string SP_InsertEmployee = "sp_InsertEmployee";
		const string SP_UpdateEmployee = "sp_UpdateEmployee";
		const string SP_DeleteEmployee = "sp_DeleteEmployee";

		public List<Employee> GetEmployeeList()
		{
			IList<Employee> result = new List<Employee>();

			using (var connection = new EmsDbContext(builder.Options))
			{
				connection.LoadStoredProc(SP_GetEmployees)
					.WithSqlParam("@Filter", string.Empty)
					.WithSqlParam("@Value", string.Empty)
					.ExecuteStoredProc(handler => result = handler.ReadToList<Employee>());
			}

			return result.ToList();
		}

		public List<Employee> GetEmployeeBy(string Filter, string Value)
		{
			IList<Employee> result = new List<Employee>();

			using (var connection = new EmsDbContext(builder.Options))
			{
				connection.LoadStoredProc(SP_GetEmployees)
					.WithSqlParam("@Filter", Filter)
					.WithSqlParam("@Value", Value)
					.ExecuteStoredProc(handler => result = handler.ReadToList<Employee>());
			}

			return result.ToList();
		}

		public string InsertEmployee(Employee Model)
		{
			DbParameter result = null;

			using (var connection = new EmsDbContext(builder.Options))
			{
				connection.LoadStoredProc(SP_InsertEmployee)
					.WithSqlParam("@EmployeeName", Model.EmployeeName)
					.WithSqlParam("@EmployeeGender", Model.EmployeeGender)
					.WithSqlParam("@EmployeeAge", Model.EmployeeAge)
					.WithSqlParam("@EmployeeStatus", Model.EmployeeStatus)
					.WithSqlParam("@EmployeeDateOfBirth", Model.EmployeeDateOfBirth)
					.WithSqlParam("@MessageCode", param =>
					{
						param.Direction = ParameterDirection.Output;
						param.DbType = DbType.String;
						param.Size = 150;
						result = param;
					})
					.ExecuteStoredProc(_ => { });
			}

			return (string)result.Value;
		}

		public string UpdateEmployee(Employee Model)
		{
			DbParameter result = null;

			using (var connection = new EmsDbContext(builder.Options))
			{
				connection.LoadStoredProc(SP_UpdateEmployee)
					.WithSqlParam("@EmployeeID", Model.EmployeeID)
					.WithSqlParam("@EmployeeName", Model.EmployeeName)
					.WithSqlParam("@EmployeeGender", Model.EmployeeGender)
					.WithSqlParam("@EmployeeAge", Model.EmployeeAge)
					.WithSqlParam("@EmployeeStatus", Model.EmployeeStatus)
					.WithSqlParam("@EmployeeDateOfBirth", Model.EmployeeDateOfBirth)
					.WithSqlParam("@MessageCode", param =>
					{
						param.Direction = ParameterDirection.Output;
						param.DbType = DbType.String;
						param.Size = 150;
						result = param;
					})
					.ExecuteStoredProc(_ => { });
			}

			return (string)result.Value;
		}

		public string DeleteEmployee(int EmployeeID)
		{
			DbParameter result = null;

			using (var connection = new EmsDbContext(builder.Options))
			{
				connection.LoadStoredProc(SP_DeleteEmployee)
					.WithSqlParam("@EmployeeID", EmployeeID)
					.WithSqlParam("@MessageCode", parameter =>
					{
						parameter.Direction = ParameterDirection.Output;
						parameter.DbType = DbType.String;
						parameter.Size = 150;
						result = parameter;
					})
					.ExecuteStoredProc(_ => { });
			}

			return (string)result.Value;
		}
	}
}
