using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop2._0.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string Name { set; get; }
    }
}