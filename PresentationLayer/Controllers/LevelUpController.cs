using BusinessLayer;
using BusinessLayer.Implementation;
using BusinessLayer.Interface;
using PresentationLayer.Helper;
using PresentationLayer.Models;
using Shared.ActionEntities;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PresentationLayer.Controllers
{
    public class LevelUpController : ActionConfigController
    {
        private IBLActionConfig blAction = new BLActionConfig();
        private IBLLevelUp blLevel = new BLLevelUp();
        private IBLGameObject blGob = new BLGameObject();
        private IBLAttribute blat = new BLAttribute();

        // GET: LevelUp/Create
        public ActionResult Create2(int idGame=-1)
        {
            try
            {
                List<DTGameObject> listGob = blAction.getAllGOBForGame(idGame);
                ViewData["GameObject"] = new SelectList(listGob.Select(x => ConversionHelper.GameObjectToModel(x)), "ID", "Name"); ;
                List<DTAttribute> listAtt = blAction.getAllAttributesForGOB(int.Parse(Request.QueryString["idGame"]));

                ViewData["Attributes"] = new List<AttributeModel>();

                cargarListaTipoAccion();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return View(new LevelUpModel() { IDGame = idGame });
        }

        public ActionResult Create3(int idGame, LevelUpModel model)
        {
            try
            {
                List<DTGameObject> listGob = blAction.getAllGOBForGame(idGame);
                ViewData["GameObject"] = new SelectList(listGob.Select(x => ConversionHelper.GameObjectToModel(x)), "ID", "Name"); ;

                //List<DTAttribute> listAtt = blAction.getAllAttributesForGOB(int.Parse(Request.QueryString["idGame"]));
                //List<DTAttribute> listAtt = listGob.Find(x => x.id.Equals(model.ID_GAMEOBJECT)).attributes;
                //ViewData["Attributes"] = listAtt.Count > 0 ? listAtt.Select(x => ConversionHelper.AttributeToModel(x)).ToList() : new List<AttributeModel>();

                cargarListaTipoAccion();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
            return View("Create2", model);
        }

        // POST: LevelUp/Create
        [HttpPost]
        public ActionResult Create4(LevelUpModel model, FormCollection collection)
        {
            try
            {
                DTLevelUpConfig level = new DTLevelUpConfig();
                level.IDGame = model.IDGame;
                //level.IDGameObject = model.ID_GAMEOBJECT;
                level.LevelUpCostrate = model.LevelUpCostRate;
                level.LevelUpGenerateRate = model.LevelUpGenerateRate;
                level.attributesRate = model.attributesRate;
                //model.GameObject = ConversionHelper.GameObjectToModel(blGob.getGameObject(model.ID_GAMEOBJECT));
                List<DTAttribute> listAtt = new List<DTAttribute>();
                var idAtrSelected = collection.Get("Attribute").Split(',');
                foreach (String id in idAtrSelected)
                {
                    listAtt.Add(blat.getAttribute(int.Parse(id)));
                }
                level.attributes = listAtt;
                blLevel.create(level);                
            }
            catch (Exception ex)
            {
                throw new Exception("error desconocido");;
            }
            return RedirectToAction("Create2", "Levelup", model);
        }

        public ActionResult Reload(LevelUpModel model)
        {
            return Create3(model.IDGame, model);
        }
    }
}
