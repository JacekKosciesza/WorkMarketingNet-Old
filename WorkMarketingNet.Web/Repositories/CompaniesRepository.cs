using System;
using System.Collections.Generic;
using System.Linq;
using WorkMarketingNet.Web.Data;
using WorkMarketingNet.Web.Models;

namespace WorkMarketingNet.Web.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
		private readonly DataContext _db;

		public CompaniesRepository(DataContext db)
		{
			_db = db;
		}

		readonly List<Company> _companies = new List<Company>
		{
			new Company { Id = Guid.NewGuid() , Name = "Jeunesse Global", Code = "jeunesse-global", Logo = new Image { Url = "http://www.jeunesse.pl/images/logo.png" } }
		};

		public IEnumerable<Company> All
		{
			get
			{
				return _db.Companies; //_companies;
			}
		}

		public Company GetById(Guid id)
		{
			return _companies.FirstOrDefault(x => x.Id == id);
		}

		public void Add(Company item)
		{
			item.Id = Guid.NewGuid();
			_companies.Add(item);
		}

		public bool TryDelete(Guid id)
		{
			var item = GetById(id);
			if (item == null)
			{
				return false;
			}
			_companies.Remove(item);
			return true;
		}
	}
}