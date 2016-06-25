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
    public class BLInitialResource : IBLInitialResource
    {
        private IDALInitialResource dalGob = new DALInitialResource();

        public BLInitialResource()
        {
            dalGob = new DALInitialResource();
        }

        public BLInitialResource(IDALInitialResource _dalGob)
        {
            dalGob = _dalGob;
        }

        public void addInitialResource(DTInitialResource ires)
        {
            try
            {
                dalGob.addInitialResource(ires);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void deleteInitialResource(int idGame, int idResource)
        {
            try
            {
                dalGob.deleteInitialResource(idGame, idResource);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTInitialResource> getAllInitialResource()
        {
            try
            {
                return dalGob.getAllInitialResource();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public DTInitialResource getInitialResource(int idGame, int idResource)
        {
            try
            {
                return dalGob.getInitialResource(idGame, idResource);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void updateInitialResource(DTInitialResource ires)
        {
            try
            {
                dalGob.updateInitialResource(ires);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }
    }
}
