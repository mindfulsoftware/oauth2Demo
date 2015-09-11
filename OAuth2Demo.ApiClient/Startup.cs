using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using OAuth2Demo.ApiClient.Infrastructure;
using Owin;
using System;
using System.Configuration;

[assembly: OwinStartup(typeof(OAuth2Demo.ApiClient.Startup))]

namespace OAuth2Demo.ApiClient {
    public class Startup {
        public void Configuration(IAppBuilder app) {

            app.UseResourceAuthorization(new AuthorizationManager());

            var clientId = (string)ConfigurationManager.AppSettings["oauth2.clientid"];
            var authority = (string)ConfigurationManager.AppSettings["oauth2.authority"];

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions {
                Authority = authority,
                RequiredScopes = new[] { clientId },
            });

            app.UseResourceAuthorization(new AuthorizationManager());
 
        }
    }
}
