using System.Web.Mvc;

namespace OAuth2Demo.MvcClient.Controllers
{
    public class BaseController : Controller {
        public new JsonResult Json(object data) {
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}