using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Config;
using DataLibrary.Database;

namespace PCar.Controllers
{
    public class ContactHController : Controller
    {
        //
        // GET: /Contact/


        [HttpPost]
        public ActionResult SubmitContact(Contact model)
        {
            model.CreateDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                using (var db = new MyDbDataContext())
                {
                    db.Contacts.InsertOnSubmit(model);
                    db.SubmitChanges();

                    SendEmail sendEmail =
                        db.SendEmails.FirstOrDefault(
                            a => a.Type == TypeSendEmail.Contact);
                    Company hotel = CommentController.DetailWebsite();

                    sendEmail.Title = sendEmail.Title.Replace("{CompanyName}", hotel.CompanyName);
                    string content = sendEmail.Content;
                     content = content.Replace("{FName}", model.FirstName);
                    content = content.Replace("{LastName}", model.LastName);
                    content = content.Replace("{Tel}", model.Phone);
                    content = content.Replace("{Email}", model.Email);
                    content = content.Replace("{Message}", model.Message);
 
                    content = content.Replace("{CompanyName}", hotel.CompanyName);
                    content = content.Replace("{Phone}", hotel.Phone);
                    content = content.Replace("{EmailCpm}", hotel.Email);
                    content = content.Replace("{AddressCpm}", hotel.Address);
                    content = content.Replace("{Website}", hotel.Website);

                    MailHelper.SendMail(model.Email, sendEmail.Title, content);
                    MailHelper.SendMail(hotel.Email, hotel.CompanyName + " Contact of " + model.FirstName, content);
                    return Redirect("/Contact/Messages?status=success");
                }
            }
            return Redirect("/Contact/Messages?status=error");
        }

        [HttpGet]
        public ActionResult Messages()
        {
            using (var db = new MyDbDataContext())
            {
                SendEmail sendEmail =
                       db.SendEmails.FirstOrDefault(
                           a => a.Type == TypeSendEmail.Contact);

                string status = Request.Params["status"];
                ViewBag.Messages = "";
                if (string.IsNullOrEmpty(status) == false)
                {
                    if (status.Equals("success"))
                    {
                        ViewBag.Messages = sendEmail.Success;
                    }
                    else
                    {
                        ViewBag.Messages = sendEmail.Error;
                    }
                }
                else
                {
                    ViewBag.Messages = sendEmail.Error;
                }
                return View();
            }
        }

    }
}
