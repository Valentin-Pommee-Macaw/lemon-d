using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Lemon_d.local.Helpers;
using Lemon_d.local.IGDB;
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

		public async Task<string> Search (string query, int limit, int offset)
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
			queryString.AppendLine(BuildSearchQuery(query, "searchQuery", limit, offset));

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
			return response;
		}

		private string BuildSearchQuery(string q, string name, int limit, int offset)
		{
			StringBuilder builder = new StringBuilder();

			StringBuilder gamePartialBuilder = new StringBuilder();
			gamePartialBuilder.AppendLine($"query games \"{name}_games\" {'{'}");
			gamePartialBuilder.AppendLine($"fields name;");
			gamePartialBuilder.AppendLine($"where name ~ *\"{q}\"*;");
			gamePartialBuilder.AppendLine($"limit {limit}; offset {offset};");
			gamePartialBuilder.AppendLine("};");
			builder.Append(gamePartialBuilder.ToString());

			StringBuilder companyPartialBuilder = new StringBuilder();
			companyPartialBuilder.AppendLine($"query companies \"{name}_companies\" {'{'}");
			gamePartialBuilder.AppendLine($"fields name;");
			companyPartialBuilder.AppendLine($"where name ~ *\"{q}\"*;");
			companyPartialBuilder.AppendLine($"limit {limit}; offset {offset};");
			companyPartialBuilder.AppendLine("};");
			builder.Append(companyPartialBuilder.ToString());

			return builder.ToString();
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
	}
}
