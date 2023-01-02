using o9.EmployeesAPI.Models;

namespace o9.EmployeesAPI.Repository;

public interface IEmployeesRepository
{
	Task<List<Employee>> GetAllAsync();

	Task<Employee> GetByIdAsync(string id);

	Task CreateAsync(Employee newEmployee);

	Task UpdateAsync(Employee employeeToUpdate);

	Task DeleteAsync(string id);
}
