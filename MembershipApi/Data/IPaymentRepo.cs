using MembershipApi.Models;

namespace MembershipApi.Data
{
	public interface IPaymentRepo
	{
		User GetBalanceById(int id);
		User AddNewUser(User user);
	}
}
