using DataLayer.JuegoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Shared.JuegoEntities;
using DataLayer.Helper;

namespace DataLayer.JuegoClasses
{
    public class DALCost : IDALCost
    {
        private AtlasConexion dbContext = new AtlasConexion();

        public void addCost(DTCost cost)
        {
            TABCost costTab = new TABCost();
            costTab.ID_GAMEOBJECT_FK = cost.idGameObject;
            costTab.ID_RESOURCE_FK = cost.idResource;
            costTab.Quantity = cost.cantidad;
            dbContext.TABCost.Add(costTab);
            dbContext.SaveChanges();
        }

        public void deleteCost(int id)
        {
            dbContext.TABCost.Remove(getTABCost(id));
            dbContext.SaveChanges();
        }
       
        public List<DTCost> getAllCosts()
        {
            List<DTCost> listCostReturn = new List<DTCost>();
            List<TABCost> listaBase = dbContext.TABCost.ToList();
            foreach(TABCost cost in listaBase)
            {
                listCostReturn.Add(ConvertHelper.ConvertTABCostToCost(cost));
            }
            return listCostReturn;
        }

        public DTCost getCost(int id)
        {
            DTCost cost = ConvertHelper.ConvertTABCostToCost(dbContext.TABCost.Where(c => c.ID == id).First());
            return cost;
        }

        public TABCost getTABCost(int id)
        {
            return dbContext.TABCost.Where(c => c.ID == id).First();
        }

        public void updateCost(DTCost cost)
        {
            TABCost costTab = dbContext.TABCost.Where(c => c.ID == cost.id).First();
            costTab.ID_GAMEOBJECT_FK = cost.idGameObject;
            costTab.ID_RESOURCE_FK = cost.idResource;
            costTab.Quantity = cost.cantidad;
            dbContext.SaveChanges();
        }
    }
}
