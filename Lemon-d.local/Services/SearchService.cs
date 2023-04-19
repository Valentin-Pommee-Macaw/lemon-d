using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Lemon_d.local.Helpers;
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

		public async Task<List<SearchResultModel.GamePartialQuery>> Search (string query, int limit, int offset, Sort sortBy, SortOrder sortOrder)

		{
			// Retrieve temporary access token from Twitch Authentication API
			AccessHelper _accessHelper = new AccessHelper();
			string AccessTokenRetriever = await _accessHelper.RetrieveAccessToken(ClientId, ClientSecret);
			string _AccessToken = string.Empty;
			try { _AccessToken = ((JObject)JsonConvert.DeserializeObject(AccessTokenRetriever)).SelectToken("access_token").Value<string>(); } catch(Exception ex) { throw new Exception(message: "An Exception was Thrown when trying to parse the request response.", innerException: ex); }
			// Send query
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
			// Deserialize JSON response
			return JsonConvert.DeserializeObject<List<SearchResultModel.GamePartialQuery>>(response);
		}

        /// <summary>
        /// Build a search query for the request based on the given parameters
        /// </summary>
        /// <param name="q">The string to search for</param>
        /// <param name="name">The name of the query as an identifier in the multiquery</param>
        /// <param name="limit">Max amount of results, default <b>15</b></param>
        /// <param name="offset">Offset of the returned items index, default <b>0</b></param>
        /// <param name="sortBy">The property to sort the results by</param>
        /// <param name="sortOrder">The order (<b>Ascending</b>/<b>Descending</b>) to sort the results</param>
        /// <returns>A valid search query <see cref="string"/> for the request</returns>
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
			gamePartialBuilder.AppendLine($"fields name, total_rating, websites.url, storyline, websites.category, cover.image_id, involved_companies.company.name, genres.name, platforms.name, multiplayer_modes.offlinecoop, multiplayer_modes.lancoop, multiplayer_modes.onlinecoop;");
			gamePartialBuilder.AppendLine($"where name ~ *\"{q}\"*;");
			gamePartialBuilder.AppendLine($"limit {limit}; offset {offset};");
			gamePartialBuilder.AppendLine($"sort {_GetSorting(sortBy)} {_GetOrder(sortOrder)};");
			gamePartialBuilder.AppendLine("};");
			builder.Append(gamePartialBuilder.ToString());

			return builder.ToString();
		}

		public async Task<List<SearchResultModel.CountPartialQuery>> GetCount (string query)
		{
            // Retrieve temporary access token from Twitch Authentication API
            AccessHelper _accessHelper = new AccessHelper();
            string AccessTokenRetriever = await _accessHelper.RetrieveAccessToken(ClientId, ClientSecret);
            string _AccessToken = string.Empty;
            try { _AccessToken = ((JObject)JsonConvert.DeserializeObject(AccessTokenRetriever)).SelectToken("access_token").Value<string>(); } catch (Exception ex) { throw new Exception(message: "An Exception was Thrown when trying to parse the request response.", innerException: ex); }
            // Send query
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken);
            }
            StringBuilder queryString = new StringBuilder();
            queryString.AppendLine(BuildSearchCountQuery(query, "searchQuery"));

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
            // Deserialize JSON response
            return JsonConvert.DeserializeObject<List<SearchResultModel.CountPartialQuery>>(response);
        }

		private string BuildSearchCountQuery(string q, string name)
        {
            StringBuilder countPartialBuilder = new StringBuilder();
            countPartialBuilder.AppendLine($"query games/count \"{name}_amount\" {'{'}");
            countPartialBuilder.AppendLine($"search *\"{q}\"*;");
            countPartialBuilder.AppendLine("};");

			return countPartialBuilder.ToString();
        }


        private string _GetSorting(Sort s)
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

		private string _GetOrder(SortOrder o)
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

		public Sort DeserializeSort(string s)
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

        public SortOrder DeserializeOrder(string so)
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
