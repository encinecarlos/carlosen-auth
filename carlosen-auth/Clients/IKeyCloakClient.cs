using carlosen_auth.Application.BackOfficeAuth;
using carlosen_auth.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace carlosen_auth.Clients
{
    public interface IKeyCloakClient
    {
        public Task<BackOfficeAuthResponse> Autehticate(BackOfficeAuthRequest parameters);
        public Task<GetUserInfoResult> GetUserInfo(string token);
    }
}
