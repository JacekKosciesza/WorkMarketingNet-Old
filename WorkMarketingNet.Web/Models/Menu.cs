using System.Collections.Generic;

namespace WorkMarketingNet.Web.Models
{
	public class Menu
    {
		public ICollection<MenuItem> Items { get; set; }
	}
}