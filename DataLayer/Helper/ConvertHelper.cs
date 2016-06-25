using DataLayer.Model;
using Shared.ActionEntities;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Helper
{
    public class ConvertHelper
    {
        public static DTAttribute ConvertTABAtributeToAttribute(TABAttribute atrTAB)
        {
            DTAttribute atr = new DTAttribute();
            atr.id = atrTAB.ID;
            atr.idGameObject = atrTAB.ID_GAMEOBJECT_FK;
            atr.nombre = atrTAB.Name;
            atr.valor = atrTAB.Value;
            atr.Type = atrTAB.Type;
            return atr;
        }

        public static TABAttribute ConvertAttributeToTABAttribute(DTAttribute atr)
        {
            TABAttribute atrTAB = new TABAttribute();
            atrTAB.ID = atr.id;
            atrTAB.ID_GAMEOBJECT_FK = atr.idGameObject;
            atrTAB.Name = atr.nombre;
            atrTAB.Value = atr.valor;
            atrTAB.Type = atr.Type;
            return atrTAB;
        }

        public static DTGroup ConvertTABGroupToGroup(TABGroup x)
        {
            DTGroup dt = new DTGroup();
            dt.Name = x.Name;
            List<DTGroupPlayer> players = new List<DTGroupPlayer>();
            foreach(TABGroupPlayer p in x.TABGroupPlayer)
            {
                players.Add(convertTABGroupPlayerToGroupPlayer(p));
            }
            dt.players = players;
            return dt;
        }

        private static DTGroupPlayer convertTABGroupPlayerToGroupPlayer(TABGroupPlayer p)
        {
            DTGroupPlayer dt = new DTGroupPlayer();
            dt.idGroup = p.ID_GROUP_FK;
            dt.idPlayer = int.Parse(p.ID_PLAYER_FK);
            if (p.Admin == 1)
            {
                dt.esAdmin = true;
            }
            else
            {
                dt.esAdmin = false;
            }
            return dt;
        }

        //public static DTPlayer ConvertTABPlayerToPlayer(TABPlayer p)
        //{
        //    DTPlayer dt = new DTPlayer();
        //    dt.Email = p.Email;
        //    dt.Id = p.ID;
        //    dt.idGame = p.ID_GAME_FK;
        //    dt.Nick = p.Nick;
        //    dt.Password = p.Pass;
        //    dt.Picture = p.Picture;
        //    dt.TokenFacebook = p.TokenFacebook;
        //    dt.TokenGoogle = p.TokenGoogle;
        //    return dt;
        //}

        public static TABGroupPlayer convertGroupPlayerToTABGroupPlayer(DTGroupPlayer pl)
        {
            TABGroupPlayer tab = new TABGroupPlayer();
            tab.ID_PLAYER_FK = pl.idPlayer.ToString();
            tab.ID_GROUP_FK = pl.idGroup;
            return tab;
        }

        public static TABGroup ConvertGroupToTABGroup(DTGroup dt)
        {
            TABGroup tab = new TABGroup();
            tab.Name = dt.Name;
            foreach (DTGroupPlayer p in dt.players)
            {
                tab.TABGroupPlayer.Add(convertGroupPlayerToTABGroupPlayer(p));
            }
            return tab;
        }

        //public static TABPlayer convertPlayerToTABPlayer(DTPlayer p)
        //{
        //    TABPlayer tab = new TABPlayer();
        //    tab.Email = p.Email;
        //    tab.ID = p.Id;
        //    tab.ID_GAME_FK = p.idGame;
        //    tab.Nick = p.Nick;
        //    tab.Pass = p.Password;
        //    tab.Picture = p.Picture;
        //    tab.TokenFacebook = p.TokenFacebook;
        //    tab.TokenGoogle = p.TokenGoogle;
        //    return tab;
        //}

        public static DTCategory ConvertTABCategorytoCategory(TABCategory catTAB)
        {
            DTCategory cat = new DTCategory();
            cat.idGame = catTAB.ID_GAME_FK;
            cat.name = catTAB.Name;
            cat.id = catTAB.ID;
            cat.toolTip = catTAB.ToolTip;
            cat.image = catTAB.Image;
            List<DTGameObject> gameobjects = new List<DTGameObject>();
            foreach (TABGameObject g in catTAB.TABGameObject)
            {
                gameobjects.Add(ConvertTABGameObjecttoGameObject(g));

            }
            cat.gameObjects = gameobjects;
            return cat;
        }

        public static DTEvent ConvertTABEventToEvent(TABEvent ev)
        {
            DTEvent dt = new DTEvent();
            dt.id = ev.ID;
            if (ev.ID_NOTIFICATION_FK > 0)
            {
                dt.id_notification = ev.ID_NOTIFICATION_FK;
            }
            else
            {
                dt.id_notification = null;
            }
            dt.expiration = DateTime.Parse(ev.expiration.ToString());
            List<DTGameObject> gameobjects = new List<DTGameObject>();
            foreach (TABGameObject g in ev.TABGameObject)
            {
                gameobjects.Add(ConvertTABGameObjecttoGameObject(g));

            }
            dt.gameobjects = gameobjects;
            return dt;
        }

        public static DTCost ConvertTABCostToCost(TABCost costTab)
        {
            DTCost cost = new DTCost();
            cost.id = costTab.ID;
            cost.idGameObject = costTab.ID_GAMEOBJECT_FK;
            cost.idResource = costTab.ID_RESOURCE_FK;
            cost.cantidad = costTab.Quantity;
            return cost;
        }

        public static DTGameObject ConvertTABGameObjecttoGameObject(TABGameObject gobTAB)
        {
            DTGameObject gob = new DTGameObject();
            gob.id = gobTAB.ID;
            gob.name = gobTAB.Name;
            gob.description = gobTAB.Description;
            gob.image = gobTAB.Image;
            gob.idCategory = gobTAB.ID_CATEGORY_FK;

            List<DTAttribute> attributes = new List<DTAttribute>();
            foreach (TABAttribute a in gobTAB.TABAttribute)
            {
                attributes.Add(ConvertTABAtributeToAttribute(a));

            }
            gob.attributes = attributes;

            List<DTCost> costes = new List<DTCost>();
            foreach (TABCost c in gobTAB.TABCost)
            {
                costes.Add(ConvertTABCostToCost(c));

            }
            gob.costes = costes;

            List<DTGenerate> generates = new List<DTGenerate>();
            foreach (TABGenerate a in gobTAB.TABGenerate)
            {
                generates.Add(ConvertTABGenerateToGenerate(a));

            }
            gob.generates = generates;

            List<DTActionConfig> actions = new List<DTActionConfig>();
            foreach(TABActionConfig action in gobTAB.TABActionConfig)
            {
                actions.Add(ConvertTABActionToAction(action));
            }
            gob.actions = actions;

            //List<DTEvent> events = new List<DTEvent>();
            //foreach(TABEvent ev in gobTAB.TABEvent)
            //{
            //    events.Add(ConvertTABEventToEvent(ev));
            //}
            //gob.events = events;

            return gob;
        }

        private static DTActionConfig ConvertTABActionToAction(TABActionConfig action)
        {
            if (action is TABCreateConfig)
            {
                DTActionConfig dt = new DTCrearConfig();
                dt.idAction = action.ID;
                dt.IDGame = action.ID_GAME_FK;
                dt.IDGameObject = action.ID_GAMEOBJECT;
                dt.name = action.Name;
                dt.TypeAction = "1";
                return dt;
            }

            return null;
        }

        public static DTGenerate ConvertTABGenerateToGenerate(TABGenerate generateTab)
        {
            DTGenerate generate = new DTGenerate();
            generate.id = generateTab.ID;
            generate.idGameObject = generateTab.ID_GAME_OBJECT_FK;
            generate.idResource = generateTab.ID_RESOURCE_FK;
            generate.resource = generateTab.TABResource.Name;
            generate.time = generateTab.Time;
            generate.quantity = generateTab.Quantity;
            return generate;
        }

        public static DTResource ConvertTABResourcetoResource(TABResource resTAB)
        {
            DTResource res = new DTResource();
            res.name = resTAB.Name;
            res.id = resTAB.ID;
            res.image = resTAB.Image;
            res.idGame = resTAB.ID_GAME_FK;
            return res;
        }

        public static DTInitialGameObject ConvertTABInitialGameObjectToInitialGameobject(TABInitialGameObject iniGameTAB)
        {
            DTInitialGameObject iniGame = new DTInitialGameObject();
            iniGame.idGameObject = iniGameTAB.ID_GAMEOBJECT_FK;
            iniGame.idGame = iniGameTAB.ID_GAME_FK;
            iniGame.quantity = iniGameTAB.Quantity;
            return iniGame;
        }


        public static DTInitialResource ConvertTABInitialResourceToInitialResource(TABInitialResource iniResTAB)
        {
            DTInitialResource iniRes = new DTInitialResource();
            iniRes.idResource = iniResTAB.ID_RESOURCE_FK;
            iniRes.idGame = iniResTAB.ID_GAME_FK;
            iniRes.quantity = iniResTAB.Quantity;
            return iniRes;
        }

        public static DTGame ConvertTABGameToGame(TABGame tab)
        {
            DTGame game = new DTGame();
            game.css = tab.CSS;
            game.domain = tab.Dominio;
            game.state = tab.Estado;
            game.FacebookAppID = int.Parse(tab.FacebookAppID);
            game.FacebookAppSecret = tab.FacebookAppSecret;
            game.facebookAuth = (byte)tab.FacebookAuth;
            game.GoogleClientID = int.Parse(tab.GoogleClientID);
            game.GoogleClientSecret = tab.GoogleClientSecret;
            game.id = tab.ID;
            game.IDAdmin = tab.ID_ADMIN_FK;
            game.name = tab.Name;
            return game;
        }

        public static DTNotification ConvertTABNotificationtoNotification(TABNotification tab)
        {
            DTNotification notification = new DTNotification();
            notification.ID = tab.ID;
            notification.ID_PLAYER_FK = tab.ID_PLAYER_FK;
            notification.Title = tab.Title;
            notification.Description = tab.Description;
            notification.hasRead = tab.hasRead;
            return notification;
        }

        public static DTSimpleAttack ConvertTABSimpleAttackTOSimpleAttack(TABAttackConfig1 tab)
        {
            var tipo = tab.GetType();
            if (tab.GetType() == typeof(DataLayer.Model.SimpleAttack))
            {
                DTSimpleAttack simpleAttackDT = new DTSimpleAttack();
                SimpleAttack sAttack = (SimpleAttack)tab;

                simpleAttackDT.ID = sAttack.ID;
                simpleAttackDT.ID_GAME_FK = sAttack.ID_GAME_FK;
                simpleAttackDT.Name = sAttack.Name;
                simpleAttackDT.PercentGain = sAttack.PercentGain;
                simpleAttackDT.PercentLoss = sAttack.PercentLoss;
                return simpleAttackDT;
            }
            if(tab.GetType() == typeof(GroupAttack))
            {
                int a = 2 + 2;
            }

            return null;

        }

    }

}
