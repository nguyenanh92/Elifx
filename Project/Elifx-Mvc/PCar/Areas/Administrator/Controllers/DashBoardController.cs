using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCar.Areas.Administrator.Controllers
{
     public class DashBoardController : IBaseController
    {
        //
        // GET: /Administrator/DashBoard/

        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            return View();
        }

    }
}
