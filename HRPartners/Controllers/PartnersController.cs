using HRPartners.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPartners.Controllers
{
    public class PartnersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Partners
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PartnerModel partnerModel)
        {
            if (ModelState.IsValid)
            {
                db.PartnerModel.Add(partnerModel);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult TestFileUploadsAndForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestFileUploadsAndForm(string userName, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                if (!Path.GetExtension(file.FileName).Contains(".jpg"))
                {
                    ViewBag.ErrorMsg = "Unknown format";
                    return View("");
                }
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(file.FileName));
                    if (!System.IO.Directory.Exists(Server.MapPath("~/Images/")))
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Images"));
                    }
                    file.SaveAs(path);
                    ViewBag.ErrorMsg = "Successfully saved" + userName;
                    var imagePath =  Path.GetFileName(file.FileName);
                    ViewBag.myimage = imagePath;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMsg = ex.Message;
                  
                }
            }
            return View();
        }

        [HttpPost]
        public JsonResult aResponse(string okay)
        {
            if (okay != null) {
                Hello hello = new Hello()
                {
                    name = "Alokan Oladipo",
                    Id ="007"
                };
                return Json(hello);
            }
            else
                return Json("Not working");

        }

      
    }

    public class Hello
    {
        public string name { get; set; }

        public string Id { get; set; }
    }
}