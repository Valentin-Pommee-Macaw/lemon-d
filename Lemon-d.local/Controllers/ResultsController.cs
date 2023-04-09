using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Lemon_d.local.Services;
using Lemon_d.local.Models;
using Lemon_d.local.IGDB;
using Newtonsoft.Json.Linq;

namespace Lemon_d.local.Controllers
{
	public class ResultsController : Controller
	{
		public async Task<IActionResult> Results(string sq, string sort, string order, int limit, int offset)
		{
			SearchService searchService = new SearchService();
			List<SearchResultModel.PartialQuery> search = await searchService.Search(sq, limit <= 0 ? Template.Search.Configuration.DEFAULT_LIMIT : limit, offset, searchService.GetSort(sort), searchService.GetOrder(order));
			SearchResultModel m = new SearchResultModel(search, sq);
			return View(m);
		}
	}
}
