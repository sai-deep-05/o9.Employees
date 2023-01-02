using MongoDB.Driver;
using o9.EmployeesAPI.Models;
using o9.EmployeesAPI.Repository;

namespace o9.EmployeesAPI.Services
{
	public class EmployeeServices : IEmployeeServices
	{
		private readonly IEmployeesRepository _employeeRepository;

		public EmployeeServices(IEmployeesRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public async Task<List<Employee>> GetAllAsync()
		{
			return await _employeeRepository.GetAllAsync();
		}

		public async Task<Employee> GetByIdAsync(string id)
		{
			return await _employeeRepository.GetByIdAsync(id);
		}

		public async Task CreateAsync(Employee newEmployee)
		{

			await _employeeRepository.CreateAsync(newEmployee);
		}

		public async Task UpdateAsync(Employee employeeToUpdate)
		{
			await _employeeRepository.UpdateAsync(employeeToUpdate);
		}

		public async Task DeleteAsync(string id)
		{
			await _employeeRepository.DeleteAsync(id);


		}
	}
}
