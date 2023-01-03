using MongoDB.Driver;


namespace o9.EmployeesAPI.Repository;

public class EmployeesRepository: IEmployeesRepository
{
	private readonly IMongoCollection<Models.Employee> _mongoEmployeeCollection;

	public EmployeesRepository(IMongoDatabase mongoDatabase)
	{
		_mongoEmployeeCollection = mongoDatabase.GetCollection<Models.Employee>("Employees");
	}

	public async Task<List<Models.Employee>> GetAllAsync()
	{
		return await _mongoEmployeeCollection.Find(_ => true).ToListAsync();
	}

	public async Task<Models.Employee> GetByIdAsync(string id)
	{
		return (await _mongoEmployeeCollection.FindAsync(x => x.Id == id)).FirstOrDefault();
	}

	public async Task CreateAsync(Models.Employee newEmployee)
	{

		 await _mongoEmployeeCollection.InsertOneAsync(newEmployee);
	}

	public async Task UpdateAsync(Models.Employee employeeToUpdate)
	{
		await _mongoEmployeeCollection.ReplaceOneAsync(_ => _.Id == employeeToUpdate.Id, employeeToUpdate);
	}

	public async Task DeleteAsync(string id)
	{
		await _mongoEmployeeCollection.DeleteOneAsync(_ => _.Id == id);
	}
}
