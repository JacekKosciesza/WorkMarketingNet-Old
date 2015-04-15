using System.Globalization;

namespace WorkMarketingNet.Web.Services
{
	public class GlobalizationService : IGlobalizationService
	{
		public string Culture
		{
			get
			{
				return "pl-PL"; // CultureInfo.CurrentCulture.ToString();
			}
		}
	}
}