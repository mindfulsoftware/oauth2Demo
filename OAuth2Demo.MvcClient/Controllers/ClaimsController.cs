using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Mvc;

namespace OAuth2Demo.MvcClient.Controllers
{
    public class ClaimsController : BaseController {

        //[ResourceAuthorize("read", "claims")]
        [Authorize]
        public ActionResult Index() {
            return Json(new object[] { "asdf", "zxcv" });
        }
    }
}