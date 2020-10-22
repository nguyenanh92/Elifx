using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Common;
using DataLibrary.Security;
using PCar.Areas.Administrator.Models;

namespace PCar.Areas.Administrator.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Administrator/Login/

        public ActionResult LoginAdmin(LoginViewModel model)
        {
            if (Request.Cookies["client_cookie"] != null)
            {
                return RedirectToAction("Index", "DashBoard");
            }

            return View(new LoginViewModel {});
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult LoginSubmit(LoginViewModel model)
        {
            Random random;
            if (ModelState.IsValid)
            {
                int checklogin = CheckLogin.CheckUserLogin(model.username, model.password, model.remember);
                switch (checklogin)
                {
                    case 1:

                        //Đăng nhập thành công
                        var user = CheckLogin.GetUser(model.username);
                        var userSession = new UserLogin();

                        userSession.UserName = user.Username;
                        userSession.ID = user.ID;
                        Session.Add(CommonConstants.USER_SESSION , userSession);


                        TempData["Count"] = 0;
                        TempData["Messages"] = "Login Success";
                        return RedirectToAction("Index", "DashBoard");
                    case 2:
                        ViewBag.Messages = "Tài khoản đã bị khóa";
                        return View("LoginAdmin");
                    case 3:
                        if (TempData["Count"] == null)
                        {
                            TempData["Count"] = 1;
                            TempData.Keep("Count");
                        }
                        else
                        {
                            TempData["Count"] = int.Parse(TempData["Count"].ToString()) + 1;
                            TempData.Keep("Count");
                        }
                        if (int.Parse(TempData["Count"].ToString()) >= 5)
                        {
                            random = new Random();
                            int iNumber = random.Next(10000, 99999);
 
                             ViewBag.Message =  "Nhập sai quá nhiều ! Vui lòng đợi";
                             return View("LoginAdmin");

                        }

                        ViewBag.Messages = "Tên đăng nhập hoặc mật khẩu không đúng";
                        return View("LoginAdmin", model);

                }
            }
            return View("LoginAdmin");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("USER_SESSION");

            return RedirectToAction("LoginAdmin" ,"Login");
        }
    }
}
