using System.Web.Mvc;
using ShoppingVegefoods.Common;
using ShoppingVegefoods.Models;
using System;
using Core;

namespace ShoppingVegefoods.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        #region Login
        [AllowAnonymous]
        [ActionName("dang-nhap")]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            password = FunctionHelper.EncodingPassword(password);
            User user = CBO.FillObject<User>(DataProvider.Instance.ExecuteReader("LoginUser", username, password));

            if (user == null || Null.IsNull(user.ID)) {
                ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng";
                return View("Login");
            }

            Session.Add("CURRENTUSER", user.ID);
            return RedirectToAction("Index","Home");
        }
        #endregion

        #region Register
        [AllowAnonymous]
        [ActionName("dang-ky")]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.ID = FunctionHelper.GetNextIDUser();
            user.PASSWORD = FunctionHelper.EncodingPassword(user.PASSWORD);
            user.CREATED = DateTime.Now;
            int result = DataProvider.Instance.ExecuteNonQuery("CreateUser",user.ID,user.USERNAME,user.EMAIL, user.PHONE, user.ADDRESS, user.PASSWORD, user.CREATED);
            return View("Login");
        }

        public JsonResult IsExistUsername(string data)
        {
            
            User user = CBO.FillObject<User>(DataProvider.Instance.ExecuteReader("CheckIsExisUsernameEmail", "username",data));
            bool isExist = Null.IsNull(user.ID) ? false : true;
            return Json(isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsExistEmail(string data)
        {
            User user = CBO.FillObject<User>(DataProvider.Instance.ExecuteReader("CheckIsExisUsernameEmail", "email" ,data));
            bool isExist = Null.IsNull(user.ID) ? false : true;
            return Json(isExist, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Forgot Password
        [AllowAnonymous]
        [ActionName("quen-mat-khau")]
        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }

        public ActionResult ForgotPassword(string email, string username)
        {
            if (FunctionHelper.SendMail(email, username))
            {
                ViewBag.Error = "Reset mật khẩu không thành công.";
                return View("ForgotPassword");
            }
            return View("Login");
        }
        #endregion

        #region Change Password
        [AllowAnonymous]
        [ActionName("doi-mat-khau")]
        public ActionResult ChangePassword()
        {
            return View("ChangePassword");
        }

        [HttpPost]
        public ActionResult ChangePassword(string passwordNewRetype)
        {
            string id = Session["CURRENTUSER"] + "";
            if (Null.IsNull(id))
            {
                return RedirectToAction("Index", "Home");
            }
            passwordNewRetype = FunctionHelper.EncodingPassword(passwordNewRetype);
            int result = DataProvider.Instance.ExecuteNonQuery("ChangedPasswordUser", id, passwordNewRetype);
            if (result > 0)
            {
                return RedirectToAction("Index","Home");
            }
            return View("ChangePassword");
        }
        #endregion
    }
}