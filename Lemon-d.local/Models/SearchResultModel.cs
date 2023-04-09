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
                public double total_rating { get; set; }
                public string name { get; set; }
				public Website[] websites { get; set; }
				public Cover cover { get; set; }

				public class Website
				{
					public string id { get; set; }
					public string url { get; set; }
					public string category { get; set; }
				}

				public class Cover
				{
					public string id { get; set; }
					public string image_id { get; set; }
				}
			}
		}
	}
}
