using IdentityModel.Client;
using OAuth2Demo.ApiClient.Infrastructure;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OAuth2Demo.ApiClient.Controllers {

    public class CredentialsModel {
        public string Username { get; set; }
        public string Password { get; set; }
    }


    [RequireHttps]
    [RoutePrefix("api/account")]
    [EnableCors(origins: "http://localhost:61664", headers: "*", methods: "*")]
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