using carlosen_auth.Clients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace carlosen_auth.Application.BackOfficeAuth
{
    public class BackOfficeAuthCommand : IRequestHandler<BackOfficeAuthRequest, BackOfficeAuthResponse>
    {
        private IKeyCloakClient Client { get; }

        public BackOfficeAuthCommand(IKeyCloakClient client)
        {
            Client = client;
        }

        public async Task<BackOfficeAuthResponse> Handle(BackOfficeAuthRequest request, CancellationToken cancellationToken)
        {
            var token = await Client.Autehticate(request);
            
            return token;
        }
    }
}
