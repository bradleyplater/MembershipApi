using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MembershipApi.Models
{
	public class User
	{
		[BsonId]
		public int EmployeeId { get; set; }

		public string Name { get; set; }

		public double Balance { get; set; }
	}
}
