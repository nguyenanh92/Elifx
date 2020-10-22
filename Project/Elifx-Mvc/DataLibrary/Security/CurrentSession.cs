using System;
using System.Globalization;
using System.Threading;
using System.Web;
using DataLibrary.Config;
using System.Linq;
using DataLibrary.Database;

namespace DataLibrary.Security
{
    public class CurrentSession
    {
        public static void SetTimeOut(int hours)
        {
            HttpContext.Current.Session.Timeout = hours;
        }
        public static int GetTimeOut()
        {
            return HttpContext.Current.Session.Timeout;
        }

        public static string SystemErrors
        {
            get
            {
                return HttpContext.Current.Session["SystemErrors"] != null ? HttpContext.Current.Session["SystemErrors"].ToString() : null;
            }
            set
            {
                HttpContext.Current.Session["SystemErrors"] = value;
            }
        }

      
        public static DateTime LockUser
        {
            get
            {
                return HttpContext.Current.Session["LockUser"] != null
                           ? Convert.ToDateTime(HttpContext.Current.Session["LockUser"])
                           : DateTime.Now;
            }
            set
            {
                HttpContext.Current.Session["LockUser"] = value;
            }
        }

        public static bool Logined
        {
            get
            {
                return HttpContext.Current.Session["Logined"] != null && Convert.ToBoolean(HttpContext.Current.Session["Logined"]);
            }
            set
            {
                HttpContext.Current.Session["Logined"] = value;
            }
        }

        //clear all session
        public static void ClearAll()
        {
            HttpContext.Current.Session.RemoveAll();
        }
    }
}
