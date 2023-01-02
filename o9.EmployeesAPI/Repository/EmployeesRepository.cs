using MongoDB.Driver;
using o9.EmployeesAPI.Models;

namespace o9.EmployeesAPI.Repository;

public class EmployeesRepository: IEmployeesRepository
{
	private readonly IMongoCollection<Employee> _mongoEmployeeCollection;

	public EmployeesRepository(IMongoDatabase mongoDatabase)
	{
		_mongoEmployeeCollection = mongoDatabase.GetCollection<Employee>("Employees");
	}

	public async Task<List<Employee>> GetAllAsync()
	{
		return await _mongoEmployeeCollection.Find(_ => true).ToListAsync();
	}

	public async Task<Employee> GetByIdAsync(string id)
	{
		return await _mongoEmployeeCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
	}

	public async Task CreateAsync(Employee newEmployee)
	{
		 await _mongoEmployeeCollection.InsertOneAsync(newEmployee);
	}

	public async Task UpdateAsync(Employee employeeToUpdate)
	{
		await _mongoEmployeeCollection.ReplaceOneAsync(_ => _.Id == employeeToUpdate.Id, employeeToUpdate);
	}

	public async Task DeleteAsync(string id)
	{
		await _mongoEmployeeCollection.DeleteOneAsync(_ => _.Id == id);
	}
}
