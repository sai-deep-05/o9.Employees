using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace o9.EmployeesAPI.Models
{
	public class Employee
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("EmployeeId")]
		public int EmployeeId { get; set; }

		[BsonElement("FirstName")]
		public string FirstName { get; set; }


		[BsonElement("LastName")]
		public string LastName { get; set; }


		[BsonElement("Department")]
		public string Department { get; set; }
	}
}
