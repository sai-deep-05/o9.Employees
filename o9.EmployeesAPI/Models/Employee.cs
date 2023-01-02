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

		[BsonElement("EmployeeName")]
		public string EmployeeName { get; set; }

		[BsonElement("Department")]
		public string Department { get; set; }
	}
}
