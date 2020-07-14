using ShoppingVegefoods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using ShoppingVegefoods.Common;
using Newtonsoft.Json;

namespace ShoppingVegefoods.Areas.Administartor.Controllers
{
    public class ProductController : Controller
    {
        // GET: Administartor/Product
        [AllowAnonymous]
        [ActionName("danh-sach")]
        public ActionResult Index()
        {
            List<Product> productDataList = CBO.FillCollection<Product>(DataProvider.Instance.ExecuteReader("GetAllProduct", ""));
            return View("Index", productDataList);
        }

        #region Add new Product
        [AllowAnonymous]
        [ActionName("them-moi")]
        public ActionResult Create()
        {
            ViewBag.CatalogDataList = CBO.FillCollection<Catalog>(DataProvider.Instance.ExecuteReader("GetCatalogByStatus",1));
            return View("Create");
        }

        public ActionResult Create(Product product, HttpPostedFileBase IMAGE_FILE)
        {
            product.ID = FunctionHelper.GetNextIDProduct();
            product.CREATED = DateTime.Now;
            product.VIEW = 0;
            product.STATUS = 1;
            product.IMAGE_LINK = IMAGE_FILE.ContentLength > 0 ? product.ID + (IMAGE_FILE.FileName + "").Substring(IMAGE_FILE.FileName.LastIndexOf(".")) : "";
            
            int result = DataProvider.Instance.ExecuteNonQuery("CreateNewProduct", product.ID, product.CATALOG_ID, product.NAME, product.PRICE, product.DESCRIPTION, product.DISCOUNT,
                product.IMAGE_LINK, product.IMAGE_LIST, product.CREATED, product.VIEW, product.STATUS);
            if (result.Equals(0))
            {
                return View("Create");
            }
            
            FunctionHelper.SaveImageToFolder(IMAGE_FILE, "~/Uploads/Products/", product.IMAGE_LINK);
            return RedirectToAction("danh-sach", "Product");
        }
        #endregion

        #region Update Product
        public JsonResult GetProductById(string id)
        {
            Product product = CBO.FillObject<Product>(DataProvider.Instance.ExecuteReader("GetAllProduct", id));
            if (product == null || Null.IsNull(product.ID))
            {
                return Json(new { result = 0 });
            }

            List<Catalog> catalogDataList = CBO.FillCollection<Catalog>(DataProvider.Instance.ExecuteReader("GetAllCalalog", ""));
            return Json(new { result = 1, product = product , catalogDataList = catalogDataList });
        }
        public JsonResult UpdateProduct(Product product)
        {
            product.IMAGE_LINK = product.IMAGE_FILE!=null && product.IMAGE_FILE.ContentLength > 0 ? product.ID + (product.IMAGE_FILE.FileName + "").Substring(product.IMAGE_FILE.FileName.LastIndexOf(".")) : product.IMAGE_LINK;

            int result = DataProvider.Instance.ExecuteNonQuery("UpdateProduct", product.ID,product.CATALOG_ID, product.NAME, product.PRICE,product.DESCRIPTION,(product.DISCOUNT+"").Trim(),product.IMAGE_LINK,product.IMAGE_LIST, product.STATUS);
            if (result.Equals(0))
            {
                return Json(new { result = 0 });
            }
            FunctionHelper.SaveImageToFolder(product.IMAGE_FILE, "~/Uploads/Products/", product.IMAGE_LINK);
            return Json(new { result = 1 });
        }
        #endregion
    }
}