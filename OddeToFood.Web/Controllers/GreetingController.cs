using OddeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OddeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
    

        // GET: Greeting
        public ActionResult Index(String name)
        {
            var model = new GreetingViewModel();
            model.Name = name ?? "no puso parametro";

            //var name = HttpContext.Request.QueryString["name"];
            model.Message = ConfigurationManager.AppSettings["message"];
            return View(model);
        }

        // GET: Greeting/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Greeting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Greeting/Create
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

        // GET: Greeting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Greeting/Edit/5
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

        // GET: Greeting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Greeting/Delete/5
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
