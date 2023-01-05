using Moq;
using o9.EmployeesAPI.Repository;
using o9.EmployeesAPI.Services;
using o9.EmployeesAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using o9.EmployeesAPI.DTO_Models;

namespace o9.EmployeesAPI.UnitTest
{
  public class EmployeeControllerTest
	{
		private EmployeeController _unitTesting = null;

		public EmployeeControllerTest()
		{
			if (_unitTesting == null)
			{
				var services = new Mock<IEmployeeServices>().Object;
				_unitTesting = new EmployeeController(services);
				//_unitTesting = new EmployeeController(repository);
			}
		}
	/***	[Fact]
		public async Task GetAll_Isworking()
		{
			var response = await _unitTesting.Get();

			var first_data = response;
			string expected_name = "SaiDeep I";
			//string actual_name = first_data.EmployeeName;
			Assert.Equal(expected_name, actual_name);
		}
	***/
	}
}
