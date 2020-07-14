using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingVegefoods.Areas.Administartor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administartor/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}