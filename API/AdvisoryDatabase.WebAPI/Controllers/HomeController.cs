using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WKFS.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "RCM Client API";
            return View();
        }

    [System.Web.Http.HttpGet]
    // [System.Web.Http.ActionName("GetWindowsUser")]
    public string GetWindowsUser()
    {
      var headerUserName = HttpContext.Request.ServerVariables["AUTH_USER"];
      return headerUserName;

    }
  }
}
