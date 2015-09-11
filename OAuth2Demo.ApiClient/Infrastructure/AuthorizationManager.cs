using System.Linq;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace OAuth2Demo.ApiClient.Infrastructure {
    public class AuthorizationManager : ResourceAuthorizationManager {

        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context) {

            switch (context.Resource.First().Value) {
                case "values":
                    return AuthorizeValues(context);
                default:
                    return Nok();
            }
        }

        Task<bool> AuthorizeValues(ResourceAuthorizationContext context) {
            switch (context.Action.First().Value) {
                case "read":
                    return Eval(context.Principal.HasClaim("role", "api-read"));
                default:
                    return Nok();
            }
        }

    }
}