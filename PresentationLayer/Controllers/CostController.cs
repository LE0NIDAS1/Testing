using BusinessLayer;
using BusinessLayer.Interface;
using PresentationLayer.Helper;
using PresentationLayer.Models;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PresentationLayer.Controllers
{
    public class CostController : BaseController
    {
        private IBLCost blCost = new BLCost();
        private IBLResource blRes = new BLResource();
        private IBLGameObject blGob = new BLGameObject();

        // GET: Cost
        public ActionResult Index()
        {
            List<CostModel> listModel = new List<CostModel>();
            try
            {
                List<DTCost> listCost = blCost.getAllCosts();
                foreach (DTCost cost in listCost)
                {
                    listModel.Add(ConversionHelper.CostToModel(cost));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
            return View(listModel);
        }

        // GET: Cost/Create
        public ActionResult Create(int idGameObject, int idGame)
        {

            cargarListaRecursos(idGame);

            CostModel model = new CostModel();
            model.ID_GameObject = idGameObject;
            return View(model);
        }


        private void cargarListaRecursos(int idGame)
        {
            List<DTResource> listResBase = blRes.getAllResources();
            List<ResourceModel> listResModel = new List<ResourceModel>();
            foreach (DTResource resource in listResBase)
            {
                if (resource.idGame == idGame)
                {
                    listResModel.Add(ConversionHelper.ResourceToModel(resource));
                }
            }
            ViewData["Resource"] = new SelectList(listResModel, "ID", "Name");
        }



        // POST: Cost/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            CostModel costModel = new CostModel();
            costModel.ID_GameObject = int.Parse(collection.Get("id_GameObject"));
            costModel.id_Resource = int.Parse(collection.Get("id_Resource"));
            costModel.cant = int.Parse(collection.Get("cant"));
            try
            {
                DTCost cost = new DTCost();
                cost.idGameObject = costModel.ID_GameObject;
                cost.idResource = costModel.id_Resource;
                cost.cantidad = costModel.cant;
                blCost.addCost(cost);
                return RedirectToAction("Index", "Game", null);
            }
            catch
            {
                
                //cargarListaRecursos(costModel.i);

                return View(costModel);
            }
        }
        // GET: Cost/Edit/5
        public ActionResult Edit(int id =-1)
        {
            CostModel costeModel;
            try
            {
                //cargarListaRecursos(2);
                DTCost cost = blCost.getCost(id);
                costeModel = ConversionHelper.CostToModel(cost);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return View(costeModel);

        }

        // POST: Cost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            CostModel costModel = new CostModel();
            //costModel.id_Resource = int.Parse(collection.Get("id_Resource"));
            //costModel.cant = int.Parse(collection.Get("cant"));
            try
            {
                DTCost cost = blCost.getCost(id); ;
                //cost.idResource = int.Parse(collection.Get("id_Resource"));
                cost.cantidad = int.Parse(collection.Get("cant"));
                blCost.updateCost(cost);
                return RedirectToAction("Index", "Game", null);
            }
            catch
            {
                //cargarListaRecursos(2);
                return View(costModel);
            }
        }

        // GET: Cost/Delete/5
        public ActionResult Delete(int idGameObject, int id=-1)
        {
            try
            {
                blCost.deleteCost(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return RedirectToAction("Index", "Game", null);
        }

        // POST: Cost/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("error desconocido");;
        //    }
        //}
    }
}