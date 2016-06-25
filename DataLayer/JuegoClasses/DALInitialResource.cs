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
    public class DALInitialResource : IDALInitialResource
    {
        private AtlasConexion dbContext = new AtlasConexion();

        public void addInitialResource(DTInitialResource ires)
        {
            TABInitialResource iresTAB = new TABInitialResource();
            iresTAB.ID_RESOURCE_FK = ires.idResource;
            iresTAB.ID_GAME_FK = ires.idGame;
            iresTAB.Quantity = ires.quantity;
            dbContext.TABInitialResource.Add(iresTAB);
            dbContext.SaveChanges();
        }

        public void deleteInitialResource(int idResource, int idGame)
        {
            dbContext.TABInitialResource.Remove(getTABInitialResource(idResource, idGame));
            dbContext.SaveChanges();
        }

        public List<DTInitialResource> getAllInitialResource()
        {
            List<DTInitialResource> listaIniResturn = new List<DTInitialResource>();
            List<TABInitialResource> listaBase = dbContext.TABInitialResource.ToList();
            foreach (TABInitialResource TABInitialResource in listaBase)
            {
                listaIniResturn.Add(ConvertHelper.ConvertTABInitialResourceToInitialResource(TABInitialResource));
            }
            return listaIniResturn;
        }

        public DTInitialResource getInitialResource(int idResource, int idGame)
        {
            DTInitialResource iresDT = ConvertHelper.ConvertTABInitialResourceToInitialResource(dbContext.TABInitialResource.Where(n => (n.ID_RESOURCE_FK == idResource) && (n.ID_GAME_FK == idGame)).First());
            return iresDT;
        }

        public TABInitialResource getTABInitialResource(int idResource, int idInitialInstance)
        {
            TABInitialResource iresTAB = dbContext.TABInitialResource.Where(n => (n.ID_RESOURCE_FK == idResource) && (n.ID_GAME_FK == idInitialInstance)).First();
            return iresTAB;
        }

        public void updateInitialResource(DTInitialResource ires)
        {
            TABInitialResource iresTAB = dbContext.TABInitialResource.Where(n => ((n.ID_RESOURCE_FK == ires.idResource) && (n.ID_GAME_FK == ires.idGame))).First();
            iresTAB.ID_RESOURCE_FK = ires.idResource;
            iresTAB.ID_GAME_FK = ires.idGame;
            iresTAB.Quantity = ires.quantity;
            dbContext.SaveChanges();
        }
    }
}