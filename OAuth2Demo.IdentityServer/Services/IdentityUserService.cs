using IdentityServer3.AspNetIdentity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OAuth2Demo.IdentityServer.Services {
    public class IdentityUserService : AspNetIdentityUserService<IdentityUser, string> {

        public IdentityUserService(UserManager userManager) : base(userManager) {

        }
    }
}