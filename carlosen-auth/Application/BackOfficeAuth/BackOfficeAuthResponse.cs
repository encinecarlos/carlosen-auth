using System.Text.Json.Serialization;

namespace carlosen_auth.Application.BackOfficeAuth
{
    public class BackOfficeAuthResponse
    {
        [JsonPropertyName("access_token")]
        public string Token { get; set; }

        [JsonPropertyName("expires_in")]
        public int Expiration { get; set; }
    }
}
