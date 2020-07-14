using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingVegefoods.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        [AllowAnonymous]
        [ActionName("danh-sach")]
        public ActionResult Index()
        {
            return View("Index");
        }

        [AllowAnonymous]
        [ActionName("chi-tiet")]
        public ActionResult Detail(int ?id)
        {
            return View("Detail");
        }
    }
}