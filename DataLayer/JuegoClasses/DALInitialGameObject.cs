using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Helper;
using DataLayer.JuegoInterfaces;
using DataLayer.Model;
using Shared.JuegoEntities;

namespace DataLayer.JuegoClasses
{
    public class DALInitialGameObject : IDALInitialGameObject
    {
        private AtlasConexion dbContext = new AtlasConexion();

        public void addInitialGameObject(DTInitialGameObject gob)
        {
            TABInitialGameObject gobTAB = new TABInitialGameObject();
            gobTAB.ID_GAMEOBJECT_FK = gob.idGameObject;
            gobTAB.ID_GAME_FK = gob.idGame;
            gobTAB.Quantity = gob.quantity;
            dbContext.TABInitialGameObject.Add(gobTAB);
            dbContext.SaveChanges();
        }

        public void deleteInitialGameObject(int idGameObject, int idInitialInstance)
        {
            dbContext.TABInitialGameObject.Remove(getTABInitialGameObject(idGameObject, idInitialInstance));
            dbContext.SaveChanges();
        }

        public List<DTInitialGameObject> getAllInitialGameObjects()
        {
            List<DTInitialGameObject> listaIniGobturn = new List<DTInitialGameObject>();
            List<TABInitialGameObject> listaBase = dbContext.TABInitialGameObject.ToList();
            foreach (TABInitialGameObject TABInitialGameObject in listaBase)
            {
                listaIniGobturn.Add(ConvertHelper.ConvertTABInitialGameObjectToInitialGameobject(TABInitialGameObject));
            }
            return listaIniGobturn;
        }

        public DTInitialGameObject getInitialGameObject(int idGameObject, int idGame)
        {
            DTInitialGameObject igobDT = ConvertHelper.ConvertTABInitialGameObjectToInitialGameobject(dbContext.TABInitialGameObject.Where(n => (n.ID_GAMEOBJECT_FK == idGameObject) && (n.ID_GAME_FK == idGame)).First());
            return igobDT;
        }

        public TABInitialGameObject getTABInitialGameObject(int idGameObject, int idGame)
        {
            TABInitialGameObject igobTAB = dbContext.TABInitialGameObject.Where(n => (n.ID_GAMEOBJECT_FK == idGameObject) && (n.ID_GAME_FK == idGame)).First();
            return igobTAB;
        }

        public void updateGameObject(DTInitialGameObject igob)
        {
            TABInitialGameObject igobTAB = dbContext.TABInitialGameObject.Where(n => (n.ID_GAMEOBJECT_FK == igob.idGameObject) && (n.ID_GAME_FK == igob.idGame)).First();
            igobTAB.ID_GAMEOBJECT_FK = igob.idGameObject;
            igobTAB.ID_GAME_FK = igob.idGame;
            igobTAB.Quantity = igob.quantity;
            dbContext.SaveChanges();
        }
    }
}
