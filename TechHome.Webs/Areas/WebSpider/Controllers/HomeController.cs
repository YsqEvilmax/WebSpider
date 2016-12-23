using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechHome.Webs.Areas.WebSpider.Controllers
{
    public class HomeController : Controller
    {
        // GET: WebSpider/Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: WebSpider/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WebSpider/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebSpider/Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WebSpider/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WebSpider/Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WebSpider/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WebSpider/Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
