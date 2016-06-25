using BusinessLayer.Interface;
using DataLayer.JuegoClasses;
using Shared.JuegoEntities;
using DataLayer.JuegoInterfaces;
using DataLayer.Helper;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BLInitialGameObject : IBLInitialGameObject
    {

        private IDALInitialGameObject dalGob = new DALInitialGameObject();

        public BLInitialGameObject()
        {
            dalGob = new DALInitialGameObject();
        }

        public BLInitialGameObject(IDALInitialGameObject _dalGob)
        {
            dalGob = _dalGob;
        }

        public void addInitialGameObject(DTInitialGameObject igob)
        {
            try
            {
                dalGob.addInitialGameObject(igob);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void deleteInitialGameObject(int idGame, int idGameObject)
        {
            try
            {
                dalGob.deleteInitialGameObject(idGame, idGameObject);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTInitialGameObject> getAllInitialGameObjects()
        {
            try
            {
                return dalGob.getAllInitialGameObjects();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public DTInitialGameObject getInitialGameObject(int idGame, int idGameObject)
        {
            try
            {
                return dalGob.getInitialGameObject(idGame, idGameObject);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void updateInitialGameObject(DTInitialGameObject igob)
        {
            try
            {
                dalGob.updateGameObject(igob);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }
    }
}