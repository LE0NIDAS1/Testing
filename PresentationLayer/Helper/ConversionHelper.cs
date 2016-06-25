using PresentationLayer.Models;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shared.ActionEntities;

namespace PresentationLayer.Helper
{
    public class ConversionHelper
    {

        public static AttributeModel AttributeToModel(DTAttribute atr)
        {
            AttributeModel model = new AttributeModel();
            model.id = atr.id;
            model.Name = atr.nombre;
            model.ID_GameObject = atr.idGameObject;
            model.valor = atr.valor;
            model.Type = atr.Type;
            return model;
        }

        public static GameObjectModel GameObjectToModel(DTGameObject gob)
        {
            GameObjectModel model = new GameObjectModel();
            model.Id = gob.id;
            model.Name = gob.name;
            model.Description = gob.description;
            model.Image = gob.image;
            model.IdCategory = gob.idCategory;
            return model;
        }

        public static CategoryModel CategoryToModel(DTCategory cat)
        {
            CategoryModel model = new CategoryModel();
            model.Id = cat.id;
            model.Name = cat.name;
            model.Tooltip = cat.toolTip;
            model.Image = cat.image;
            return model;
        }

        public static CostModel CostToModel(DTCost cost)
        {
            CostModel costMdl = new CostModel();
            costMdl.cant = cost.cantidad;
            costMdl.Id = cost.id;
            costMdl.ID_GameObject = cost.idGameObject;
            costMdl.id_Resource = cost.idResource;
            return costMdl;
        }

        public static GenerateModel GenerateToModel(DTGenerate generate)
        {
            GenerateModel generateMdl = new GenerateModel();
            generateMdl.time = generate.time;
            generateMdl.Id = generate.id;
            generateMdl.Id_GameObject = generate.idGameObject;
            generateMdl.Id_Resource = generate.idResource;
            generateMdl.Resource = generate.resource;
            generateMdl.Quantity = generate.quantity;
            return generateMdl;
        }

        public static ResourceModel ResourceToModel(DTResource res)
        {
            ResourceModel model = new ResourceModel();
            model.Id = res.id;
            model.Name = res.name;
            model.Image = res.image;
            return model;
        }

        public static GameModel GameToModel(DTGame dataType)
        {
            GameModel model = new GameModel();
            model.css = dataType.css;
            model.domain = dataType.domain;
            model.FacebookAppID = dataType.FacebookAppID;
            model.FacebookAppSecret = dataType.FacebookAppSecret;
            model.facebookAuth = dataType.facebookAuth;
            model.GoogleClientID = dataType.GoogleClientID;
            model.GoogleClientSecret = dataType.GoogleClientSecret;
            model.id = dataType.id;
            model.Logo = dataType.Logo;

            model.IDAdmin = dataType.IDAdmin;
            model.name = dataType.name;
            model.state = dataType.state;
            return model;
        }

        public static ActionConfigModel ActionModelToAction(DTActionConfig action)
        {
            ActionConfigModel model = new ActionConfigModel();
            model.id = action.idAction;
            model.IDGame = action.IDGame;
            model.name = action.name;
            model.TypeAction = action.TypeAction;
            return model;
        }

        //public static InitialInstanceModel InitialInstanceToModel(DTInitialInstance iniInst)
        //{
        //    InitialInstanceModel model = new InitialInstanceModel();
        //    model.id = iniInst.id;
        //    model.idGame = iniInst.idGame;
        //    return model;
        //}

        public static InitialGameObjectModel InitialGameObjectToModel(DTInitialGameObject iniGameObject)
        {
            InitialGameObjectModel model = new InitialGameObjectModel();
            model.Name = iniGameObject.Name;
            model.IdGameObject = iniGameObject.idGameObject;
            model.IdGame = iniGameObject.idGame;
            model.Quantity = iniGameObject.quantity;
            return model;
        }

        public static InitialResourceModel InitialResourceToModel(DTInitialResource iniResource)
        {
            InitialResourceModel model = new InitialResourceModel();
            model.Name = iniResource.Name;
            model.idResource = iniResource.idResource;
            model.IdGame = iniResource.idGame;
            model.Quantity = iniResource.quantity;
            return model;
        }
    }
}