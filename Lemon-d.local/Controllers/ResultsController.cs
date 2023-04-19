using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Lemon_d.local.Services;
using Lemon_d.local.Helpers;
using Lemon_d.local.Models;
using Lemon_d.local.IGDB;
using Newtonsoft.Json.Linq;
using Lemon_d.local.Database.DbModels;

namespace Lemon_d.local.Controllers
{
	public class ResultsController : Controller
	{
		public async Task<IActionResult> Results(string sq, string sort, string order, int limit, int offset)
		{
			SearchService searchService = new SearchService();
			List<SearchResultModel.GamePartialQuery> search = await searchService.Search(sq, limit <= 0 ? Template.Search.Configuration.DEFAULT_LIMIT : limit, offset, searchService.DeserializeSort(sort), searchService.DeserializeOrder(order));
			List<SearchResultModel.CountPartialQuery> countPartial = await searchService.GetCount(sq);
			SearchResultModel m = new SearchResultModel(new SearchResultModel.PartialCollection() { GamePartialQuery = search.First(), CountPartialQuery = countPartial.First()}, sq, searchService.DeserializeSort(sort), searchService.DeserializeOrder(order));

			ResultsViewModel model = new ResultsViewModel(sq, searchService.DeserializeSort(sort), searchService.DeserializeOrder(order));
			TypeConverter typeConverter = new TypeConverter();
            model.projects = new List<Project>();
			foreach (var i in m.Results.GamePartialQuery.result) {
				model.projects.Add(typeConverter.Convert(i));
			}
			model.TotalCount = (m.Results.CountPartialQuery.count);
			return View(model);
		}
	}
}
