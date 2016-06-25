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
    public class InitialGameObjectController : Controller
    {
        private IBLInitialGameObject blInitialObject = new BLInitialGameObject();
        private IBLGameObject blGob = new BLGameObject();
        //private IBLInitialInstance blInitialInstance = new BLInitialInstance();
        private IBLCategory blCat = new BLCategory();

        // GET: InitialGameObject
        public ActionResult Index(int idGame)
        {
            //CategoryModel model = new CategoryModel();
            //model.ID_Game = idGame;
            //return View(model);

            

            List<InitialGameObjectModel> listModel = new List<InitialGameObjectModel>();
            try
            {
                List<DTInitialGameObject> listInitialGameObject = blInitialObject.getAllInitialGameObjects();
                foreach (DTInitialGameObject initialInitialGameObjects in listInitialGameObject)
                {
                    if (initialInitialGameObjects.idGame == idGame)
                    {
                        initialInitialGameObjects.Name = blGob.getGameObject(initialInitialGameObjects.idGameObject).name;
                        listModel.Add(ConversionHelper.InitialGameObjectToModel(initialInitialGameObjects));
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
            return View(listModel);
        }

        // GET: InitialGameObject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InitialGameObject/Create
        public ActionResult Create(int idGame)
        {
            try
            {

                List<DTCategory> listCat = blCat.getAllCategories();
                List<DTGameObject> listBase = blGob.getAllGameObjects();
                var listGameObjects = new List<GameObjectModel>();
                foreach (DTCategory cat in listCat)
                {
                    if (cat.idGame == idGame)
                    {
                        //listCat.Add(cat);

                        foreach (DTGameObject gameobjects in listBase)
                        {
                            if (cat.id == gameobjects.idCategory)
                            {
                                listGameObjects.Add(ConversionHelper.GameObjectToModel(gameobjects));
                            }
                        }
                    }
                }

                var list = new SelectList(listGameObjects, "ID", "Name");
                ViewData["GameObject"] = list;
                //obtener id instance
                
                InitialGameObjectModel model = new InitialGameObjectModel();
                model.IdGame = idGame;
                return View(model);
            }
            catch
            {

            }

            return View();

        }

        // POST: InitialGameObject/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {


                DTInitialGameObject iniGameObject = new DTInitialGameObject();
                iniGameObject.idGame = Int32.Parse(collection.Get("IdGame"));
                iniGameObject.idGameObject = Int32.Parse(collection.Get("IdGameObject"));
                iniGameObject.quantity = Int32.Parse(collection.Get("Quantity"));
                blInitialObject.addInitialGameObject(iniGameObject);

                return RedirectToAction("Index", "InitialGameObject", new { IdGame = iniGameObject.idGame });
            }
            catch
            {
                return View();
            }
        }

        // GET: InitialGameObject/Edit/5
        public ActionResult Edit(int id, int idGame)
        {
            //obtener id instance

            InitialGameObjectModel model = new InitialGameObjectModel();
            model.IdGame = idGame;
            return View(model);

        }

        // POST: InitialGameObject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                DTInitialGameObject iniGameObject = new DTInitialGameObject();
                iniGameObject.idGame = Int32.Parse(collection.Get("IdGame"));
                iniGameObject.idGameObject = id;
                iniGameObject.quantity = Int32.Parse(collection.Get("Quantity"));
                blInitialObject.updateInitialGameObject(iniGameObject);
                return RedirectToAction("Index", "InitialGameObject",  new { IdGame = iniGameObject.idGame });
            }
            catch
            {
                return View();
            }
        }

        // GET: InitialGameObject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InitialGameObject/Delete/5
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
