using carlosen_auth.Application.BackOfficeAuth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace carlosen_auth.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IMediator Mediator { get; }

        public AuthenticationController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BackOfficeAuthResponse>> Autheticate([FromBody] BackOfficeAuthRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
