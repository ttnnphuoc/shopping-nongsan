using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Core;
using ShoppingVegefoods.Models;

namespace ShoppingVegefoods.Controllers
{
    public class ProductController : Controller
    {
        // GET: List Product
        [AllowAnonymous]
        [ActionName("danh-sach")]
        public ActionResult Index()
        {
            List<Product> dataProductList = CBO.FillCollection<Product>(DataProvider.Instance.ExecuteReader("GetAllProduct", ""));
            return View("Index",dataProductList);
        }

        [AllowAnonymous]
        [ActionName("chi-tiet")]
        public ActionResult Detail(string id)
        {
            Product product = CBO.FillObject<Product>(DataProvider.Instance.ExecuteReader("GetAllProduct", id));
            return View("Detail", product);
        }
    }
}