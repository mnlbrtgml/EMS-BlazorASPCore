using EMS.Server.Common;
using EMS.Shared.Models;
using System.Data;
using System.Data.SqlClient;

namespace EMS.Server.Services
{
	public class Service : IService
	{
		private readonly ISqlQueryObject _context;

		const string SP_GetEmployees = "sp_GetEmployees";
		const string SP_InsertEmployee = "sp_InsertEmployee";
		const string SP_UpdateEmployee = "sp_UpdateEmployee";
		const string SP_DeleteEmployee = "sp_DeleteEmployee";
		const string SP_InsertJsonEmployee = "sp_InsertJsonEmployee";
		const string SP_UpdateJsonEmployee = "sp_UpdateJsonEmployee";

		public Service(ISqlQueryObject context) => _context = context;

		public async Task<Response<List<Employee>>> GetEmployeeList()
		{
			_context.ProcedureName = SP_GetEmployees;
			_context.Parameters = new SqlParameter[]
			{
				new SqlParameter("@Filter", string.Empty),
				new SqlParameter("@Value", string.Empty),
			};

			await _context.ExecuteAsync();

			if (_context.OnFailure) return null;

			var result = _context.Result
				.Tables[0]
				.AsEnumerable()
				.Select(row => new Employee()
				{
					EmployeeID = Convert.ToInt32(row["EmployeeID"]),
					EmployeeName = Convert.ToString(row["EmployeeName"]),
					EmployeeAge = Convert.ToInt32(row["EmployeeAge"]),
					EmployeeGender = Convert.ToString(row["EmployeeGender"]),
					EmployeeStatus = Convert.ToString(row["EmployeeStatus"]),
					EmployeeDateOfBirth = Convert.ToDateTime(row["EmployeeDateOfBirth"]),
				})
				.ToList();

			//DateOnly.FromDateTime((DateTime)())

			return new Response<List<Employee>>() { Data = result };
		}

		public async Task<Response<List<Employee>>> GetEmployeeBy(string Filter, string Value)
		{
			_context.ProcedureName = SP_GetEmployees;
			_context.Parameters = new SqlParameter[]
			{
				new SqlParameter("@Filter", Filter),
				new SqlParameter("@Value", Value),
			};

			await _context.ExecuteAsync();

			if (_context.OnFailure) return null;

			var result = _context.Result
				.Tables[0]
				.AsEnumerable()
				.Select(row => new Employee()
				{
					EmployeeID = Convert.ToInt32(row["EmployeeID"]),
					EmployeeName = Convert.ToString(row["EmployeeName"]),
					EmployeeAge = Convert.ToInt32(row["EmployeeAge"]),
					EmployeeGender = Convert.ToString(row["EmployeeGender"]),
					EmployeeStatus = Convert.ToString(row["EmployeeStatus"]),
					EmployeeDateOfBirth = Convert.ToDateTime(row["EmployeeDateOfBirth"]),
				})
				.ToList();

			return new Response<List<Employee>>() { Data = result };
		}

		public async Task<Response<string>> InsertEmployee(Employee Model)
		{
			_context.ProcedureName = SP_InsertEmployee;
			_context.Parameters = new SqlParameter[]
			{
				new SqlParameter("@EmployeeName", Model.EmployeeName),
				new SqlParameter("@EmployeeAge", Model.EmployeeAge),
				new SqlParameter("@EmployeeGender", Model.EmployeeGender),
				new SqlParameter("@EmployeeStatus", Model.EmployeeStatus),
				new SqlParameter("@EmployeeDateOfBirth", Model.EmployeeDateOfBirth),
			};

			await _context.ExecuteAsync();

			if (_context.OnFailure) return null;

			var row = _context.Result.Tables[0].AsEnumerable().FirstOrDefault();

			if (row == null) return null;

			return new Response<string> { Message = Convert.ToString(row["MessageCode"]) };
		}

		public async Task<Response<string>> UpdateEmployee(Employee Model)
		{
			_context.ProcedureName = SP_UpdateEmployee;
			_context.Parameters = new SqlParameter[]
			{
				new SqlParameter("@EmployeeID", Model.EmployeeID),
				new SqlParameter("@EmployeeName", Model.EmployeeName),
				new SqlParameter("@EmployeeAge", Model.EmployeeAge),
				new SqlParameter("@EmployeeGender", Model.EmployeeGender),
				new SqlParameter("@EmployeeStatus", Model.EmployeeStatus),
				new SqlParameter("@EmployeeDateOfBirth", Model.EmployeeDateOfBirth),
			};

			await _context.ExecuteAsync();

			if (_context.OnFailure) return null;

			var row = _context.Result.Tables[0].AsEnumerable().FirstOrDefault();

			if (row == null) return null;

			return new Response<string> { Message = Convert.ToString(row["MessageCode"]) };
		}

		public async Task<Response<string>> DeleteEmployee(int EmployeeID)
		{
			_context.ProcedureName = SP_DeleteEmployee;
			_context.Parameters = new SqlParameter[]
			{
				new SqlParameter("@EmployeeID", EmployeeID),
			};

			await _context.ExecuteAsync();

			if (_context.OnFailure) return null;

			var row = _context.Result.Tables[0].AsEnumerable().FirstOrDefault();

			if (row == null) return null;

			return new Response<string> { Message = Convert.ToString(row["MessageCode"]) };
		}

		public async Task<Response<string>> InsertJsonEmployee(string JData)
		{
			_context.ProcedureName = SP_InsertJsonEmployee;
			_context.Parameters = new SqlParameter[]
			{
				new SqlParameter("@JData", JData),
			};

			await _context.ExecuteAsync();

			if (_context.OnFailure) return null;

			var row = _context.Result.Tables[0].AsEnumerable().FirstOrDefault();

			if (row == null) return null;

			return new Response<string> { Message = Convert.ToString(row["MessageCode"]) };
		}

		public async Task<Response<string>> UpdateJsonEmployee(string JData)
		{
			_context.ProcedureName = SP_UpdateJsonEmployee;
			_context.Parameters = new SqlParameter[]
			{
				new SqlParameter("@JData", JData),
			};

			await _context.ExecuteAsync();

			if (_context.OnFailure) return null;

			var row = _context.Result.Tables[0].AsEnumerable().FirstOrDefault();

			if (row == null) return null;

			return new Response<string> { Message = Convert.ToString(row["MessageCode"]) };
		}
	}
}
