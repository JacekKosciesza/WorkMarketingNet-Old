using System;
using System.Collections.Generic;
using WorkMarketingNet.Web.Models;

namespace WorkMarketingNet.Web.Repositories
{
    public interface ICompaniesRepository
    {
		IEnumerable<Company> All { get; }
		Company GetById(Guid id);
		void Add(Company item);
		bool TryDelete(Guid id);
    }
}