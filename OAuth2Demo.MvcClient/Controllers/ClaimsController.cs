using System.Security.Claims;
using System.Linq;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Mvc;

namespace OAuth2Demo.MvcClient.Controllers
{
    public class ClaimsController : BaseController {

        [ResourceAuthorize("read", "claims")]
        public ActionResult Index() {
            return Json(
                ((ClaimsIdentity)User.Identity).Claims.Select(x => new { Type = x.Type, Value = x.Value })
            );
        }
    }
}