using IdentityManager.Configuration;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

[assembly: OwinStartup(typeof(OAuth2Demo.IdentityServer.Startup))]

namespace OAuth2Demo.IdentityServer {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            string connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            app.Map("/identity", id => {
                id.UseIdentityServer(new IdentityServerOptions {
                    SiteName = "Demo Identity Server",
                    IssuerUri = (string)ConfigurationManager.AppSettings["options.issuerUri"],

                    Factory = new IdentityServerServiceFactory().Configure(connectionString),

                    SigningCertificate = LoadCertificate()
                });

            });

            app.Map("/admin", adminApp => {
                adminApp.UseIdentityManager(new IdentityManagerOptions() {
                    Factory = new IdentityManagerServiceFactory().Configure(connectionString)
                });

            });

        }

        X509Certificate2 LoadCertificate() {

            //Test certificate sourced from https://github.com/IdentityServer/IdentityServer3.Samples/tree/master/source/Certificates
            return new X509Certificate2(
                string.Format(@"{0}\bin\{1}", AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["signing-certificate.name"]),
                (string)ConfigurationManager.AppSettings["signing-certificate.password"]);
        }
    }
}
