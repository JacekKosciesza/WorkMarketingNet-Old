using System;

namespace WorkMarketingNet.Web.Services
{
    public interface IDictionaryService
    {
		string Translate(string text, string culture);
    }
}