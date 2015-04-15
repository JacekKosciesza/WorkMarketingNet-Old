using System;
using System.ComponentModel.DataAnnotations;

namespace WorkMarketingNet.Web.Models
{
	public class Company
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		[Required]
		public string Code { get; set; }
		public Image Logo { get; set; }
	}
}