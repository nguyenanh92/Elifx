using Common.Constants;
using Database.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Admin.Common;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model , int? remember)
        {
            if (ModelState.IsValid)
            {
                var dto = new UserDto();
                var result = dto.Login(model.UserName , model.Password);
                if (result)
                {
                    var user = dto.GetById(model.UserName);

                    var userSession = new UserSession();

                    userSession.UserName = user.Username;
                    userSession.ID = user.ID;
                    Session.Add(UserCons.USER_SESSION, userSession);

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi đăng nhập.Vui lòng thử lại");
                }

            }
            return RedirectToAction("Index", "Login");
        }
    }
}