using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using OAuth2Demo.MvcClient.Infrastructure;
using Owin;
using System.Configuration;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(OAuth2Demo.MvcClient.App_Start.Startup))]

namespace OAuth2Demo.MvcClient.App_Start {
    public class Startup {
        public void Configuration(IAppBuilder app) {

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = "Cookies"
            });

            app.UseResourceAuthorization(new AuthorizationManager());

            var clientId = (string)ConfigurationManager.AppSettings["oauth2.clientid"];
            var authority = (string)ConfigurationManager.AppSettings["oauth2.authority"];
            var redirectUri = (string)ConfigurationManager.AppSettings["openid.redirect"];

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
                Authority = authority,
                ClientId = clientId,
                RedirectUri = redirectUri,
                ResponseType = "id_token token",
                Scope = "openid roles demo-website",

                SignInAsAuthenticationType = "Cookies",

                Notifications = new OpenIdConnectAuthenticationNotifications() {
                    SecurityTokenValidated = x => {

                        return Task.FromResult(0);
                    }
                }
            });

        }
    }
}
