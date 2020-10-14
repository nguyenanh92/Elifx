using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Common
{
    [Serializable]
    public class UserSession
    {
        public int ID { get; set; }
        public string UserName { get; set; }
    }
}