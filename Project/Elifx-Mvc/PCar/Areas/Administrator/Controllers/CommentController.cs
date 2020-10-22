using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Config;
using DataLibrary.Database;
using DataLibrary.Security;

namespace PCar.Areas.Administrator.Controllers
{
    public class CommentController : IBaseController
    {
        //
        // GET: /Administrator/Comment/

     
         
        //lấy họ tên người đăng nhập
        public static string GetFullName(string cookie)
        {
            using (var db = new MyDbDataContext())
            {
                string cookieClient = cookie;
                string deCodecookieClient = CryptorEngine.Decrypt(cookieClient, true);
                string userName = deCodecookieClient.Substring(0, deCodecookieClient.IndexOf("||"));
                return db.Users.FirstOrDefault(a => a.Username == userName).FullName;
            }
        }
        //lấy danh sách menu theo theo kiểu menu
        [HttpPost]
        public JsonResult GetListMenu(int typeMenu)
        {
            //check logged
            var listMenu = new List<Menu>();

            listMenu = MenuController.GetListMenu(SystemMenuLocation.ListLocationMenu().ToList()[0].LocationId);
            listMenu = listMenu.Where(a => a.TypeMenu == typeMenu).ToList();

            foreach (Menu menu in listMenu)
            {
                string titleMenu = "";
                for (int i = 1; i <= menu.Level; i++)
                {
                    titleMenu += "|--";
                }
                menu.NameMenu = titleMenu + menu.NameMenu;
            }
            return Json(new { Result = "OK", ListMenu = listMenu.Select(a => new { MenuId = a.ID, a.NameMenu }).ToList() });
        }
        //Show messages
        public static string Messages(object messages)
        {
            if (messages != null)
                return messages.ToString();
            return "";
        }
    }

}
 