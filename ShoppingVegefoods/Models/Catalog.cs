using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingVegefoods.Models
{
    public class Catalog
    {
        public string ID { set; get; }
        public string NAME { set; get; }
        public string PARENT_ID { set; get; }
        public int STATUS { set; get; }
        public string STATUS_NAME { set; get; }
    }
}