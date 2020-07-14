using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingVegefoods.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        [AllowAnonymous]
        [ActionName("thong-tin")]
        public ActionResult Index()
        {
            return View("Index");
        }

        [AllowAnonymous]
        [ActionName("ve-chung-toi")]
        public ActionResult AboutInfo()
        {
            return View("AboutInfo");
        }
    }
}