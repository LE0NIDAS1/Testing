using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.JuegoEntities;
using DataLayer.JuegoInterfaces;
using DataLayer.JuegoClasses;


namespace BusinessLayer
{
    public class BLGameObject : IBLGameObject
    {
        private IDALGameObject dalGob = new DALGameObect();

        public BLGameObject()
        {
            dalGob = new DALGameObect();
        }

        public BLGameObject(IDALGameObject _dalGob)
        {
            dalGob = _dalGob;
        }
        public void addGameObject(DTGameObject gob)
        {
            try
            {
                dalGob.addGameObject(gob);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void deleteGameObject(int id)
        {
            try
            {
                dalGob.deleteGameObject(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTGameObject> getAllGameObjects()
        {
            try
            {
                return dalGob.getAllGameObjects();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }

        }

        public DTGameObject getGameObject(int id)
        {
            try
            {
                return dalGob.getGameObject(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }

        }

        public List<DTGameObject> getGameObjectsByGameAndCategory(int id, int category)
        {
            try
            {
                return dalGob.getGameObjectsByGameAndCategory(id, category);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTGameObject> getGameObjectsByGameID(int id)
        {
            try
            {
                return dalGob.getGameObjectsByGameID(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void updateGameObject(DTGameObject gob)
        {
            try
            {
                dalGob.updateGameObject(gob);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public bool isValid(string Name, int id, int idGame, int idCategory)
        {
            try
            {
                return dalGob.isValid(Name, id, idGame, idCategory);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTCost> getCostsOfGameObject(int idGameObject)
        {
            return dalGob.getCostsForGameObject(idGameObject);
        }

        public string getTimeConstructionOfGameObject(int idGameObject)
        {
            return dalGob.getTimeConstructionOfGameObject(idGameObject);
        }
    }
}
