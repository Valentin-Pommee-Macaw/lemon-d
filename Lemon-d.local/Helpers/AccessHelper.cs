namespace Lemon_d.local.Helpers
{
	public class AccessHelper
	{
		public async Task<string> RetrieveAccessToken(string clientId, string clientSecret)
		{
			HttpClient _httpClient = new HttpClient();
			var httpRequestMessage = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri($"https://id.twitch.tv/oauth2/token?client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials")
			};
			var response = await _httpClient.SendAsync(httpRequestMessage).Result.Content.ReadAsStringAsync();
			return response;
		}
	}
}
