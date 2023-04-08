using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using Lemon_d.local.Helpers;
using Lemon_d.local.IGDB;
using Lemon_d.local.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lemon_d.local.Services
{
	public class SearchService
	{
		#region Properties

		private protected HttpClient _httpClient;

		private string ClientId = Template.API.Authorization.CLIENT_ID;

		private string ClientSecret = Template.API.Authorization.CLIENT_SECRET;

		#endregion

		#region Methods

		public async Task<List<SearchResultModel.PartialQuery>> Search (string query, int limit, int offset, Sort sortBy, SortOrder sortOrder)
		{
			AccessHelper _accessHelper = new AccessHelper();
			string AccessTokenRetriever = await _accessHelper.RetrieveAccessToken(ClientId, ClientSecret);
			string _AccessToken = string.Empty;
			try { _AccessToken = ((JObject)JsonConvert.DeserializeObject(AccessTokenRetriever)).SelectToken("access_token").Value<string>(); } catch(Exception ex) { throw new Exception(message: "An Exception was Thrown when trying to parse the request response.", innerException: ex); }
			if (_httpClient == null)
			{
				_httpClient = new HttpClient();
				_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken);
			}
			StringBuilder queryString = new StringBuilder();
			queryString.AppendLine(BuildSearchQuery(query, "searchQuery", limit, offset, sortBy, sortOrder));

			var httpRequestMessage = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri("https://api.igdb.com/v4/multiquery/"),
				Headers = {
					{ HttpRequestHeader.Authorization.ToString(), "Bearer " + _AccessToken },
					{ "Client-ID", ClientId }
				},
				Content = new StringContent(queryString.ToString())
			};

			var response = await _httpClient.SendAsync(httpRequestMessage).Result.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<SearchResultModel.PartialQuery>>(response);
		}

		private string BuildSearchQuery(string q, string name, int limit, int offset, Sort sortBy, SortOrder sortOrder)
		{
//			Regex rgx = new Regex(@"[\s\.\,\|\-_\/]");
//			string[] qSpl = rgx.Split(q);
//			List<string> qFin = new List<string>();
//			foreach (string c in qSpl)
//			{
//				if (!String.IsNullOrEmpty(c))
//				{
//					qFin.Add($"name ~ *\"{c}\"*");
//				}
//			}
//
//			StringBuilder qBuilder = new StringBuilder();
//			qBuilder.AppendJoin(" | ", qFin.Distinct());
//			string qCollection = qBuilder.ToString();

			StringBuilder builder = new StringBuilder();

			StringBuilder gamePartialBuilder = new StringBuilder();
			gamePartialBuilder.AppendLine($"query games \"{name}_games\" {'{'}");
			gamePartialBuilder.AppendLine($"fields name, websites.url;");
			gamePartialBuilder.AppendLine($"where name ~ *\"{q}\"*;");
			gamePartialBuilder.AppendLine($"limit {limit}; offset {offset};");
			gamePartialBuilder.AppendLine($"sort {GetSorting(sortBy)} {GetOrder(sortOrder)};");
			gamePartialBuilder.AppendLine("};");
			builder.Append(gamePartialBuilder.ToString());

			StringBuilder companyPartialBuilder = new StringBuilder();
			companyPartialBuilder.AppendLine($"query companies \"{name}_companies\" {'{'}");
			companyPartialBuilder.AppendLine($"fields name, websites.url;");
			companyPartialBuilder.AppendLine($"where name ~ *\"{q}\"*;");
			companyPartialBuilder.AppendLine($"limit {limit}; offset {offset};");
			companyPartialBuilder.AppendLine("};");
			builder.Append(companyPartialBuilder.ToString());

			return builder.ToString();
		}

		private string GetSorting(Sort s)
		{
			switch (s)
			{
				case Sort.Name:
					return "name";
				case Sort.TotalRating:
					return "total_rating";
				case Sort.FirstReleaseDate:
					return "first_release_date";
				case Sort.LastUpdated:
					return "updated_at";
				default:
					return "name";
            }
		}

		private string GetOrder(SortOrder o)
		{
			switch(o)
			{
				case SortOrder.Ascending:
					return "asc";
				case SortOrder.Descending:
					return "desc";
				default:
					return "asc";
			}
		}

		#endregion

		#region Constructors
		public SearchService()
		{
			if (this._httpClient == null)
			{
				this._httpClient = new HttpClient();
			}
		}
		#endregion

		public enum Sort
        {
            Name = 0,
            TotalRating = 1,
            FirstReleaseDate = 2,
			LastUpdated = 3,
			Default = 4,
        }

		public Sort GetSort(string s)
		{
			if (!String.IsNullOrEmpty(s))
			{
                switch (s.ToLower())
                {
                    case "name":
                        return Sort.Name;
                    case "n":
                        return Sort.Name;
                    case "title":
                        return Sort.Name;
                    case "totalrating":
                        return Sort.TotalRating;
                    case "rating":
                        return Sort.TotalRating;
                    case "tr":
                        return Sort.TotalRating;
                    case "firstreleasedate":
                        return Sort.FirstReleaseDate;
                    case "firstrelease":
                        return Sort.FirstReleaseDate;
                    case "release":
                        return Sort.FirstReleaseDate;
                    case "releasedate":
                        return Sort.FirstReleaseDate;
                    case "lastupdated":
                        return Sort.LastUpdated;
                    case "updated":
                        return Sort.LastUpdated;
                    default: return Sort.Default;
                }
            } else
			{
				return Sort.Default;
			}
		}

		public enum SortOrder
		{
			Ascending = 0,
			Descending = 1,
			Default = 2,
		}

        public SortOrder GetOrder(string so)
        {
            if(!String.IsNullOrEmpty(so))
			{
                switch (so.ToLower())
                {
                    case "descending":
                        return SortOrder.Descending;
                    case "desc":
                        return SortOrder.Descending;
                    case "d":
                        return SortOrder.Descending;
                    case "ascending":
                        return SortOrder.Ascending;
                    case "asc":
                        return SortOrder.Ascending;
                    case "a":
                        return SortOrder.Ascending;
                    default: return SortOrder.Default;
                }
            }
			else
			{
				return SortOrder.Default;
			}
        }
    }
}
