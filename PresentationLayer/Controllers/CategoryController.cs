using PresentationLayer.Models;
using Shared.JuegoEntities;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLayer;
using PresentationLayer.Helper;
using System;
using BusinessLayer.Implementation;



namespace PresentationLayer.Controllers
{
    public class CategoryController : BaseController
    {
        private IBLCategory blCat = new BLCategory();

        

        // GET: Resource
        public ActionResult Index()
        {
            List<CategoryModel> listModel = new List<CategoryModel>();
            try
            {
                List<DTCategory> listCategory = blCat.getAllCategories();
                foreach (DTCategory category in listCategory)
                {
                    listModel.Add(ConversionHelper.CategoryToModel(category));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
            return View(listModel);
        }


        // GET: Resource/Create
        public ActionResult Create(int idGame)
        {
            CategoryModel model = new CategoryModel();
            try
            {
                model.ID_Game = idGame;
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return View(model);
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DTCategory cat = new DTCategory();
                cat.name = collection.Get("Name");
                cat.toolTip = collection.Get("Tooltip");
                cat.image = "algo";
                cat.idGame = int.Parse(collection.Get("ID_Game"));
                blCat.addCategory(cat);
                return RedirectToAction("Edit", "Game", new { id = cat.idGame });
            }
            catch (Exception ex)
            {
                //return Create(int.Parse(collection.Get("IdGame")));
                throw new Exception("error desconocido");;
            }
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int id = -1)
        {
            CategoryModel catModel = new CategoryModel();
            try
            {
                DTCategory cat = blCat.getCategory(id);
                catModel.Name = cat.name;
                catModel.Tooltip = cat.toolTip;
                catModel.Id = cat.id;
                string url = "";
                if (!String.IsNullOrEmpty(cat.image))
                {
                    
                }
                catModel.Image = url;
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return View(catModel);

        }

        // POST: Resource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            DTCategory cat = blCat.getCategory(id);
            cat.name = collection.Get("name");
            cat.toolTip = collection.Get("tooltip");
            
            blCat.updateCategory(cat);
            try
            {
                return RedirectToAction("Edit", "Game", new { id = cat.idGame});
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int id =-1)
        {
            try
            {
                blCat.deleteCategory(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");; 
            }
            return RedirectToAction("Index", "Game", null);
        }

        //POST: Resource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            try
            {
                return RedirectToAction("Index", "Game", null);
            }
            catch
            {
                return View();
            }
        }

    }
}

