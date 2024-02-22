using BlazorCrudPractice.DataSQL;
using EMS.Business.Models;
using EMS.Shared.Models;
using System.Data;
using System.Data.Common;

namespace EMS.DataSQL.Employees
{
	public class DLEmployees : BaseDataAccess, IDLEmployees
	{
		private const string SP_GetEmployees = "sp_GetEmployees";
		private const string SP_InsertEmployee = "sp_InsertEmployee";
		private const string SP_UpdateEmployee = "sp_UpdateEmployee";
		private const string SP_DeleteEmployee = "sp_DeleteEmployee";

		public List<Employee> GetEmployees(string Filter, string Value)
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
			DbParameter? result = null;

			using (var connection = new EmsDbContext(builder.Options))
			{
				connection.LoadStoredProc(SP_InsertEmployee)
					.WithSqlParam("@EmployeeName", Model.EmployeeName)
					.WithSqlParam("@EmployeeAge", Model.EmployeeAge)
					.WithSqlParam("@EmployeeGender", ParseGender(Model.EmployeeGender))
					.WithSqlParam("@EmployeeStatus", ParseStatus(Model.EmployeeStatus))
					.WithSqlParam("@EmployeeDateOfBirth", Model.EmployeeDateOfBirth)
					.WithSqlParam("@MessageCode", output =>
					{
						output.Direction = ParameterDirection.Output;
						output.DbType = DbType.String;
						output.Size = 150;
						result = output;
					})
					.ExecuteStoredProc(_ => { });
			}

			return (string)result.Value;
		}

		public string UpdateEmployee(Employee Model)
		{
			DbParameter? result = null;

			using (var connection = new EmsDbContext(builder.Options))
			{
				connection.LoadStoredProc(SP_UpdateEmployee)
					.WithSqlParam("@EmployeeID", Model.EmployeeID)
					.WithSqlParam("@EmployeeName", Model.EmployeeName)
					.WithSqlParam("@EmployeeAge", Model.EmployeeAge)
					.WithSqlParam("@EmployeeGender", ParseGender(Model.EmployeeGender))
					.WithSqlParam("@EmployeeStatus", ParseStatus(Model.EmployeeStatus))
					.WithSqlParam("@EmployeeDateOfBirth", Model.EmployeeDateOfBirth)
					.WithSqlParam("@MessageCode", output =>
					{
						output.Direction = ParameterDirection.Output;
						output.DbType = DbType.String;
						output.Size = 150;
						result = output;
					})
					.ExecuteStoredProc(_ => { });
			}

			return (string)result.Value;
		}

		public string DeleteEmployee(int EmployeeID)
		{
			DbParameter? result = null;

			using (var connection = new EmsDbContext(builder.Options))
			{
				connection.LoadStoredProc(SP_DeleteEmployee)
					.WithSqlParam("@EmployeeID", EmployeeID)
					.WithSqlParam("@MessageCode", output =>
					{
						output.Direction = ParameterDirection.Output;
						output.DbType = DbType.String;
						output.Size = 150;
						result = output;
					})
					.ExecuteStoredProc(_ => { });
			}

			return (string)result.Value;
		}

		private int ParseStatus(string Status) => Status == "Active" ? 1 : 0;

		private char ParseGender(string Gender) => Convert.ToChar(Gender[0]);
	}
}
