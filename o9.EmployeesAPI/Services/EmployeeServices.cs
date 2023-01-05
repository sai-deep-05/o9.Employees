
using o9.EmployeesAPI.Models;
using o9.EmployeesAPI.Repository;
using o9.EmployeesAPI.DTO_Models;


namespace o9.EmployeesAPI.Services
{
	public class EmployeeServices : IEmployeeServices
	{
		private readonly IEmployeesRepository _employeeRepository;
		

		public EmployeeServices(IEmployeesRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}


		public async Task<List<DTO_Models.EmployeeDTO>> GetAllAsync()
		{
			
			
			 var employees= await _employeeRepository.GetAllAsync();
			 var employeeDTOs= new List<EmployeeDTO>();
			if (employees != null)
			{
				foreach (Employee employee in employees)
				{
					EmployeeDTO empDTO = new EmployeeDTO();
					empDTO.EmployeeName = employee.FirstName + " " + employee.LastName;
					empDTO.EmployeeId = employee.EmployeeId;
					empDTO.Id = employee.Id;
					empDTO.Department = employee.Department;
					employeeDTOs.Add(empDTO);
				}
			}
			
			return employeeDTOs;
		}

		public async Task<DTO_Models.EmployeeDTO> GetByIdAsync(string id)
		{
			Employee employee= await _employeeRepository.GetByIdAsync(id);
			if (employee == null)
				return null;
			EmployeeDTO empDTO= new EmployeeDTO();
			empDTO.EmployeeName = employee.FirstName +" "+ employee.LastName;
			empDTO.EmployeeId = employee.EmployeeId;
			empDTO.Id = employee.Id;
			empDTO.Department= employee.Department;
			return empDTO;

		}

		public async Task CreateAsync(DTO_Models.EmployeeDTO newEmployee)
		{
			Employee employee = new Employee();
			String[] Names = newEmployee.EmployeeName.Split(" ");
			if (Names.Length < 2)
				return;
			//employee.Id= newEmployee.Id;
			employee.EmployeeId= newEmployee.EmployeeId;
			employee.FirstName= Names[0];
			employee.LastName= Names[1];
			employee.Department=newEmployee.Department;
			await _employeeRepository.CreateAsync(employee);

			// use call backs
			
		}

		public async Task UpdateEmployeeDataAsync(DTO_Models.EmployeeDTO employeeToUpdate)
		{
			Employee employee = new Employee();
			String[] Names = employeeToUpdate.EmployeeName.Split(" ");
			if (Names.Length < 2)
				return;
			employee.Id = employeeToUpdate.Id;
			employee.EmployeeId = employeeToUpdate.EmployeeId;
			employee.FirstName = Names[0];
			employee.LastName = Names[1];
			employee.Department = employeeToUpdate.Department;
			await _employeeRepository.UpdateAsync(employee);
			
		}

		public async Task DeleteAsync(string id)
		{
			await _employeeRepository.DeleteAsync(id);


		}
	}
}
