using carlosen_auth.Clients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace carlosen_auth.Application.UserInfo
{
    public class UserInfoQuery : IRequestHandler<UserInfoRequest, UserInfoResponse>
    {
        private IKeyCloakClient Client { get; }

        public UserInfoQuery(IKeyCloakClient client)
        {
            Client = client;
        }

        public async Task<UserInfoResponse> Handle(UserInfoRequest request, CancellationToken cancellationToken)
        {
            var response = await Client.GetUserInfo(request.Token);

            var result = new UserInfoResponse
            {
                UserInfo = response
            };

            return await Task.FromResult(result);
        }
    }
}
