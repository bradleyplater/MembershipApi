using MembershipApi.Models;

namespace MembershipApi.Data
{
	public interface IPaymentRepo
	{
		User GetBalanceById(int id);
		User AddNewUser(User user);
		User UpdateUserTopUp(int id, double amount);
		User UpdateUserPurchase(int id, double purchaseAmount);

	}
}
