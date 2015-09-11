using System.Collections.Generic;
using System.Web.Http;

namespace OAuth2Demo.ApiClient.Controllers
{
    public class ValuesController : ApiController
    {
        [Authorize]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

    }
}
