using MembershipApi.Models;
using MongoDB.Driver;
using System;

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

		public User AddNewUser(User user)
		{
			Random random = new Random();
			int newId = random.Next(100000,999999);
			while(_Users.Find(user => user.EmployeeId == newId).SingleOrDefault() != null)
			{
				newId = random.Next(100000, 999999);
			}
			user.EmployeeId = newId;
			_Users.InsertOne(user);
			return user;
		}

		public User GetBalanceById(int id)
		{
			return _Users.Find(user => user.EmployeeId == id).SingleOrDefault();
		}

		public User UpdateUserTopUp(int id, double amount)
		{
			var filter = Builders<User>.Filter.Eq("EmployeeId", id);
			var update = new UpdateDefinitionBuilder<User>().Inc(user => user.Balance, amount);
			_Users.FindOneAndUpdate(filter, update);
			return GetBalanceById(id);
		}
		public User UpdateUserPurchase(int id, double purchaseAmount)
		{
			var filter = Builders<User>.Filter.Eq("EmployeeId", id);
			var update = new UpdateDefinitionBuilder<User>().Inc(user => user.Balance, -purchaseAmount);
			_Users.FindOneAndUpdate(filter, update);
			return GetBalanceById(id);

		}
	}
}
