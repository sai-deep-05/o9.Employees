using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using o9.EmployeesAPI.Models;
using o9.EmployeesAPI.Repository;
using o9.EmployeesAPI.Services;

namespace o9.EmployeesAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeServices _employeeServices;
		public EmployeeController(IEmployeeServices employeeServices)
		{
			_employeeServices = employeeServices;
		}

		[HttpGet]

		public async Task<ActionResult<Employee>> Get()
		{
			var employee=await _employeeServices.GetAllAsync();
			return Ok(employee);
		}

		[HttpGet]
		[Route("{id}")]

		public async Task<IActionResult> Get(string id)
		{
			var employee = await _employeeServices.GetByIdAsync(id);
			return Ok(employee);
		}

		[HttpPost]
		public async Task<IActionResult> Post(Employee newEmployee)
		{
			//String[] Names = newEmployee.EmployeeName.Split(" ");
			//if(Names.Length<2)
			//	return Content("Full Name not entered");
			//newEmployee.FirstName= Names[0];
			//newEmployee.LastName= Names[1];
			await _employeeServices.CreateAsync(newEmployee);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Put(Employee employeeToUpdate)
		{
			var employeeid=await _employeeServices.GetByIdAsync(employeeToUpdate.Id);
			if(employeeid==null)
				return NotFound();

			await _employeeServices.UpdateAsync(employeeToUpdate);
			return NoContent();
		}

		[HttpDelete]

		public async Task<IActionResult> Delete(string id)
		{
			var employeeid = _employeeServices.GetByIdAsync(id);
			if(employeeid==null)
				return NotFound();
			await _employeeServices.DeleteAsync(id);
			return NoContent();
		}

	}
}
