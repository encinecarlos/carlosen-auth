using MediatR;
using System.Text.Json.Serialization;

namespace carlosen_auth.Application.BackOfficeAuth
{
    public class BackOfficeAuthRequest : IRequest<BackOfficeAuthResponse>
    {
        public string Username { get; set; }
        public string password { get; set; }
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
    }
}
