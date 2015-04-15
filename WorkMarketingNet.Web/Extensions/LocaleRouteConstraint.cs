using Microsoft.AspNet.Routing;
using System;
using Microsoft.AspNet.Http;
using System.Collections.Generic;
using System.Linq;

namespace WorkMarketingNet.Web.Extensions
{
	public class LocaleRouteConstraint : IRouteConstraint
	{
		public string Culture { get; private set; }
		public LocaleRouteConstraint(string culture)
		{
			Culture = culture;
		}

		public bool Match(HttpContext httpContext, IRouter route, string routeKey, IDictionary<string, object> values, RouteDirection routeDirection)
		{
			object value;
			if (values.TryGetValue("locale", out value) && !string.IsNullOrWhiteSpace(value as string))
			{
				string culture = value as string;
				if (IsValid(culture))
				{
					return string.Equals(Culture, culture, StringComparison.OrdinalIgnoreCase);
				}
			}
			return false;
		}

		private bool IsValid(string locale)
		{
			string[] validOptions = "en-US|pl-PL".Split('|');
			return validOptions.Contains(locale.ToUpper());
		}
	}
}