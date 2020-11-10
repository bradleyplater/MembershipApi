using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MembershipApi.Models
{
	public interface IItemTypes
	{
		Dictionary<string, double> PriceList { get; set; }
	}
}
