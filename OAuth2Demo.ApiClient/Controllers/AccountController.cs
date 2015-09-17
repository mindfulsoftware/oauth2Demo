using IdentityModel.Client;
using OAuth2Demo.ApiClient.Infrastructure;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;

namespace OAuth2Demo.ApiClient.Controllers {

    public class CredentialsModel {
        public string Username { get; set; }
        public string Password { get; set; }
    }


    [RequireHttps]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController {


        [Route("login")]
        public Task<TokenResponse> Login([FromBody]CredentialsModel credentials) {

            var clientId = (string)ConfigurationManager.AppSettings["oauth2.clientid"];

            var client = new TokenClient(
                (string)ConfigurationManager.AppSettings["openid.endpoints.token"],
                clientId,
                (string)ConfigurationManager.AppSettings["oauth2.client-secret"]
            );

            return client.RequestResourceOwnerPasswordAsync(credentials.Username, credentials.Password, clientId);
        }

    }
}