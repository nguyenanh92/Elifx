using DataLibrary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Config;
using PCar.Models;

namespace PCar.Controllers
{
    public class HomePageController : Controller
    {
        //
        // GET: /HomePage/

        [HttpGet]
        public ActionResult Index(object aliasMenuSub, object idSub, object aliasSub)
        {
            var db = new MyDbDataContext();
            Company hotel = CommentController.DetailWebsite();
            ViewBag.MetaTitle = hotel.MetaTitle;
            ViewBag.MetaDesctiption = hotel.MetaDescription;
            ViewBag.OgImage = hotel.Image;

            if (aliasMenuSub.ToString() == "System.Object")
            {
                ViewBag.HomePage = true;
                return View("Index");
            }

            //Xác định menu => tìm ra Kiểu hiển thị của menu
            Menu menu = db.Menus.FirstOrDefault(a => a.Alias == aliasMenuSub.ToString());
            if (menu == null)
            {
                ViewBag.HomePage = true;
                return View("Index");
            }

            //Seo
            ViewBag.MetaTitle = menu.MetaTitle;
            ViewBag.MetaDesctiption = menu.MetaDescription;
            ViewBag.Menu = menu;

            switch (menu.TypeMenu)
            {
                case SystemMenuType.Article:
                    goto Trangbaiviet;
                case SystemMenuType.About:
                    return View("About");
                //case SystemMenuType.Contact:
                //    return View("Contact");
                default:
                    ViewBag.HomePage = true;
                    return View("Index");
            }

            #region "Trang bài viết"

            Trangbaiviet:
            if (idSub.ToString() != "System.Object")
            {
                int idArticle;
                int.TryParse(idSub.ToString(), out idArticle);
                DetailArticle detailArticle = CommentController.Detail_Article(idArticle);
                ViewBag.MetaTitle = detailArticle.Article.MetaTitle;
                ViewBag.MetaDesctiption = detailArticle.Article.MetaDescription;
                ViewBag.Images = detailArticle.Article.Image;
                return View("Article/DetailArticle", detailArticle);
            }

            //Danh sách bài viết
            List<Article> articles = CommentController.GetArticles(menu.ID);
            if (articles.Count == 1)
            {
                DetailArticle detailArticle = CommentController.Detail_Article(articles[0].ID);
                ViewBag.MetaTitle = detailArticle.Article.MetaTitle;
                ViewBag.MetaDesctiption = detailArticle.Article.MetaDescription;
                ViewBag.Images = detailArticle.Article.Image;
                return View("Article/DetailArticle", detailArticle);
            }

            return View("Article/ListArticle", articles);

            #endregion

        }
    }
}
