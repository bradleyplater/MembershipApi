using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipApi.Models
{
	public class ItemTypes : IItemTypes
	{
		public Dictionary<string, double> PriceList { get; set; }

		public ItemTypes()
		{
			PriceList = new Dictionary<string, double>();
			PriceList.Add("Orange", 1.25);
			PriceList.Add("Tea", 0.99);
		}
	}
}
