using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingVegefoods.Models;
using Core;
using System.Net.Mail;
using System.Text;
using System.IO;

namespace ShoppingVegefoods.Common
{
    public static class FunctionHelper
    {
        #region Get next id user
        public static string GetNextIDUser()
        {
            User user = CBO.FillObject<User>(DataProvider.Instance.ExecuteReader("GetNextID", "tbl_user"));

            if (user == null || Null.IsNull(user.ID))
            {
                return "KH00000001";
            }

            string currentID = user.ID.Replace("KH", "");
            long currentNumber = long.Parse(currentID);
            return string.Format("KH{0:00000000}", currentNumber+1);
        }
        #endregion

        #region Get next id product
        public static string GetNextIDProduct()
        {
            Product product = CBO.FillObject<Product>(DataProvider.Instance.ExecuteReader("GetNextID", "tbl_product"));
            if (product == null || Null.IsNull(product.ID))
            {
                return "SP00000001";
            }

            string currentID = product.ID.Replace("SP", "");
            long currentNumber = long.Parse(currentID);
            return string.Format("SP{0:00000000}", currentNumber + 1);
        }
        #endregion

        #region Get next id Catalog
        public static string GetNextIDCatalog()
        {
            Catalog Catalog = CBO.FillObject<Catalog>(DataProvider.Instance.ExecuteReader("GetNextID", "tbl_catalog"));
            if (Catalog == null || Null.IsNull(Catalog.ID))
            {
                return "C0001";
            }

            string currentID = Catalog.ID.Replace("C", "");
            long currentNumber = long.Parse(currentID);
            return string.Format("C{0:0000}", currentNumber + 1);
        }
        #endregion

        #region Encoding Password
        public static string EncodingPassword(string password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;

            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));

            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        #endregion

        #region Send Mail
        public static bool SendMail(string email, string username)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("your_email_address@gmail.com");
                mail.To.Add(email);
                mail.Subject = "[Reset Password]";
                mail.Body = string.Format("Mật khẩu mới cả tài khoản {0} là: <b>{1}</b>",username, RandomPassword());

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Create random password
        private static string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        #endregion

        #region Save image to folder
        public static bool SaveImageToFolder(HttpPostedFileBase file, string pathImage, string fileName = "")
        {
         
            if (file != null && file.ContentLength > 0)
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(pathImage);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                fileName = Null.IsNull(fileName) ? file.FileName : fileName;
                file.SaveAs(path + Path.GetFileName(fileName));
                return true;
            }
            return false;
          
        }
        #endregion
    }
}