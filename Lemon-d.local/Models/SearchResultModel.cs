using Newtonsoft.Json.Linq;

namespace Lemon_d.local.Models
{
	public class SearchResultModel
	{
		#region Properties

		public List<PartialQuery> Results { get; set; }
		public string query { get; set; }

		#endregion

		#region Constructors

		public SearchResultModel(List<PartialQuery> obj, string q)
		{
			this.Results = obj;
			this.query = q;
		}

		#endregion

		public class PartialQuery
		{
			public string name { get; set; }
			public List<Item> result { get; set; }

			public class Item
			{
				public string id { get; set; }
				public string name { get; set; }
			}
		}
	}
}
