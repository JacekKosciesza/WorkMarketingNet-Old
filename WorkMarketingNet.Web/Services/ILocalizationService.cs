using System;

namespace WorkMarketingNet.Web.Services
{
    public interface ILocalizationService
    {
		string Translate(string text, params object[] args);
    }
}