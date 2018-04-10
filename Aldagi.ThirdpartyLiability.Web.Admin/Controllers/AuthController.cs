using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace Aldagi.ThirdpartyLiability.Web.Admin.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Index([FromBody]UserLogin userData)
        {
            var discoveryResponse = await DiscoveryClient.GetAsync("http://localhost:5000");
            if (discoveryResponse.IsError)
            {
                throw new NotImplementedException();
            }

            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, "adminClient", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(userData.Username, userData.Password, "tplApi");
            if (tokenResponse.IsError)
                return BadRequest();
            else
            {
                return Json(new { access_token = tokenResponse.AccessToken });
            }
            
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}