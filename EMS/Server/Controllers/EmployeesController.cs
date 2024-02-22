using EMS.Server.Models;
using EMS.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class EmployeesController : Controller
	{
		private readonly IMainEmployee _mainEmployee;

		public EmployeesController() => _mainEmployee = new MainEmployee();

		[HttpGet("getEmployeeList")]
		public async Task<ActionResult<List<Employee>?>> GetEmployeeList()
		{
			var result = await _mainEmployee.GetEmployees(string.Empty, string.Empty);
			return Ok(result);
		}

		[HttpGet("getEmployeeBy/{Filter}/{Value}")]
		public async Task<ActionResult<Employee>> GetEmployeeBy(string Filter, string Value)
		{
			var result = await _mainEmployee.GetEmployees(Filter, Value);
			return Ok(result);
		}

		[HttpPost("insertEmployee")]
		public async Task<ActionResult<string>> InsertEmployee([FromBody] Employee Model)
		{
			var result = await _mainEmployee.InsertEmployee(Model);
			return Ok(result);
		}

		[HttpPut("updateEmployee/{EmployeeID}")]
		public async Task<ActionResult<string>> UpdateEmployee([FromBody] Employee Model)
		{
			var result = await _mainEmployee.UpdateEmployee(Model);
			return Ok(result);
		}

		[HttpDelete("deleteEmployee/{EmployeeID}")]
		public async Task<ActionResult<string>> DeleteEmployee(int EmployeeID)
		{
			var result = await _mainEmployee.DeleteEmployee(EmployeeID);
			return Ok(result);
		}

		[HttpPost("insertJsonEmployee")]
		public async Task<ActionResult<string>> InsertJsonEmployee([FromBody] Employee Model)
		{
			var result = await _mainEmployee.InsertJsonEmployee(Model);
			return Ok(result);
		}

		[HttpPut("updateJsonEmployee/{EmployeeID}")]
		public async Task<ActionResult<string>> UpdateJsonEmployee([FromBody] Employee Model)
		{
			var result = await _mainEmployee.UpdateJsonEmployee(Model);
			return Ok(result);
		}
	}
}
