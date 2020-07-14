using ShoppingVegefoods.Common;
using ShoppingVegefoods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Newtonsoft.Json;

namespace ShoppingVegefoods.Areas.Administartor.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Administartor/Catalog
        [ActionName("danh-sach")]
        public ActionResult Index()
        {
            List<Catalog> catalogDataList = CBO.FillCollection<Catalog>(DataProvider.Instance.ExecuteReader("GetAllCalalog", ""));
            return View("Index", catalogDataList);
        }

        #region Add new catalog
        [AllowAnonymous]
        [ActionName("them-moi")]
        public ActionResult Create()
        {
            List<Catalog> catalogDataList = CBO.FillCollection<Catalog>(DataProvider.Instance.ExecuteReader("GetAllCalalog", ""));
            return View("Create", catalogDataList);
        }

        [HttpPost]
        public ActionResult Create(Catalog catalog)
        {
            string id = FunctionHelper.GetNextIDCatalog();
            int result = DataProvider.Instance.ExecuteNonQuery("CreateNewCatalog", id, catalog.NAME, catalog.PARENT_ID, 1);
            if(result.Equals(0))
            {
                List<Catalog> catalogDataList = CBO.FillCollection<Catalog>(DataProvider.Instance.ExecuteReader("GetAllCalalog", ""));
                return View("Create", catalogDataList);
            }
            return RedirectToAction("danh-sach","Catalog");
        }
        #endregion

        #region Edit catalog
        public JsonResult GetCatalogById(string id)
        {
            List<Catalog> catalogDataList = CBO.FillCollection<Catalog>(DataProvider.Instance.ExecuteReader("GetAllCalalog", ""));
            Catalog catalog = catalogDataList.FirstOrDefault(x => x.ID == id);
            if (catalog == null || Null.IsNull(catalog.ID))
            {
                return Json(new { result = 0});
            }
            
            return Json(new { result = 1, catalog = catalog, catalogDataList = catalogDataList });
        }


        public JsonResult UpdateCatalog(string cat)
        {
            Catalog catalog = JsonConvert.DeserializeObject<Catalog>(cat);
            int result = DataProvider.Instance.ExecuteNonQuery("UpdateCatalog", catalog.ID, catalog.NAME, catalog.PARENT_ID, catalog.STATUS);
            if (result.Equals(0))
            {
                Json(new { result = 0 });
            }
            return Json(new { result = 1});
        }
        #endregion

        #region Delete catalog
        public JsonResult DeleteCatalog(string id)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("DeleteCatalog", id);
            if (result.Equals(0))
            {
                return Json(new { result = 0 });
            }
            return Json(new { result = 1});
        }
        #endregion
    }
}