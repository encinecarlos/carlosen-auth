using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carlosen_auth.Application.UserInfo
{
    public class UserInfoRequest : IRequest<UserInfoResponse>
    {
        public string Token { get; set; }
    }
}
