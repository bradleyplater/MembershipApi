using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipApi.Models
{
	public interface IOrder
	{
		public bool CheckItemsRequestedInItemTypes(Dictionary<string, int> requestedItems);
		public bool CheckAccountHasEnoughBalance(double balance);
		public void CalculateBasket(Dictionary<string, int> requestedItems);
		public double basketTotal { get; set; }
	}
}
