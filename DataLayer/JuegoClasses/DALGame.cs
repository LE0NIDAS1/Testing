using DataLayer.Helper;
using DataLayer.JuegoInterfaces;
using DataLayer.Model;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer.JuegoClasses
{
    public class DALGame : DALGenericCRUD<TABGame, DTGame>, IDALGame
    {
        public override TABGame convertDTToTAB(DTGame dt)
        {
            TABGame tab = new TABGame();

            tab.ID = dt.id;
            tab.CSS = dt.css;
            tab.Dominio = dt.domain;
            tab.Name = dt.name;
            tab.Logo = dt.Logo;
            tab.Estado = dt.state;
            tab.FacebookAppID = dt.FacebookAppID.ToString();
            tab.FacebookAppSecret = dt.FacebookAppSecret;
            tab.FacebookAuth = dt.facebookAuth;
            tab.GoogleClientID = dt.GoogleClientID.ToString();
            tab.GoogleClientSecret = dt.GoogleClientSecret;
            tab.ID_ADMIN_FK = dt.IDAdmin;

            return tab;
        }

        public override DTGame convertTABToDT(TABGame tab)
        {
            if (tab==null)
            {
                return null;
            }
            DTGame dt = new DTGame();
            dt.id = tab.ID;
            dt.css = tab.CSS;
            dt.name = tab.Name;
            dt.domain = tab.Dominio;
            dt.state = tab.Estado;
            dt.Logo = tab.Logo;
            dt.FacebookAppID = int.Parse(tab.FacebookAppID);
            dt.FacebookAppSecret = tab.FacebookAppSecret;
            dt.facebookAuth = byte.Parse(tab.FacebookAuth.ToString());
            dt.GoogleClientID = int.Parse(tab.GoogleClientID);
            dt.GoogleClientSecret = tab.GoogleClientSecret;
            dt.IDAdmin = tab.ID_ADMIN_FK;
            List<DTCategory> categories = new List<DTCategory>();
            foreach (TABCategory c in tab.TABCategory)
            {
                categories.Add(ConvertHelper.ConvertTABCategorytoCategory(c));

            }
            dt.categories = categories;
            dt.IDAdmin = tab.ID_ADMIN_FK;
            List<DTGameObject> listGob = new List<DTGameObject>();
            List<TABGameObject> lisTabGob = getAllGOBForGame(dt.id);
            foreach(TABGameObject gameobject in lisTabGob)
            {
                listGob.Add(ConvertHelper.ConvertTABGameObjecttoGameObject(gameobject));
            }
            dt.gameObjects = listGob;
            List<DTResource> resources = new List<DTResource>();
            foreach (TABResource r in tab.TABResource)
            {
                resources.Add(ConvertHelper.ConvertTABResourcetoResource(r));

            }
            dt.resources = resources;
            //initialGameObject
            List<DTInitialGameObject> initialGO = new List<DTInitialGameObject>();
            foreach (TABInitialGameObject initialobject in tab.TABInitialGameObject)
            {
                initialGO.Add(ConvertHelper.ConvertTABInitialGameObjectToInitialGameobject(initialobject));
            }
            dt.initialGO = initialGO;
            //initial resource

            List<DTInitialResource> initialR = new List<DTInitialResource>();
            foreach (TABInitialResource initialResourc in tab.TABInitialResource)
            {
                initialR.Add(ConvertHelper.ConvertTABInitialResourceToInitialResource(initialResourc));
            }
            dt.initialR = initialR;


            
            return dt;
        }

        public List<TABGameObject> getAllGOBForGame(int idGame)
        {
            AtlasConexion dbContext = getDbContext();
            return dbContext.TABGameObject.Where(x => x.TABCategory.ID_GAME_FK == idGame).ToList();
        }


        public override TABGame getForId(int id)
        {
            AtlasConexion dbContext = getDbContext();
            return dbContext.TABGame.Where(g => g.ID == id).First();
        }

        public DTGame getForIdTenantIdentity(string tenantIdentity)
        {
            try
            {
                AtlasConexion dbContext = getDbContext();
                return convertTABToDT(dbContext.TABGame.Where(g => g.Dominio.Trim().ToLower().Equals(tenantIdentity)).FirstOrDefault());
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");
            }

        }

        protected override void processBeforeCreate(TABGame obj)
        {
            //throw new NotImplementedException();
        }

        protected override void processBeforeUpdate(TABGame obj)
        {
            //throw new NotImplementedException();
        }

        private AtlasConexion dbContext = new AtlasConexion();

        public bool isValid(string Name, int id)
        {
            return dbContext.TABGame.Any(a => (a.ID != id) && (a.Name == Name));
        }

        public bool isValidDomain(string Domain, int id)
        {
            return dbContext.TABGame.Any(a => (a.ID != id) && (a.Dominio == Domain));
        }
    }
}
