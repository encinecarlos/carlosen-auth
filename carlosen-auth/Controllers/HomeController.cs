using carlosen_auth.Application.UserInfo;
using carlosen_auth.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace carlosen_auth.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IMediator Mediator { get; }

        public HomeController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public ActionResult Welcome()
        {
            return Ok("to get a new token go to /api/auth");
        }

        [HttpPost]
        [Route("secret-info")]
        public async  Task<ActionResult<UserInfoResponse>> GetSecretInformation([FromBody] UserInfoRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
