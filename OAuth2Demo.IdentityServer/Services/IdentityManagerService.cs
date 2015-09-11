using IdentityManager.AspNetIdentity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OAuth2Demo.IdentityServer.Services {
    public class IdentityManagerService : AspNetIdentityManagerService<IdentityUser, string, IdentityRole, string> {
        public IdentityManagerService(UserManager userManager, RoleManager roleManager)
            : base(userManager, roleManager) {
        }
    }
}