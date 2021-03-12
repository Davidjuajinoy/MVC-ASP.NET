using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OddeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }


        // GET: Greeting/Details/5
        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            if (model == null)
            {
                //return RedirectToAction("Index");
                return View("Not_found");
            }
            return View(model);
        }

        // GET: Greeting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Greeting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurante)
        {
            try
            {
                // TODO: Add insert logic here

                /*
                 * UNA FORMA DE VALIDAR
                 * if (String.IsNullOrEmpty(restaurante.Name))
                 {
                     ModelState.AddModelError(nameof(restaurante.Name), "El nombre es requerido");
                 }

                 if (ModelState.IsValid)
                 {
                      db.Add(restaurante);
                      return RedirectToAction("Index");        
                 }
                 return View();*/
                if (ModelState.IsValid)
                {
                    db.Add(restaurante);
                    //return RedirectToAction("Details", new { id = restaurante.Id });
                    TempData["Mensaje"] = "Creado correctamente";
                    return RedirectToAction("Index");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: Greeting/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                //return RedirectToAction("Index");
                return View("Not_found");
            }
            return View(model);
        }

        // POST: Greeting/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurante)
        {
            try
            {
                db.Edit(restaurante);
                // TODO: Add update logic here
                
                TempData["Mensaje"] = "Editado correctamente";


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
            var model = db.Get(id);
            if (model == null)
            {
                return View("Not_found");
            }
            
            return View(model);

        }

        // POST: Greeting/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Delete(id);
                TempData["Mensaje"] = "Borrado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}