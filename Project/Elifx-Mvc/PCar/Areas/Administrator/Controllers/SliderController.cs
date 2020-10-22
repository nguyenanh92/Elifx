//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using DataLibrary.Config;
//using DataLibrary.Database;
//using PCar.Areas.Administrator.Models;
//using PCar.Models;

//namespace PCar.Areas.Administrator.Controllers
//{
//    public class SliderController : Controller
//    {
//        //
//        // GET: /Administrator/Slider/

//        public ActionResult Index()
//        {
//            ViewBag.Messages = CommentController.Messages(TempData["Messages"]);
//            ViewBag.Title = "Trang Slider ảnh";
//            return View();
//        }

//        [HttpPost]
//        public ActionResult UpdateIndex()
//        {
//            using (var db = new MyDbDataContext())
//            {
//                List<Slider> records =
//                    db.Sliders.Where(r => r.Status).ToList();
//                foreach (Slider record in records)
//                {
//                    string itemAdv = Request.Params[string.Format("Sort[{0}].Index", record.ID)];
//                    int index;
//                    int.TryParse(itemAdv, out index);
//                    record.Index = index;
//                    db.SubmitChanges();
//                }
//                TempData["Messages"] = "Sắp xếp slide thành công";
//                return RedirectToAction("Index");
//            }
//        }

//        [HttpPost]
//        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
//        {
//            try
//            {
//                using (var db = new MyDbDataContext())
//                {
//                    List<Slider> listSlider =
//                        db.Sliders.Where(a => a.Status).ToList();
//                    List<SliderViewModel> records = listSlider.Select(a => new SliderViewModel
//                    {
//                        ID = a.ID,
//                        Title = a.Title,
//                        Image = a.Image,
//                        Link = a.Link,
//                        Status = a.Status,
//                        Index = a.Index,
//                        ViewAll = a.ViewAll,
//                    }).OrderBy(c => c.Index).Skip(jtStartIndex).Take(jtPageSize).ToList();
//                    //Return result to jTable
//                    return Json(new { Result = "OK", Records = records, TotalRecordCount = listSlider.Count });
//                }
//            }
//            catch (Exception ex)
//            {
//                return Json(new { Result = "ERROR", ex.Message });
//            }
//        }

//        [HttpGet]
//        public ActionResult Create()
//        {
//            ViewBag.Title = "Thêm mới slider";
//            ViewBag.Menus = LoadData("");
//            var model = new SliderDto();
//            model.ViewAll = true;
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult Create(SliderDto model)
//        {
//            using (var db = new MyDbDataContext())
//            {
//                try
//                {
//                    if (model.ViewAll)
//                    {
//                        model.MenuIDs = "";
//                    }
//                    var slider = new Slider
//                    {
//                        LanguageID = "vi",
//                        Title = model.Title,
//                        MenuIDs = model.MenuIDs,
//                        Image = model.Image,
//                        Link = model.Link,
//                        Index = 0,
//                        ViewAll = model.ViewAll,
//                        Status = model.Status,
//                        Content = model.Content,
//                    };

//                    db.Sliders.InsertOnSubmit(slider);
//                    db.SubmitChanges();

//                    TempData["Messages"] = "Thêm mới slider thành công";
//                    return RedirectToAction("Index");
//                }
//                catch (Exception exception)
//                {
//                    ViewBag.Menus = LoadData(model.MenuIDs);
//                    ViewBag.Messages = "Error: " + exception.Message;
//                    return View(model);
//                }

//                ViewBag.Menus = LoadData(model.MenuIDs);
//                return View(model);
//            }
//        }

//        [HttpGet]
//        public ActionResult Update(int id)
//        {
//            using (var db = new MyDbDataContext())
//            {
//                Slider detailSlider = db.Sliders.FirstOrDefault(a => a.ID == id);
//                if (detailSlider == null)
//                {
//                    TempData["Messages"] = "Slider không tồn tại";
//                    return RedirectToAction("Index");
//                }
//                var slider = new SliderDto
//                {
//                    ID = detailSlider.ID,
//                    Title = detailSlider.Title,
//                    MenuIDs = detailSlider.MenuIDs,
//                    Image = detailSlider.Image,
//                    Link = detailSlider.Link,
//                    ViewAll = detailSlider.ViewAll,
//                    Status = detailSlider.Status,
//                    Content = detailSlider.Content,
//                };
//                ViewBag.Title = "Sửa slide";
//                ViewBag.Menus = LoadData(slider.MenuIDs);
//                return View(slider);
//            }
//        }

//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult Update(SliderDto model)
//        {

//            try
//            {
//                using (var db = new MyDbDataContext())
//                {
//                    Slider slider = db.Sliders.FirstOrDefault(b => b.ID == model.ID);
//                    if (model.ViewAll)
//                    {
//                        model.MenuIDs = "";
//                    }

//                    if (slider != null)
//                    {
//                        slider.Title = model.Title;
//                        slider.Image = model.Image;
//                        slider.Link = model.Link;
//                        slider.Status = model.Status;
//                        slider.ViewAll = model.ViewAll;
//                        slider.MenuIDs = model.MenuIDs;
//                        slider.LanguageID = "vi";
//                        slider.Content = model.Content;
//                        db.SubmitChanges();
//                        TempData["Messages"] = "Sửa slide thành công.";
//                        return RedirectToAction("Index");
//                    }
//                }
//            }
//            catch (Exception exception)
//            {
//                ViewBag.Menus = LoadData(model.MenuIDs);
//                ViewBag.Messages = "Error: " + exception.Message;
//                return View(model);
//            }

//            ViewBag.Menus = LoadData(model.MenuIDs);
//            return View(model);
//        }

//        [HttpPost]
//        public JsonResult Delete(int id)
//        {
//            try
//            {
//                using (var db = new MyDbDataContext())
//                {
//                    Slider del = db.Sliders.FirstOrDefault(c => c.ID == id);
//                    if (del != null)
//                    {
//                        db.Sliders.DeleteOnSubmit(del);
//                        db.SubmitChanges();
//                        return Json(new { Result = "OK", Message = "Xóa slide thành công" });
//                    }
//                    return Json(new { Result = "ERROR", Message = "Slide không tồn tại" });
//                }
//            }
//            catch (Exception ex)
//            {
//                return Json(new { Result = "ERROR", ex.Message });
//            }
//        }

//        //Lấy danh sách menu khi thay đổi hotel
//        public List<MenuCheck> LoadData(string menuIDs)
//        {
//            //check logged
//            var menuIsSelect = new List<MenuCheck>();
//            List<Menu> listMenu =
//                MenuController.GetListMenu(SystemMenuLocation.ListLocationMenu().ToList()[0].LocationId);
//            var listMenuIds = new int[1];
//            if (string.IsNullOrEmpty(menuIDs) == false)
//            {
//                listMenuIds =
//                    menuIDs.Substring(0, menuIDs.Length - 1)
//                        .Split(',')
//                        .Select(n => Convert.ToInt32(n))
//                        .ToArray();
//            }
//            menuIsSelect =
//                listMenu.Select(a => new MenuCheck
//                {
//                    Checked = listMenuIds.Contains(a.ID) ? "checked" : "",
//                    Level = a.Level,
//                    ID = a.ID,
//                    Title = a.Title
//                }).ToList();
//            return menuIsSelect;
//        }
//    }
//}
