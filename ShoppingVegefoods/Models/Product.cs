using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingVegefoods.Models
{
    public class Product
    {
        public string ID { set; get; }
        public string CATALOG_ID { set; get; }
        public string CATALOG_NAME { set; get; }
        public string NAME { set; get; }
        public decimal PRICE { set; get; }
        public string DESCRIPTION { set; get; }
        public string DISCOUNT { set; get; }
        public string IMAGE_LINK { set; get; }
        public string IMAGE_LIST { set; get; }
        public DateTime CREATED { set; get; }
        public int VIEW { set; get; }
        public int STATUS { set; get; }
        public string STATUS_NAME { set; get; }
        public int IDX { set; get; }
        public HttpPostedFileBase IMAGE_FILE { set; get; }
    }
}