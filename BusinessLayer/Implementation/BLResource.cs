using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.JuegoEntities;
using DataLayer.JuegoInterfaces;
using DataLayer.JuegoClasses;
using BusinessLayer.Interface;

namespace BusinessLayer
{
    public class BLResource : IBLResource
    {
        private IDALResource dalRes = new DALResource();
        
        public BLResource()
        {
            dalRes = new DALResource();
        }
        
        public BLResource(IDALResource _dalRes)
        {
            dalRes = _dalRes;
        }

        public void addResource(DTResource res)
        {
            try
            {
                dalRes.addResource(res);
            }
           catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void deleteResource(int id)
        {
            try
            {
                dalRes.deleteResource(id);
            }
            catch(Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTResource> getAllResources()
        {
            try
            {
                return dalRes.getAllResources();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public DTResource getResource(int id)
        {
            try
            {
                return dalRes.getResource(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void updateResource(DTResource res)
        {
            try
            {
                dalRes.updateResource(res);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }



        public List<DTResource> getResourcesByGameId(int id)
        {
            try
            {
                return dalRes.getResourcesByGameId(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTResource> getResourcesByGameName(string name)
        {
            try
            {
                return dalRes.getResourcesByGameName(name);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTResource> getResourcesByGameTenant(string tenantIdentity)
        {
            try
            {
                return dalRes.getResourcesByGameTenant(tenantIdentity);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }
    }
}
