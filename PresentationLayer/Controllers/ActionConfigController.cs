using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class ActionConfigController : BaseController
    {
        // GET: ActionConfig
        public ActionResult Index()
        {
            return View();
        }

        // GET: ActionConfig/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActionConfig/Create
        public ActionResult Create(int idGame)
        {
            cargarListaTipoAccion();
            return View(new ActionConfigModel() { IDGame = idGame });
        }

        protected void cargarListaTipoAccion()
        {
            List<String> listAction = new List<string>();
            listAction.Add("Select Action...");
            listAction.Add("Level Up");
            listAction.Add("Atacar");
            listAction.Add("Crear");
            var list2 = new SelectList(listAction);
            ViewData["ActionConfig"] = list2;
        }
       
        // POST: ActionConfig/Create
        //[HttpPost]
        //public ActionResult Create(ActionConfigModel model)
        //{
        //    try
        //    {
        //        switch (model.TypeAction) {
        //            case "Level Up":
        //                return RedirectToAction("Create2", "LevelUp", model);
        //            case "Crear":
        //                return RedirectToAction("CreateActionCreate", "Create", model);
        //            default:
        //                break;
        //        }

        //        return View();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ActionConfig/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActionConfig/Edit/5
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

        // GET: ActionConfig/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActionConfig/Delete/5
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
