using BusinessLayer.Implementation;
using BusinessLayer.Interface;
using PresentationLayer.Models.ActionModels;
using Shared.ActionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PresentationLayer.Controllers
{
    public class SimpleAttackController : ActionConfigController
    {

        private IBLAttack blAttack = new BLAttack();
        // GET: SimpleAttack
        public ActionResult Index()
        {
            return View();
        }



        // GET: SimpleAttack/Create
        public ActionResult CreateSimpleAttack(int idGame)
        {
            try
            {
                SimpleAttackModel model = new SimpleAttackModel();
                model.ID_GAME_FK = idGame;
                cargarListaTipoAccion();
                return View(model);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }

        }

        // POST: SimpleAttack/Create
        [HttpPost]
        public ActionResult CreateSimpleAttack(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                DTSimpleAttack sAttackDT = new DTSimpleAttack();
                //sAttackDT.ID_COST_FK = Int32.Parse(collection.Get("ID_COST_FK"));
                sAttackDT.ID_GAME_FK = Int32.Parse(collection.Get("ID_GAME_FK"));
                sAttackDT.Name = collection.Get("name");
                sAttackDT.PercentGain = Int32.Parse(collection.Get("PercentGain"));
                sAttackDT.PercentLoss = Int32.Parse(collection.Get("PercentLoss"));
                blAttack.addSimpleAttack(sAttackDT);
                return RedirectToAction("Index", "Game", null);
            }
            catch
            {
                return View();
            }
        }

        // GET: SimpleAttack/Edit/5
        public ActionResult EditSimpleAttack(int id, int idGame)
        {
            SimpleAttackModel model = new SimpleAttackModel();
            model.ID_GAME_FK = idGame;
            return View(model);
            
        }

        // POST: SimpleAttack/Edit/5
        [HttpPost]
        public ActionResult EditSimpleAttack(int id, FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SimpleAttack/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SimpleAttack/Delete/5
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
