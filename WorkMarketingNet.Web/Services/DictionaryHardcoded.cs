using System;
using System.Collections.Generic;

namespace WorkMarketingNet.Web.Services
{
	// TODO: add case sensitivity switch
	public class DictionaryHardcoded : IDictionaryService
	{
		private readonly Dictionary<Tuple<string, string>, string> _dictionary = new Dictionary<Tuple<string, string>, string>
		{
			{Tuple.Create("Sign In", "pl-PL"), "Zaloguj się"},
			{Tuple.Create("Settings", "pl-PL"), "Ustawienia"},
		};

		public string Translate(string text, string culture)
		{
			var key = Tuple.Create(text, culture);
			var translation = _dictionary.ContainsKey(key) ? _dictionary[key] : text;
			return translation;
		}
	}
}