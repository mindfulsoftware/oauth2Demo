using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OAuth2Demo.ApiClient.Infrastructure {
    public class RequireHttpsAttribute : AuthorizationFilterAttribute {

        public override void OnAuthorization(HttpActionContext actionContext) {
            base.OnAuthorization(actionContext);

            var request = actionContext.Request;
            if (request.RequestUri.Scheme != Uri.UriSchemeHttps) {

                actionContext.Response.Content = new StringContent("<p>https scheme required.</p>", Encoding.UTF8, "text/html");

                if (string.Compare(request.Method.Method, "GET", true) == 0) {
                    actionContext.Response = request.CreateResponse(HttpStatusCode.Found);

                    var builder = new UriBuilder(request.RequestUri);
                    builder.Scheme = Uri.UriSchemeHttps;
                    builder.Port = 443;

                    actionContext.Response.Headers.Location = builder.Uri;
                }
                else {
                    actionContext.Response = request.CreateResponse(HttpStatusCode.NotFound);

                }
            }
        }
    }
}