using DataLayer.JuegoInterfaces;
using System.Collections.Generic;
using System.Linq;
using Shared.JuegoEntities;
using DataLayer.Model;
using DataLayer.Helper;
using System;

namespace DataLayer.JuegoClasses
{
    public class DALResource : IDALResource
    {
        private AtlasConexion dbContext = new AtlasConexion();

        public void addResource(DTResource res)
        {
            TABResource resTAB = new TABResource();
            resTAB.Name = res.name;
            resTAB.Image = res.image;
            resTAB.ID_GAME_FK = res.idGame;
            dbContext.TABResource.Add(resTAB);
            dbContext.SaveChanges();
        }

        public void deleteResource(int id)
        {
            dbContext.TABResource.Remove(getTABResource(id));
            dbContext.SaveChanges();
        }

        public List<DTResource> getAllResources()
        {
            List<DTResource> listaResturn = new List<DTResource>();
            List<TABResource> listaBase = dbContext.TABResource.ToList();
            foreach (TABResource TABResource in listaBase)
            {
                listaResturn.Add(ConvertHelper.ConvertTABResourcetoResource(TABResource));
            }
            return listaResturn;
        }
       
        public TABResource getTABResource(int id)
        {
            TABResource resTAB = dbContext.TABResource.Where(n => n.ID == id).First();
            return resTAB;
        }

        public DTResource getResource(int id)
        {
            DTResource res = ConvertHelper.ConvertTABResourcetoResource(dbContext.TABResource.Where(n => n.ID == id).First());
            return res;
        }

        public void updateResource(DTResource res)
        {
            TABResource resTAB = dbContext.TABResource.Where(n => n.ID == res.id).First();
            resTAB.Name = res.name;
            resTAB.Image = res.image;
            dbContext.SaveChanges();
        }



        public List<DTResource> getResourcesByGameId(int id)
        {
            try
            {
                dbContext = new AtlasConexion();
                List<TABResource> results = dbContext.TABResource.Where(n => n.ID_GAME_FK.Equals(id)).ToList();
                return results.Select(n=> ConvertHelper.ConvertTABResourcetoResource(n)).ToList();
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
                dbContext = new AtlasConexion();
                List<TABResource> results = dbContext.TABResource.Where(n => n.TABGame.Name == name).ToList();
                List<DTResource> resources = new List<DTResource>();
                foreach (TABResource TABResource in results)
                {
                    resources.Add(ConvertHelper.ConvertTABResourcetoResource(TABResource));
                }
                return resources;
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
                dbContext = new AtlasConexion();
                List<TABResource> results = dbContext.TABResource.Where(n => n.TABGame.Dominio.ToLower().Equals(tenantIdentity.ToLower())).ToList();
                return results.Select(n => ConvertHelper.ConvertTABResourcetoResource(n)).ToList();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }
    }
}
