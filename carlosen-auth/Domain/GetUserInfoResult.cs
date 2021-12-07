using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace carlosen_auth.Domain
{
    public class GetUserInfoResult
    {
        [JsonPropertyName("sub")]
        public string Id { get; set; }
        
        [JsonPropertyName("preferred_username")]
        public string Username { get; set; }

        [JsonPropertyName("email_verified")]        
        public bool EmailVerified { get; set; }

        [JsonPropertyName("given_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("family_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
        public FederatedIdentifies FederatedIdentity { get; set; }
    }
}