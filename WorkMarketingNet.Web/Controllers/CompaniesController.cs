using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using WorkMarketingNet.Web.Models;
using WorkMarketingNet.Web.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkMarketingNet.Web.Controllers
{
	[Route("api/[controller]")]
	public class CompaniesController : Controller
    {
		private readonly ICompaniesRepository _repository;

		public CompaniesController(ICompaniesRepository repository)
		{
			_repository = repository;
		}

		// GET /api/companies
		[HttpGet]		
		public IEnumerable<Company> GetAll()
		{
			return _repository.All;
		}

		// GET /api/companies/id
		[HttpGet("{id:int}", Name = "GetByIdRoute")]
		public IActionResult GetById(Guid id)
		{
			var item = _repository.GetById(id);
			if (item == null)
			{
				return HttpNotFound();
			}

			return new ObjectResult(item);
		}

		// POST /api/companies
		[HttpPost]
		public void CreateCompany([FromBody] Company item)
		{
			if (!ModelState.IsValid)
			{
				Context.Response.StatusCode = 400;
			}
			else
			{
				_repository.Add(item);

				string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id }, Request.Scheme, Request.Host.ToUriComponent());
				Context.Response.StatusCode = 201;
				Context.Response.Headers["Location"] = url;
			}
		}

		// DELETE /api/companies/id
		[HttpDelete("{id}")]
		public IActionResult DeleteItem(Guid id)
		{
			if (_repository.TryDelete(id))
			{
				return new HttpStatusCodeResult(204); // 201 No Content
			}
			else
			{
				return HttpNotFound();
			}
		}
	}
}
