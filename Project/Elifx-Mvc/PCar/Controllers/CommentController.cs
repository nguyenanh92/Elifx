using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Config;
using DataLibrary.Database;
using PCar.Models;
using TeamplateHotel.Models;

namespace PCar.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        //Chi tiết khách sạn
        public static Company DetailWebsite()
        {
            using (var db = new MyDbDataContext())
            {
                var hotel =
                    db.Companies.FirstOrDefault() ??
                    new Company();
                return hotel;
            }
        }
        //Danh sách Main menu
        public static List<Menu> GetMainMenus()
        {
            using (var db = new MyDbDataContext())
            {
                List<Menu> menus = db.Menus.Where(a => a.Status && a.Location == SystemMenuLocation.MainMenu).OrderBy(a => a.Index).ToList();
                return menus;
            }
        }
        //Danh sách Second menu
        public static List<Menu> GetSecondMenus()
        {
            using (var db = new MyDbDataContext())
            {
                List<Menu> menufooter = db.Menus.Where(a => a.Status && a.Location == SystemMenuLocation.SecondMenu).ToList();
                return menufooter;
            }
        }


        public static List<Article> GetArticles(int menuId)
        {
            using (var db = new MyDbDataContext())
            {
                List<Article> articles = db.Articles.Where(a => a.MenuID == menuId && a.Status).OrderBy(a => a.Index).ToList();
                foreach (var article in articles)
                {
                    article.MenuAlias = article.MenuAlias;
                }
                return articles;
            }
        }
        //Lấy danh sách bài viết

        public static List<ShowObject> LstArticles()
        {
            using (var db = new MyDbDataContext())
            {
                //List<Article> articles = db.Articles.Where(a => a.Status && a.Home).ToList();

                var menucheck = db.Menus.Select(a => a.ID).ToList();

                List<ShowObject> aList = db.Articles.Where(a => a.Home && a.Status)
                    .Join(db.Menus.Where(a => a.Status), a => a.MenuID, b => b.ID,
                        (a, b) => new ShowObject
                        {
                            ID = a.ID,
                            Alias = a.Alias,
                            MenuAlias = b.Alias,
                            Title = a.Title,
                            Index = a.Index,
                            Image = a.Image,
                            Description = a.Description,
                            //Content = a.Content
                        }).OrderByDescending(a => a.ID).ToList();
                return aList;
            }
        }

        //Chi tiết bài viết
        public static DetailArticle Detail_Article(int id)
        {
            using (var db = new MyDbDataContext())
            {
                Article article = db.Articles.FirstOrDefault(a => a.ID == id && a.Status) ?? new Article();
                List<Article> articles = db.Articles.Where(a => a.MenuID == article.MenuID && a.Status && a.ID != article.ID).OrderBy(a => a.Index).ToList();
                var user = db.Users.FirstOrDefault(a => a.ID == article.AuthorID);
                foreach (var item in articles)
                {
                    item.MenuAlias = article.Menu.Alias;
                    item.Author = user.FullName;
                }
                DetailArticle detailArticle = new DetailArticle()
                {
                    Author = user.FullName,
                    Article = article,
                    Articles = articles
                };
                return detailArticle;
            }
        }

    }
}
