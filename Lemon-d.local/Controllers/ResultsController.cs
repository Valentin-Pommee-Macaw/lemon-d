using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Lemon_d.local.Services;
using Lemon_d.local.Models;
using Lemon_d.local.IGDB;

namespace Lemon_d.local.Controllers
{
	public class ResultsController : Controller
	{
		public async Task<IActionResult> Results(string sq)
		{
			SearchService searchService = new SearchService();
			string search = await searchService.Search(sq, 10, 0);
			return View(new SearchResultModel()
			{
				Results = JsonConvert.DeserializeObject<List<object>>(search)
			});
		}
	}
}
