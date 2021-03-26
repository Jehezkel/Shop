namespace Shop.Web.Controllers
{

    public class AccountController : ApiControllerBase{
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] GetTokenCommand getTokenCommand){
            
        }
    }
}