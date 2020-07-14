using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingVegefoods.Models
{
    public class User
    {
        public string ID { set; get; }
        public string USERNAME { set; get; }
        public string EMAIL { set; get; }
        public string PHONE { set; get; }
        public string ADDRESS { set; get; }
        public string PASSWORD { set; get; }
        public DateTime CREATED { set; get; }
    }
}