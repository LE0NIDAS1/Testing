using BusinessLayer.Interface;
using BusinessLayer.Implementation;
using PresentationLayer.Models;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.Helper;
using BusinessLayer;
using Microsoft.AspNet.Identity;
using Shared.ActionEntities;


namespace PresentationLayer.Controllers
{
    public class GameController : GenericCrudController<GameModel, DTGame>
    {
        

        public GameController()
        {
            _bl = new BLGame();
        }



        protected override GameModel ConvertDTToMO(DTGame dataType)
        {
            GameModel model = new GameModel();
            if (!String.IsNullOrEmpty(dataType.css))
            {
                
            }
            model.domain = dataType.domain;
            model.FacebookAppID = dataType.FacebookAppID;
            model.FacebookAppSecret = dataType.FacebookAppSecret;
            model.facebookAuth = dataType.facebookAuth;
            model.GoogleClientID = dataType.GoogleClientID;
            model.GoogleClientSecret = dataType.GoogleClientSecret;
            model.id = dataType.id;
            if (!String.IsNullOrEmpty(dataType.Logo))
            {
            }
           
            model.IDAdmin = dataType.IDAdmin;
            model.name = dataType.name;
            model.state = dataType.state;
            return model;
        }

        protected override DTGame ConvertMOToDT(GameModel model)
        {
            DTGame dataType = new DTGame();
            if (model.id>0)
            {
                dataType = _bl.getForId(model.id);
            }
            dataType.id = model.id;
            dataType.domain = model.domain;
            dataType.FacebookAppID = model.FacebookAppID;
            dataType.FacebookAppSecret = model.FacebookAppSecret;
            dataType.facebookAuth = model.facebookAuth;
            dataType.GoogleClientID = model.GoogleClientID;
            dataType.GoogleClientSecret = model.GoogleClientSecret;
            
            dataType.IDAdmin = User.Identity.GetUserId();
            dataType.name = model.name;
            dataType.state = model.state;
            return dataType;
        }

        protected override GameModel LoadDataToEdit(int id)
        {
            GameModel model = new GameModel();
            DTGame game = _bl.getForId(id);
            model = ConvertDTToMO(game);
           
            List<CategoryModel> listCat = new List<CategoryModel>();
            if (game.categories != null)
            {
                foreach (DTCategory category in game.categories)
                {
                    listCat.Add(ConversionHelper.CategoryToModel(category));
                }
            }
            model.categories = listCat;
            List<ResourceModel> listRes = new List<ResourceModel>();
            if (game.resources != null)
            {
                foreach (DTResource resource in game.resources)
                {
                    listRes.Add(ConversionHelper.ResourceToModel(resource));
                }
            }
            model.resources = listRes;
            List<GameObjectModel> listGob = new List<GameObjectModel>();
            foreach (DTGameObject gameobject in game.gameObjects)
            {
                listGob.Add(ConversionHelper.GameObjectToModel(gameobject));
            }
            model.gameObjects = listGob;

            BLGameObject blGO = new BLGameObject();

            List<InitialGameObjectModel> listIGO = new List<InitialGameObjectModel>();
            foreach (DTInitialGameObject iniGO in game.initialGO)
            {
                iniGO.Name = blGO.getGameObject(iniGO.idGameObject).name;
                listIGO.Add(ConversionHelper.InitialGameObjectToModel(iniGO));
            }
            model.iniGameObjects = listIGO;

            BLResource blR = new BLResource();
            List<InitialResourceModel> listIR = new List<InitialResourceModel>();
            foreach (DTInitialResource iniR in game.initialR)
            {
                iniR.Name = blR.getResource(iniR.idResource).name;
                listIR.Add(ConversionHelper.InitialResourceToModel(iniR));
            }
            model.iniResource = listIR;

            List<ActionConfigModel> listAct = new List<ActionConfigModel>();
            if (game.actions != null)
            {
                
                foreach (DTActionConfig action in game.actions)
                {
                    listAct.Add(ConversionHelper.ActionModelToAction(action));
                }
            }
            model.actions = listAct;
            return model;
        }

        protected override List<GameModel> loadDataToIndex()
        {
            List<DTGame> listGame = _bl.getAll();
            return listGame.Select(x => ConvertDTToMO(x)).Where(x => x.IDAdmin.Equals(User.Identity.GetUserId())).ToList();
        }

        protected override void LoadViewDataToCreate()
        {
            
        }

        protected override GameModel PreLoadModelToCreate()
        {
            GameModel model = new GameModel();
            return model;
        }

        protected override GameModel PreLoadModelToEdit()
        {
            GameModel model = new GameModel();
            return model;
        }

        public JsonResult IsGameNameAvailable(GameModel gModel)
        {
            BLGame blGame = new BLGame();
            return Json(!blGame.isValid(gModel.name, gModel.id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsGameDomainAvailable(GameModel gModel)
        {
            BLGame blGame = new BLGame();
            return Json(!blGame.isValidDomain(gModel.domain, gModel.id), JsonRequestBehavior.AllowGet);
        }

    }
}
