using BusinessLayer;
using BusinessLayer.Implementation;
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
    public class InitialResourceController : Controller
    {
        private IBLInitialResource blInitialResource = new BLInitialResource();
        private IBLResource blRes = new BLResource();
        //private IBLInitialInstance blInitialInstance = new BLInitialInstance();
        // GET: InitialResource
        public ActionResult Index(int idGame)
        {

            List<InitialResourceModel> listModel = new List<InitialResourceModel>();
            try
            {
                List<DTInitialResource> listInitialResources = blInitialResource.getAllInitialResource();
                foreach (DTInitialResource initialInitialResource in listInitialResources)
                {
                    if (initialInitialResource.idGame == idGame)
                    {
                        initialInitialResource.Name = blRes.getResource(initialInitialResource.idResource).name;
                        listModel.Add(ConversionHelper.InitialResourceToModel(initialInitialResource));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
            return View(listModel);
        }

        // GET: InitialResource/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InitialResource/Create
        public ActionResult Create(int idGame)
        {
            {
                List<DTResource> listBase = blRes.getAllResources();
                try
                {
                    var listResource = new List<ResourceModel>();
                    foreach (DTResource resources in listBase)
                    {
                        if (resources.idGame == idGame)
                        {
                            listResource.Add(ConversionHelper.ResourceToModel(resources));
                        }
                    }
                    var list = new SelectList(listResource, "ID", "Name");
                    ViewData["Resource"] = list;

                   
                    InitialResourceModel model = new InitialResourceModel();
                    model.IdGame = idGame;
                    return View(model);
                }
                catch
                {

                }
                return View();

            }
        }

        // POST: InitialResource/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DTInitialResource iniResource = new DTInitialResource();
                iniResource.idGame = Int32.Parse(collection.Get("IdGame"));
                iniResource.idResource = Int32.Parse(collection.Get("IdResource")); ;
                iniResource.quantity = Int32.Parse(collection.Get("Quantity"));
                blInitialResource.addInitialResource(iniResource);

                return RedirectToAction("Index", "InitialResource", new { IdGame = iniResource.idGame });
            }
            catch
            {
                return View();
            }
        }

        // GET: InitialResource/Edit/5
        public ActionResult Edit(int id, int idGame)
        {

            InitialResourceModel model = new InitialResourceModel();
            model.IdGame = idGame;
            return View(model);
        }

        // POST: InitialResource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                DTInitialResource iniResource = new DTInitialResource();
                iniResource.idGame = Int32.Parse(collection.Get("IdGame"));
                iniResource.idResource = id;
                iniResource.quantity = Int32.Parse(collection.Get("Quantity"));
                blInitialResource.updateInitialResource(iniResource);


                return RedirectToAction("Index", "InitialResource", new { IdGame = iniResource.idGame });
            }
            catch
            {
                return View();
            }
        }

        // GET: InitialResource/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InitialResource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index", "Game", null);
            }
            catch
            {
                return View();
            }
        }
    }
}
