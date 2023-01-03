using o9.EmployeesAPI.Models;

namespace o9.EmployeesAPI.Repository;

public interface IEmployeesRepository
{
	Task<List<Models.Employee>> GetAllAsync();

	Task<Models.Employee> GetByIdAsync(string id);

	Task CreateAsync(Models.Employee newEmployee);

	Task UpdateAsync(Models.Employee employeeToUpdate);

	Task DeleteAsync(string id);
}
