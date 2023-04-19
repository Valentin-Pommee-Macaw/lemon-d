using Newtonsoft.Json.Linq;
using Lemon_d.local.Services;

namespace Lemon_d.local.Models
{
	public class SearchResultModel
	{
		#region Properties

		public PartialCollection Results { get; set; }
		public string query { get; set; }
		public SearchService.Sort Sort { get; set; }
		public SearchService.SortOrder SortOrder { get; set; }

		#endregion

		#region Constructors

		public SearchResultModel(PartialCollection obj, string q, SearchService.Sort sort, SearchService.SortOrder order)
		{
			this.Results = obj;
			this.query = q;
			this.Sort = sort;
			this.SortOrder = order;
		}

		#endregion

		public class PartialCollection
		{
			public GamePartialQuery GamePartialQuery { get; set; }
			public CountPartialQuery CountPartialQuery { get; set; }
		}

		public class CountPartialQuery
		{
			public int count { get; set; }
			public string name { get; set; }
		}


        public class GamePartialQuery
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
				public List<InvolvedCompany> involved_companies { get; set; }
				public List<MultiplayerMode> multiplayer_modes { get; set; }
				public List<Genre> genres { get; set; }
				public List<Platform> platforms { get; set; }
				public string storyline { get; set; }


                public class Platform
				{
					public string id { get; set; }
					public string name { get; set; }
				}

				public class Genre
				{
					public string id { get; set; }
					public string name { get; set; }
				}

                public class InvolvedCompany
				{
					public string id { get; set; }
					public Company company { get; set; }

					public class Company
					{
						public string id { get; set; }
						public string name { get; set; }
					}
				}

				public class MultiplayerMode
				{
					public string id { get; set; }
					public bool lancoop { get; set; }
					public bool offlinecoop { get; set; }
					public bool onlinecoop { get; set; }
				}

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
