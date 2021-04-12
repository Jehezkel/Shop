using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Accounts.Commands;

namespace Shop.Web.Controllers
{

    public class AccountController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<JwtSecurityToken>> Login([FromBody] LogInCommand logInCommand)
        {
            return await Mediator.Send(logInCommand);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<ActionResult<RegisterResult>> Register([FromBody] RegisterCommand registerCommand)
        {
            return await Mediator.Send(registerCommand);
        }
    }
}