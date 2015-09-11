using IdentityModel.Client;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;

namespace OAuth2Demo.ApiClient.Controllers {

    [RoutePrefix("api/Account")]
    public class AccountController : ApiController {

        [AllowAnonymous]
        [Route("Register")]
        public Task<TokenResponse> Register(string username, string password) {

            var clientId = (string)ConfigurationManager.AppSettings["oauth2.clientid"];

            var client = new TokenClient (
                (string)ConfigurationManager.AppSettings["openid.endpoints.token"],
                clientId,
                (string)ConfigurationManager.AppSettings["oauth2.client-secret"]
            );

            return client.RequestResourceOwnerPasswordAsync(username, password, clientId);
        }

    }
}