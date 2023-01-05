using Microsoft.AspNetCore.Mvc;
using o9.EmployeesAPI.Models;
using o9.EmployeesAPI.Services;
using o9.EmployeesAPI.DTO_Models;

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

		public async Task<ActionResult<EmployeeDTO>> Get()
		{
			var employees=await _employeeServices.GetAllAsync();
			return Ok(employees);
		}

		[HttpGet]
		[Route("{id}")]

		public async Task<IActionResult> Get(string id)
		{
			var employee = await _employeeServices.GetByIdAsync(id);
			return Ok(employee);
		}

		[HttpPost]
		public async Task<IActionResult> Post(EmployeeDTO newEmployee)
		{
			EmployeeDTO emp = new EmployeeDTO();
		    await _employeeServices.CreateAsync(newEmployee);
			return CreatedAtAction(nameof(Get),new {id=newEmployee.Id},newEmployee);
			//return Ok();
			
		}

		[HttpPut]
		public async Task<IActionResult> Put(EmployeeDTO employeeToUpdate)
		{
			var employeeid=await _employeeServices.GetByIdAsync(employeeToUpdate.Id);
			if(employeeid==null)
				return NotFound();

			await _employeeServices.UpdateEmployeeDataAsync(employeeToUpdate);
			//return CreatedAtAction( nameof(Get),new { id = employeeToUpdate.Id },employeeToUpdate);
			//return Ok();
			return Created("",employeeToUpdate);
		}

		[HttpDelete]

		public async Task<IActionResult> Delete(string id)
		{
			var employeeid = _employeeServices.GetByIdAsync(id);
			if(employeeid==null)
				return NotFound("Invalid key");
			await _employeeServices.DeleteAsync(id);
			return NoContent();
		}

	}
}
