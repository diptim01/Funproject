using HRPartners.Models;
using System;
using System.Collections.Generic;
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
    }
}