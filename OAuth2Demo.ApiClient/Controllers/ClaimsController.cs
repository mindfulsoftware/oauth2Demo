using OAuth2Demo.ApiClient.Infrastructure;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using Thinktecture.IdentityModel.WebApi;

namespace OAuth2Demo.ApiClient.Controllers
{
    [RequireHttps]
    [RoutePrefix("api/claims")]
    [EnableCors(origins: "http://localhost:61664", headers: "*", methods: "*")]
    public class ClaimsController : ApiController
    {
        [HttpGet]
        //[ResourceAuthorize("read", "claims")]
        [Authorize]
        public IEnumerable<Claim> Get() {

            return ((ClaimsIdentity)User.Identity).Claims;
        }
    }
}
