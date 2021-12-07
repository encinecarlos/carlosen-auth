using carlosen_auth.Application.BackOfficeAuth;
using carlosen_auth.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace carlosen_auth.Clients
{
    public class KeyCloakClient : IKeyCloakClient
    {
        private IHttpClientFactory HttpClient { get; }
        private KeyCloakConfig Config { get; }
        private IConfiguration Configuration { get; }

        public KeyCloakClient(
            IHttpClientFactory httpClient,
            IOptions<KeyCloakConfig> options,
            IConfiguration configuration)
        {
            HttpClient = httpClient;
            Config = options.Value;
            Configuration = configuration;
        }

        public async Task<BackOfficeAuthResponse> Autehticate(BackOfficeAuthRequest parameters)
        {
            using var client = HttpClient.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, Config.Uri);

            var credentials = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", parameters.Username),
                new KeyValuePair<string, string>("password", parameters.password),
                new KeyValuePair<string, string>("grant_type", parameters.GrantType),
                new KeyValuePair<string, string>("client_id", parameters.ClientId),
                new KeyValuePair<string, string>("client_secret", parameters.ClientSecret),
                new KeyValuePair<string, string>("scope", parameters.Scope)
            };

            request.Content = new FormUrlEncodedContent(credentials);

            var response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<BackOfficeAuthResponse>(responseBody);
            
            return await Task.FromResult(result);
        }

        public async Task<GetUserInfoResult> GetUserInfo(string token)
        {
            var client = HttpClient.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, Config.UserInfo);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var result = new GetUserInfoResult();

            var response = await client.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                result = JsonSerializer.Deserialize<GetUserInfoResult>(responseBody);
            }

            return await Task.FromResult(result);
        }
    }
}
