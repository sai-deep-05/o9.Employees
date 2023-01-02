using o9.EmployeesAPI.Models;

namespace o9.EmployeesAPI.Services
{
	public interface IEmployeeServices
	{
		Task<List<Employee>> GetAllAsync();

		Task<Employee> GetByIdAsync(string id);

		Task CreateAsync(Employee newEmployee);

		Task UpdateAsync(Employee employeeToUpdate);
		
		Task DeleteAsync(string id);
	}
}
