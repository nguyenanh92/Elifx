using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataLibrary.Config;
using DataLibrary.Database;
using DataLibrary.Utility;
using PCar.Areas.Administrator.Models;
using PCar.Models;


namespace PCar.Areas.Administrator.Controllers
{
    public class ArticleController : IBaseController
    {
        // GET: /Administrator/Article/
        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang Bài Viết";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateIndex()
        {
            using (var db = new MyDbDataContext())
            {
                var records =
                    db.Articles.Join(db.Menus.Where(a => a.Status),
                        a => a.MenuID,
                        b => b.ID, (a, b) => new { a }).ToList();
                foreach (var record in records)
                {
                    string itemAdv = Request.Params[string.Format("Sort[{0}].Index", record.a.ID)];
                    int index;
                    int.TryParse(itemAdv, out index);
                    record.a.Index = index;
                    db.SubmitChanges();
                }
                TempData["Messages"] = "Sắp xếp thành công";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                using (var db = new MyDbDataContext())
                {
                    var listArticle =
                        db.Articles.Join(db.Menus.Where(a => a.Status),
                            a => a.MenuID, b => b.ID, (a, b) => new { a, b });
                    List<ArticleViewModel> records = listArticle.Select(a => new ArticleViewModel
                    {
                        ID = a.a.ID,
                        Title = a.a.Title,
                        TitleMenu = a.b.NameMenu,
                        Index = a.a.Index,
                        Status = a.a.Status,
                        Home = a.a.Home,
            
                    }).OrderByDescending(a => a.ID).Skip(jtStartIndex).Take(jtPageSize).ToList();
                    //Return result to jTable
                    return Json(new { Result = "OK", Records = records, TotalRecordCount = listArticle.Count() });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            LoadData();
            ViewBag.Title = "Thêm Bài Viết";
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ArticleDto model)
        {
            using (var db = new MyDbDataContext())
            {
                if (string.IsNullOrEmpty(model.Alias))
                {
                    model.Alias = StringHelper.ConvertToAlias(model.Title);
                }
                try
                {
                    var article = new Article
                    {
                        MenuID = model.MenuID,
                        Title = model.Title,
                        Alias = model.Alias,
                        Image = model.Image,
                        Description = model.Description,
                        Content = model.Content,
                        Index = 0,
                        MetaTitle = model.MetaTitle,
                        MetaDescription = model.Description,
                        Status = model.Status,
                        Home = model.Home,
   
                    };

                    db.Articles.InsertOnSubmit(article);
                    db.SubmitChanges();

                    TempData["Messages"] = "Thêm bài viết thành công";
                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    LoadData();
                    ViewBag.Messages = "Error: " + exception.Message;
                    return View();
                }
            }
            LoadData();
            return View();

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Title = "Cập nhật bài viết";
            using (var db = new MyDbDataContext())
            {
                Article detailArticle = db.Articles.FirstOrDefault(a => a.ID == id);

                if (detailArticle == null)
                {
                    TempData["Messages"] = "Bài viết không tồn tại";
                    return RedirectToAction("Index");
                }

                var artile = new ArticleDto
                {
                    ID = detailArticle.ID,
                    MenuID = detailArticle.MenuID,
                    Title = detailArticle.Title,
                    Alias = detailArticle.Alias,
                    Image = detailArticle.Image,
                    Description = detailArticle.Description,
                    Content = detailArticle.Content,
                    MetaTitle = detailArticle.MetaTitle,
                    MetaDescription = detailArticle.MetaDescription,
                    Status = detailArticle.Status,
                    Home = detailArticle.Home,
               

                };
                LoadData();
                return View(artile);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(ArticleDto model)
        {
            using (var db = new MyDbDataContext())
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.Alias))
                    {
                        model.Alias = StringHelper.ConvertToAlias(model.Alias);
                    }
                    try
                    {
                        Article article = db.Articles.FirstOrDefault(b => b.ID == model.ID);
                        if (article != null)
                        {
                            article.MenuID = model.MenuID;
                            article.Title = model.Title;
                            article.Alias = model.Alias;
                            article.Image = model.Image;
                            article.Description = model.Description;
                            article.Content = model.Content;
                            article.MetaTitle = string.IsNullOrEmpty(model.MetaTitle) ? model.Title : model.MetaTitle;
                            article.MetaDescription = string.IsNullOrEmpty(model.MetaDescription)
                                ? model.Title
                                : model.MetaDescription;
                            article.Status = model.Status;
                            article.Home = model.Home;
          

                            db.SubmitChanges();
                            TempData["Messages"] = "Cập nhật bài viết thành công";
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception exception)
                    {
                        LoadData();
                        ViewBag.Messages = "Lỗi: " + exception.Message;
                        return View();
                    }
                }
                LoadData();
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                using (var db = new MyDbDataContext())
                {
                    Article del = db.Articles.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {
                        db.Articles.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new { Result = "OK", Message = "Xóa bài viết thành công" });
                    }
                    return Json(new { Result = "ERROR", Message = "Bài viết không tồn tại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        public void LoadData()
        {
            var listMenu = new List<SelectListItem>
            {
                new SelectListItem {Value = "0", Text = "--Lựa chọn Menu--"}
            };
            var menus = new List<Menu>();

            menus =
                MenuController.GetListMenu(0).Where(
                    a =>
                        a.TypeMenu == SystemMenuType.Article ||
                        a.TypeMenu == SystemMenuType.About ||
                        a.TypeMenu == SystemMenuType.Location).ToList();

            foreach (Menu menu in menus)
            {
                string sub = "";
                for (int i = 0; i < menu.Level; i++)
                {
                    sub += "|--";
                }
                menu.NameMenu = sub + menu.NameMenu;
            }

            listMenu.AddRange(menus.OrderBy(a => a.Location).Select(a => new SelectListItem
            {
                Text = a.NameMenu,
                Value = a.ID.ToString()
            }).ToList());
            ViewBag.ListMenu = listMenu;
        }
    }
}