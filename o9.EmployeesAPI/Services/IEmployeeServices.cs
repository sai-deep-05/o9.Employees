//using o9.EmployeesAPI.Models;
//using o9.EmployeesAPI.DTO_Models;

namespace o9.EmployeesAPI.Services
{
	public interface IEmployeeServices
	{
		Task<List<DTO_Models.EmployeeDTO>> GetAllAsync();

		Task<DTO_Models.EmployeeDTO> GetByIdAsync(string id);

		Task CreateAsync(DTO_Models.EmployeeDTO newEmployee);

		Task UpdateAsync(DTO_Models.EmployeeDTO employeeToUpdate);
		
		Task DeleteAsync(string id);
	}
}
