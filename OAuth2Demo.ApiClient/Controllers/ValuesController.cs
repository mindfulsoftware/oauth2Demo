using OAuth2Demo.ApiClient.Infrastructure;
using System.Collections.Generic;
using System.Web.Http;

namespace OAuth2Demo.ApiClient.Controllers
{
    [RequireHttps]
    public class ValuesController : ApiController
    {
        [Authorize]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

    }
}
