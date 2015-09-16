using System.Linq;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace OAuth2Demo.MvcClient.Infrastructure {
    public class AuthorizationManager : ResourceAuthorizationManager {

        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context) {

            switch (context.Resource.First().Value) {
                case "claims":
                    return AuthorizeBlog(context);
                default:
                    return Nok();
            }
        }

        Task<bool> AuthorizeBlog(ResourceAuthorizationContext context) {
            switch (context.Action.First().Value) {
                case "read":
                    return Eval(context.Principal.HasClaim("role", "website-claims"));
                default:
                    return Nok();
            }
        }
    }
}