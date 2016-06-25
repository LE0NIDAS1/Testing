using DataLayer.JuegoInterfaces;
using System.Collections.Generic;
using System.Linq;
using Shared.JuegoEntities;
using DataLayer.Model;
using DataLayer.Helper;
using System;

namespace DataLayer.JuegoClasses
{
    public class DALGameObect : IDALGameObject
    {
        private AtlasConexion dbContext = new AtlasConexion();

        public void addGameObject(DTGameObject gob)
        {
            TABGameObject gobTAB = new TABGameObject();
            gobTAB.Name = gob.name;
            gobTAB.Description = gob.description;
            gobTAB.Image = gob.image;
            gobTAB.ID_CATEGORY_FK = gob.idCategory;
            dbContext.TABGameObject.Add(gobTAB);
            dbContext.SaveChanges();
        }

        public void deleteGameObject(int id)
        {
            dbContext.TABGameObject.Remove(getTABGameObject(id));
            dbContext.SaveChanges();
        }

        public List<DTGameObject> getAllGameObjects()
        {
            List<DTGameObject> listaGobturn = new List<DTGameObject>();
            List<TABGameObject> listaBase = dbContext.TABGameObject.ToList();
            foreach (TABGameObject TABGameObject in listaBase)
            {
                listaGobturn.Add(ConvertHelper.ConvertTABGameObjecttoGameObject(TABGameObject));
            }
            return listaGobturn;
        }

        public TABGameObject getTABGameObject(int id)
        {
            TABGameObject gobTAB = dbContext.TABGameObject.Where(n => n.ID == id).First();
            return gobTAB;
        }

        public DTGameObject getGameObject(int id)
        {
            DTGameObject gob = ConvertHelper.ConvertTABGameObjecttoGameObject(dbContext.TABGameObject.Where(n => n.ID == id).First());
            return gob;
        }

        public void updateGameObject(DTGameObject gob)
        {
            TABGameObject gobTAB = dbContext.TABGameObject.Where(n => n.ID == gob.id).First();
            gobTAB.Name = gob.name;
            gobTAB.Description = gob.description;
            gobTAB.Image = gob.image;
            gobTAB.ID_CATEGORY_FK = gob.idCategory;
            dbContext.SaveChanges();
        }

        public List<DTGameObject> getGameObjectsByGameID(int id)
        {
            List<DTGameObject> listaGobturn = new List<DTGameObject>();
            List<TABGameObject> listaBase = dbContext.TABGameObject.Where(n => n.ID.Equals(id)).ToList();


            IEnumerable<TABGameObject> ListaGameObject = from I in dbContext.TABGameObject
                                                         join o in dbContext.TABCategory on I.ID_CATEGORY_FK equals o.ID
                                                         where o.ID_GAME_FK == id
                                                         orderby o.Name
                                                         select I;

            foreach (TABGameObject TABGameObject in ListaGameObject)
            {
                listaGobturn.Add(ConvertHelper.ConvertTABGameObjecttoGameObject(TABGameObject));
            }
            return listaGobturn;
        }

        public List<DTGameObject> getGameObjectsByGameAndCategory(int idGame, int idCategory)
        {
            AtlasConexion dbContext = new AtlasConexion();
            List<TABGameObject> list = dbContext.TABGameObject.Where(n => n.ID_CATEGORY_FK.Equals(idCategory) && n.TABCategory.ID_GAME_FK.Equals(idGame)).ToList();
            return list.Select(x => ConvertHelper.ConvertTABGameObjecttoGameObject(x)).ToList();
        }
        public bool isValid(string Name, int id, int idGame, int idCategory)
        {
            int idG = dbContext.TABCategory.Where(n => n.ID == idCategory).First().ID_GAME_FK;
            return dbContext.TABGameObject.Any(a => (((a.ID != id) && (a.Name == Name)) && (a.ID_CATEGORY_FK == idCategory)));
        }

        public List<DTCost> getCostsForGameObject(int idGameObject)
        {
            return dbContext.TABGameObject.Where(x => x.ID == idGameObject).First().TABCost.Select(x => ConvertHelper.ConvertTABCostToCost(x)).ToList();
            
        }

        public string getTimeConstructionOfGameObject(int idGameObject)
        {
            return dbContext.TABGameObject.Where(x => x.ID == idGameObject).First().TABAttribute.Where(x => x.Type.Equals("3")).First().Value;
        }
    }
}