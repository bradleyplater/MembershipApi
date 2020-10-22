using MembershipApi.Models;

namespace MembershipApi.Data
{
	public interface IPaymentRepo
	{
		User GetBalanceById(int id);
		void AddNewUser(User user);
	}
}
