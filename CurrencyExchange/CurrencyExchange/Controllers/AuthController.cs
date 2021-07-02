using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Route("signin")]
        public IActionResult SignIn()
        {
            return Challenge(new AuthenticationProperties {RedirectUri = "/"});
        }
    }
}
