using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet, Route("ExternalLogin")]
        public IActionResult ExternalLogin(string returnUrl, string provider = "facebook")
        {
            string authenticationScheme = string.Empty;

            // Logic to select the authenticationScheme
            // which specifies which LoginProvider to use
            // comes in here
            authenticationScheme = FacebookDefaults.AuthenticationScheme;

            var auth = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(LoginCallback), new { provider, returnUrl })
            };

            return new ChallengeResult(authenticationScheme, auth);
        }

        public IActionResult LoginCallback()
        {
            var a = _httpContextAccessor.HttpContext.User.Claims;
            return Ok(a);
        }
    }
}
