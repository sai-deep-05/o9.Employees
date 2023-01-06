using Moq;
using o9.EmployeesAPI.Controllers;
using o9.EmployeesAPI.Services;
using o9.EmployeesAPI.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using o9.EmployeesAPI.DTO_Models;
using MongoDB.Driver;
using o9.EmployeesAPI.Repository;

namespace o9.EmployeesAPI.UnitTest


{
	public class EmployeesAPITest
	{
		private Employee _employeeCallBackObject;
		private Employee createAsync_employeeCallBackObject;
	

	[Fact]
		 public async Task GetAll_IsWorking()
		{

			//Arrange
		    var _mockrepository = new Mock<IEmployeesRepository>();
			_mockrepository.Setup(x => x.GetAllAsync()).ReturnsAsync(GetEmployeeList());
			var empservices = new EmployeeServices(_mockrepository.Object);
			string expected_name = "SaiDeep Indukur";
			


			//Act
			var response = await empservices.GetAllAsync();
			EmployeeDTO first_data = response.FirstOrDefault();
			string actual_name = first_data.EmployeeName;


			//Assert
			Assert.Equal(expected_name, actual_name); 
			
		 }
		
	

	[Fact]
		public async Task GetById_IsWorking()
		{
			//Arrange
			string Id = "63b3e8f7295b3b5293f506b3";
			var EmployeeId = 1;
			var FirstName = "Saideep";
			var LastName = "I";
			Employee emp = new Employee
			{
				Id = Id,
				FirstName=FirstName,
				LastName=LastName,
				EmployeeId=EmployeeId,
				Department="WebAPI"
			};

			var _mockrepository = new Mock<IEmployeesRepository>();         
			var empservices = new EmployeeServices(_mockrepository.Object); 
			_mockrepository.Setup(x => x.GetByIdAsync(Id)).ReturnsAsync(emp);
			
			//Act
			EmployeeDTO testEmployee = await empservices.GetByIdAsync(Id);
			


			//Assert
			Assert.Equal(emp.Id, testEmployee.Id);
			Assert.Equal(emp.EmployeeId, testEmployee.EmployeeId);
		

		}

	[Fact]
	
		public async Task UpdateAsync_IsWorking()
		{
			//Arrange
			var empDTO = new EmployeeDTO
			{
				Id = "Id",
				EmployeeId = 2,
				EmployeeName = "TEMP A",
				Department = "WebAPI"
			};

			var _mockrepository = new Mock<IEmployeesRepository>();
			var empservices = new EmployeeServices(_mockrepository.Object);
			_mockrepository.Setup(x => x.UpdateAsync(It.IsAny<Employee>())).Callback<Employee>(UpdateAsyncCallBack);
			
			//Act
			 await empservices.UpdateEmployeeDataAsync(empDTO);


			//Assert
			_employeeCallBackObject.FirstName.Should().Be("TEMP");
			_employeeCallBackObject.LastName.Should().Be("A");
			_mockrepository.Verify(x => x.UpdateAsync(It.IsAny<Employee>()),Times.Once);


		}


	[Fact]
		public async Task CreateAsync_IsWorking()
		{
			//Arrange
			var empDTO = new EmployeeDTO
			{
				Id = "Id",
				EmployeeId = 2,
				EmployeeName = "New Value",
				Department = "WebAPI"
			};

			var _mockrepository = new Mock<IEmployeesRepository>();
			var empservices = new EmployeeServices(_mockrepository.Object);
			_mockrepository.Setup(x => x.CreateAsync(It.IsAny<Employee>())).Callback<Employee>(CreateAsyncCallBack);

			//Act
			await empservices.CreateAsync(empDTO);


			//Assert
			createAsync_employeeCallBackObject.FirstName.Should().Be("New");
			createAsync_employeeCallBackObject.LastName.Should().Be("Value");
			_mockrepository.Verify(x => x.CreateAsync(It.IsAny<Employee>()), Times.Once);

		}



		[Fact]
		public async Task DeleteAsync_IsWorking()
		{
			//Arrange
			EmployeeDTO empDTO = new EmployeeDTO
			{
				Id = "63b3e8f7295b3b5293f506b3",
				EmployeeId = 5,
				EmployeeName = "Sai Deep",
				Department = "WebAPI"

			};
			var _mockrepository = new Mock<IEmployeesRepository>();
			var services = new EmployeeServices(_mockrepository.Object);
			_mockrepository.Setup(x => x.DeleteAsync(empDTO.Id));

			//Act
			await services.DeleteAsync(empDTO.Id);

			//Assert
			_mockrepository.Verify(x => x.DeleteAsync(empDTO.Id));

		}

		private static List<Employee> GetEmployeeList()
		{
			return new List<Employee>
			{
				new Employee
				{
				Id = "63b3e8f7295b3b5293f506b3",
				FirstName="SaiDeep",
				LastName="Indukur",
				EmployeeId=1,
				Department="WebAPI"
				},
				new Employee
				{
				Id = "63b3e8f7295b3b5293f506b4",
				FirstName="Ashish",
				LastName="Agarwal",
				EmployeeId=2,
				Department="WebAPI"
				}

			};

		}

		private void CreateAsyncCallBack(Employee obj)
		{
			createAsync_employeeCallBackObject = obj;
		}

		private void UpdateAsyncCallBack(Employee obj)
		{
			_employeeCallBackObject = obj;

		}

	}
}