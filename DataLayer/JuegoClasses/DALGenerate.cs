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
    public class DALGenerate : IDALGenerate
    {
        private AtlasConexion dbContext = new AtlasConexion();

        public void addGenerate(DTGenerate generate)
        {
            TABGenerate generateTab = new TABGenerate();
            generateTab.ID_GAME_OBJECT_FK = generate.idGameObject;
            generateTab.ID_RESOURCE_FK = generate.idResource;
            generateTab.Time = generate.time;
            generateTab.Quantity = generate.quantity;
            dbContext.TABGenerate.Add(generateTab);
            dbContext.SaveChanges();
        }

        public void deleteGenerate(int id)
        {
            dbContext.TABGenerate.Remove(getTABGenerate(id));
            dbContext.SaveChanges();
        }
       
        public List<DTGenerate> getAllGenerates()
        {
            List<DTGenerate> listCostReturn = new List<DTGenerate>();
            List<TABGenerate> listaBase = dbContext.TABGenerate.ToList();
            foreach(TABGenerate generate in listaBase)
            {
                listCostReturn.Add(ConvertHelper.ConvertTABGenerateToGenerate(generate));
            }
            return listCostReturn;
        }

        public DTGenerate getGenerate(int id)
        {
            DTGenerate cost = ConvertHelper.ConvertTABGenerateToGenerate(dbContext.TABGenerate.Where(c => c.ID == id).First());
            return cost;
        }

        public TABGenerate getTABGenerate(int id)
        {
            return dbContext.TABGenerate.Where(c => c.ID == id).First();
        }

        public void updateGenerate(DTGenerate generate)
        {
            TABGenerate generateTab = dbContext.TABGenerate.Where(c => c.ID == generate.id).First();
            generateTab.ID_GAME_OBJECT_FK = generate.idGameObject;
            generateTab.ID_RESOURCE_FK = generate.idResource;
            generateTab.Time = generate.time;
            generateTab.Quantity = generate.quantity;
            dbContext.SaveChanges();
        }
    }
}
