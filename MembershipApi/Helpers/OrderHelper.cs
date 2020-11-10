using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipApi.Models
{
	public class OrderHelper : IOrder
	{
		private readonly IItemTypes _itemTypes;
		public double basketTotal { get; set; }
		public OrderHelper(IItemTypes itemTypes)
		{
			_itemTypes = itemTypes;
		}

		public bool CheckItemsRequestedInItemTypes(Dictionary<string, int> requestedItems)
		{
			foreach (KeyValuePair<string, int> requestedItem in requestedItems)
			{
				Console.WriteLine(requestedItem.Key);
				if (!_itemTypes.PriceList.ContainsKey(requestedItem.Key))
				{
					return false;
				}
			}
			return true;
		}

		public bool CheckAccountHasEnoughBalance(double balance)
		{
			return balance - basketTotal < 0;
		}

		public void CalculateBasket(Dictionary<string, int> requestedItems)
		{
			foreach(KeyValuePair<string, int> requestedItem in requestedItems)
			{
				basketTotal += CalculateItemTotal(requestedItem);
			}
			Console.WriteLine(basketTotal);
		}

		public double CalculateItemTotal(KeyValuePair<string,int> requestedItem)
		{
			double price = _itemTypes.PriceList.GetValueOrDefault(requestedItem.Key);
			return price * requestedItem.Value;
		}
	}
}
