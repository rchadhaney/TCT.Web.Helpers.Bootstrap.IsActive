using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsActiveExample.Areas.Host.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Host/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}