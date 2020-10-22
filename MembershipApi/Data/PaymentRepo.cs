using MembershipApi.Models;
using MongoDB.Driver;

namespace MembershipApi.Data
{
	public class PaymentRepo : IPaymentRepo
	{
		private readonly IMongoCollection<User> _Users;
		public PaymentRepo(IDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);
			_Users = database.GetCollection<User>("users");
		}

		public void AddNewUser(User user)
		{
			_Users.InsertOne(user);
		}

		public User GetBalanceById(int id)
		{
			return _Users.Find(user => user.EmployeeId == id).SingleOrDefault();
		}
	}
}
