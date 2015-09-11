using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OAuth2Demo.IdentityServer {

    public class Context : IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim> {
        public Context(string connectionString) : base(connectionString) { }
    }

    public class UserStore : UserStore<IdentityUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim> {
        public UserStore(Context context) : base(context) { }
    }

    public class RoleStore : RoleStore<IdentityRole> {
        public RoleStore(Context context) : base(context) { }
    }


    public class UserManager : UserManager<IdentityUser, string> {
        public UserManager(UserStore userStore) : base(userStore) {
            //this.ClaimsIdentityFactory = new ClaimsFactory();
        }
    }

    public class RoleManager : RoleManager<IdentityRole> {
        public RoleManager(RoleStore roleStore) : base(roleStore) { }
    }
}