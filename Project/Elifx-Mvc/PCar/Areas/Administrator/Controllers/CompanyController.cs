using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Database;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using PCar.Areas.Administrator.Models;

namespace PCar.Areas.Administrator.Controllers
{
    public class CompanyController : IBaseController
    {
        public ActionResult Index()
        {
            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
            ViewBag.Title = "Trang Website";
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                using (var db = new MyDbDataContext())
                {
                    var list = db.Companies.Select(a => new
                    {
                        a.ID,
                        a.CompanyName,
                        a.Logo,
                        a.Image,
                        a.Email,
                        a.Hotline,
                        a.Phone,
                        a.Address,
                        a.MetaTitle
                    }).ToList();
                    //Return result to jTable
                    return Json(new { Result = "OK", Records = list, TotalRecordCount = list.Count() });
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
            using (var db = new MyDbDataContext())
            {
                if (db.Companies.Any())
                {
                    TempData["Messages"] = "Website đã tồn tại rồi";
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Title = "Thêm Khách sạn";
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CompanyViewModel model)
        {
            using (var db = new MyDbDataContext())
            {
                if (db.Companies.Any())
                {
                    TempData["Messages"] = "Website đã tồn tại rồi";
                    return RedirectToAction("Index");
                }
             
                    try
                    {
                        var hotel = new Company()
                        {
                            CompanyName = model.CompanyName,
                            Logo = model.Logo,
                            Image = model.Image,
                            Phone = model.Phone,
                            Description = model.Description,
                            Email = model.Email,
                            Address = model.Address,
                            Website = model.Website,
                            Facebook = model.FaceBook,
                            Instagram = model.Instagram,
                            Youtube = model.Youtube,
                            Copyright = model.CopyRight,
                            MetaTitle = model.MetaTitle,
                            MetaDescription = model.MetaDescription
                        };

                        db.Companies.InsertOnSubmit(hotel);
                        db.SubmitChanges();

                        TempData["Messages"] = "Thêm thành công";
                        return RedirectToAction("Index");
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Lỗi: " + exception.Message;
                        return View();
                    }
                }
                return View();
          
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Title = "Cập nhật ";
            using (var db = new MyDbDataContext())
            {
                Company hotel = db.Companies.FirstOrDefault(a => a.ID == id);

                if (hotel == null)
                {
                    TempData["Messages"] = "Không tồn tại";
                    return RedirectToAction("Index");
                }

                var eHotel = new CompanyViewModel
                {
                    CompanyName = hotel.CompanyName,
                    Logo = hotel.Logo,
                    Hotline = hotel.Hotline,
                    Image = hotel.Image,
                    Phone = hotel.Phone,
                    Email = hotel.Email,
                    Address = hotel.Address,
                    Website = hotel.Website,
                    zalo = hotel.Zalo,
                    FaceBook = hotel.Facebook,
                    Instagram = hotel.Instagram,
                    Youtube = hotel.Youtube,
                    CopyRight = hotel.Copyright,
                    MetaTitle = hotel.MetaTitle,
                    MetaDescription = hotel.MetaDescription
                };
                return View(eHotel);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(CompanyViewModel model)
        {
            using (var db = new MyDbDataContext())
            {
                  try
                    {
                        Company hotel = db.Companies.FirstOrDefault(b => b.ID == model.ID);
                        if (hotel != null)
                        {
                            hotel.CompanyName = model.CompanyName;
                            hotel.Logo = model.Logo;
                            hotel.Image = model.Image;
                            hotel.Phone = model.Phone;
                            hotel.Hotline = model.Hotline;
                            hotel.Email = model.Email;
                            hotel.Address = model.Address;
                            hotel.Website = model.Website;
                            hotel.Facebook = model.FaceBook;
                            hotel.Instagram = model.Instagram;
                            hotel.Youtube = model.Youtube;
                            hotel.Zalo = model.zalo;
                            hotel.Copyright = model.CopyRight;
                            hotel.MetaTitle = model.MetaTitle;
                            hotel.MetaDescription = model.MetaDescription;

                            db.SubmitChanges();
                            TempData["Messages"] = "Cập nhật thành công";
                            return RedirectToAction("Index");
                        }
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Messages = "Lỗi: " + exception.Message;
                        return View();
                    }
                }
                return View(model);
            
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                using (var db = new MyDbDataContext())
                {
                    Company del = db.Companies.FirstOrDefault(c => c.ID == id);
                    if (del != null)
                    {
                        db.Companies.DeleteOnSubmit(del);
                        db.SubmitChanges();
                        return Json(new { Result = "OK", Message = "Xóa thành công" });
                    }
                    return Json(new { Result = "ERROR", Message = "Không tồn tại" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }
    }
}
