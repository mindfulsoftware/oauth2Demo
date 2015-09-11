using OAuth2Demo.IdentityServer;
using OAuth2Demo.IdentityServer.Services;

namespace IdentityManager.Configuration {
    public static class IdentityManagerServiceExtensions {
        public static IdentityManagerServiceFactory Configure(this IdentityManagerServiceFactory factory, string connectionString) {

            factory.Register(new Registration<Context>(resolver => new Context(connectionString)));
            factory.Register(new Registration<UserStore>());
            factory.Register(new Registration<RoleStore>());
            factory.Register(new Registration<UserManager>());
            factory.Register(new Registration<RoleManager>());

            factory.IdentityManagerService = new IdentityManager.Configuration.Registration<IIdentityManagerService, IdentityManagerService>();

            return factory;
        }
    }
}
