using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace o9.EmployeesAPI.DTO_Models
{
	public class EmployeeDTO
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
