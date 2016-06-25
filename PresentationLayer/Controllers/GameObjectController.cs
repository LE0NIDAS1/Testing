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
    public class GameObjectController : BaseController
    {
        private IBLGameObject blGob = new BLGameObject();

        private IBLCategory blCat = new BLCategory();

        // GET: GameObject
        public ActionResult Index()
        {
            List<GameObjectModel> listModel = new List<GameObjectModel>();
            try
            {
                List<DTGameObject> listGameObject = blGob.getAllGameObjects();
                foreach (DTGameObject gameobject in listGameObject)
                {
                    listModel.Add(ConversionHelper.GameObjectToModel(gameobject));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
            return View(listModel);
        }


        public JsonResult IsGameObjectNameAvailable(GameObjectModel gom)
        {
            var idGame = Int32.Parse(Request.UrlReferrer.ToString().Substring(Request.UrlReferrer.ToString().IndexOf('=') + 1));
            return Json(!blGob.isValid(gom.Name, gom.Id, idGame, gom.IdCategory), JsonRequestBehavior.AllowGet);
        }

        // GET: GameObject/Create
        public ActionResult Create(int idGame)
        {
            List<DTCategory> listBase = blCat.getAllCategories();
            try
            {
                var listCategory = new List<CategoryModel>();
                foreach (DTCategory category in listBase)
                {
                    if (category.idGame == idGame)
                    {
                        listCategory.Add(ConversionHelper.CategoryToModel(category));
                    }
                }
                var list = new SelectList(listCategory, "ID", "Name");
                ViewData["Categoria"] = list;
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }

            return View();
        }

        // POST: GameObject/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DTGameObject gob = new DTGameObject();
                gob.name = collection.Get("Name");
                gob.description = collection.Get("Description");
               
                gob.idCategory = Int32.Parse(collection.Get("IDCategory"));
                blGob.addGameObject(gob);
                return RedirectToAction("Index", "Game", null);
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
        }

        // GET: GameObject/Edit/5
        public ActionResult Edit(int id = -1)
        {
            GameObjectModel gobModel = new GameObjectModel();

            try
            {
                DTGameObject gob = blGob.getGameObject(id);
                gobModel.Name = gob.name;
                gobModel.Description = gob.description;
                gobModel.Id = gob.id;
                gobModel.IdCategory = gob.idCategory;
                string url = "";
               
                gobModel.Image = url;
                //gobModel.IdCategory = gob.idCategory;
                cargarListaCategorias();


                List<AttributeModel> listAttModel = new List<AttributeModel>();
                foreach (DTAttribute attribute in gob.attributes)
                {
                    listAttModel.Add(ConversionHelper.AttributeToModel(attribute));
                }
                gobModel.attributes = listAttModel;


                List<CostModel> listCostModel = new List<CostModel>();
                foreach (DTCost cost in gob.costes)
                {
                    listCostModel.Add(ConversionHelper.CostToModel(cost));
                }
                gobModel.costes = listCostModel;

                List<GenerateModel> listGenerateModel = new List<GenerateModel>();
                foreach (DTGenerate generate in gob.generates)
                {
                    listGenerateModel.Add(ConversionHelper.GenerateToModel(generate));
                }
                gobModel.generates = listGenerateModel;

            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return View(gobModel);
        }


        private void cargarListaCategorias()
        {
            List<DTCategory> listCatBase = blCat.getAllCategories();
            List<CategoryModel> listCatModel = new List<CategoryModel>();
            foreach (DTCategory category in listCatBase)
            {
                listCatModel.Add(ConversionHelper.CategoryToModel(category));
            }
            ViewData["Categoria"] = new SelectList(listCatModel, "ID", "Name");
        }

        // POST: GameObject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            GameObjectModel gobModel = new GameObjectModel();
            DTGameObject gob = blGob.getGameObject(id);
            gob.name = collection.Get("name");
            gob.description = collection.Get("description");
            
            gob.idCategory = Int32.Parse(collection.Get("idCategory"));
            //gobModel.IdCategory = gob.idCategory;
            cargarListaCategorias();

            List<AttributeModel> listAttModel = new List<AttributeModel>();
            foreach (DTAttribute attribute in gob.attributes)
            {
                listAttModel.Add(ConversionHelper.AttributeToModel(attribute));
            }
            gobModel.attributes = listAttModel;


            List<CostModel> listCostModel = new List<CostModel>();
            foreach (DTCost cost in gob.costes)
            {
                listCostModel.Add(ConversionHelper.CostToModel(cost));
            }
            gobModel.costes = listCostModel;

            List<GenerateModel> listGenerateModel = new List<GenerateModel>();
            foreach (DTGenerate generate in gob.generates)
            {
                listGenerateModel.Add(ConversionHelper.GenerateToModel(generate));
            }
            gobModel.generates = listGenerateModel;
            blGob.updateGameObject(gob);
            return RedirectToAction("Index", "Game", null);
        }

        // GET: GameObject/Delete/5
        public ActionResult Delete(int id = -1)
        {
            try
            {
                blGob.deleteGameObject(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return RedirectToAction("Index", "Game", null);
        }


        // POST: GameObject/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{

        //    try
        //    {                
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
