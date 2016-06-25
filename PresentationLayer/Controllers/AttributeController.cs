using BusinessLayer;
using PresentationLayer.Helper;
using PresentationLayer.Models;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shared;


namespace PresentationLayer.Controllers
{
    public class AttributeController : BaseController
    {
        private IBLAttribute blAtr = new BLAttribute();
        private IBLGameObject blGob = new BLGameObject();

        // GET: Attribute
        public ActionResult Index()
        {
            List<AttributeModel> listModel = new List<AttributeModel>();
            try
            {
                List<DTAttribute> listAttribute = blAtr.getAllAttributes();
                foreach (DTAttribute attribute in listAttribute)
                {
                    listModel.Add(ConversionHelper.AttributeToModel(attribute));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
            return View(listModel);
        }

        public JsonResult IsAttributeNameAvailable(AttributeModel atr)
        {
            var idGame = Int32.Parse(Request.UrlReferrer.ToString().Substring(Request.UrlReferrer.ToString().IndexOf('=') + 1));

            return Json(!blAtr.isValid(atr.Name, atr.id, idGame), JsonRequestBehavior.AllowGet);
        }


        // GET: Attribute/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Attribute/Create
        public ActionResult Create(int idGameObject)
        {
            //List<DTGameObject> listGobBase = blGob.getAllGameObjects();
            //List<GameObjectModel> listGobModel = new List<GameObjectModel>();
            //foreach (DTGameObject gameobject in listGobBase)
            //{
            //    listGobModel.Add(GameObjectToModel(gameobject));
            //}
            //var list2 = new SelectList(listGobModel, "ID", "Name");
            //ViewData["GameObject"] = list2;

            AttributeModel model = new AttributeModel();
            model.ID_GameObject = idGameObject;
            return View(model);
        }

        // POST: Attribute/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            AttributeModel attributeModel = new AttributeModel();
            attributeModel.Name = collection.Get("Name");
            attributeModel.valor = collection.Get("valor");
            attributeModel.ID_GameObject = int.Parse(collection.Get("ID_GameObject"));
            attributeModel.Type = collection.Get("Type");
            try
            {


                DTAttribute attribute = new DTAttribute();
                attribute.nombre = attributeModel.Name;
                attribute.valor = attributeModel.valor;
                attribute.idGameObject = attributeModel.ID_GameObject;
                attribute.Type = attributeModel.Type;
                blAtr.addAttribute(attribute);
                return RedirectToAction("edit", "GameObject", new { id = attribute.idGameObject });


            }
            catch
            {
                cargarListaGameObjects();
                return View(attributeModel);
            }
        }
        private void cargarListaGameObjects()
        {
            List<DTGameObject> listGameObject = blGob.getAllGameObjects();
            List<GameObjectModel> listGameObjectModel = new List<GameObjectModel>();
            foreach (DTGameObject gameObject in listGameObject)
            {
                listGameObjectModel.Add(ConversionHelper.GameObjectToModel(gameObject));
            }
            ViewData["GameObject"] = new SelectList(listGameObjectModel, "ID", "Name");
        }

        // GET: Attribute/Edit/5
        public ActionResult Edit(int id = -1)
        {
            AttributeModel attributeteModel;
            try
            {
                cargarListaGameObjects();
                DTAttribute attribute = blAtr.getAttribute(id);
                attributeteModel = ConversionHelper.AttributeToModel(attribute);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return View(attributeteModel);
        }

        // POST: Attribute/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            AttributeModel attriuteModel = new AttributeModel();
            attriuteModel.Name = collection.Get("Name");
            attriuteModel.valor = (collection.Get("valor"));
            attriuteModel.Type = collection.Get("Type");
            try
            {
                DTAttribute atr = blAtr.getAttribute(id);
                atr.nombre = collection.Get("Name");
                atr.valor = collection.Get("valor");
                atr.Type = collection.Get("Type");
                blAtr.updateAttribute(atr);
                return RedirectToAction("edit", "GameObject", new { id = atr.idGameObject });
            }
            catch
            {
                cargarListaGameObjects();
                return View(attriuteModel);
            }
        }

        // GET: Attribute/Delete/5
        public ActionResult Delete(int idGameObject, int id = -1)
        {
            try
            {
                blAtr.deleteAttribute(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return RedirectToAction("Edit", "GameObject", new { id = idGameObject });
        }

        //// POST: Attribute/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index", "Game", null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("error desconocido");;
        //    }
        //}
    }
}
