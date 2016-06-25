using DataLayer.JuegoInterfaces;
using System.Collections.Generic;
using System.Linq;
using Shared.JuegoEntities;
using DataLayer.Model;
using DataLayer.Helper;
using System;

namespace DataLayer.JuegoClasses
{
    public class DALCategory : IDALCategory
    {
        private AtlasConexion dbContext = new AtlasConexion();

        public void addCategory (DTCategory cat)
        {
            TABCategory catTAB = new TABCategory();
            catTAB.Name = cat.name;
            catTAB.ToolTip = cat.toolTip;
            catTAB.Image = cat.image;
            catTAB.ID_GAME_FK = cat.idGame;
            dbContext.TABCategory.Add(catTAB);
            dbContext.SaveChanges();
        }

        public void deleteCategory(int id)
        {
            dbContext.TABCategory.Remove(getTABCategory(id));
            dbContext.SaveChanges();
        }

        public List<DTCategory> getAllCategories()
        {
            List<DTCategory> listaCatturn = new List<DTCategory>();
            List<TABCategory> listaBase = dbContext.TABCategory.ToList();
            foreach (TABCategory TABCategory in listaBase)
            {
                listaCatturn.Add(ConvertHelper.ConvertTABCategorytoCategory(TABCategory));
            }
            return listaCatturn;
        }

        public TABCategory getTABCategory(int id)
        {
            TABCategory catTAB = dbContext.TABCategory.Where(n => n.ID == id).First();
            return catTAB;
        }

        public DTCategory getCategory(int id)
        {
            DTCategory cat = ConvertHelper.ConvertTABCategorytoCategory(dbContext.TABCategory.Where(n => n.ID == id).First());
            return cat;
        }

        public void updateCategory(DTCategory cat)
        {
            TABCategory catTAB = dbContext.TABCategory.Where(n => n.ID == cat.id).First();
            catTAB.Name = cat.name;
            catTAB.ToolTip = cat.toolTip;
            catTAB.Image = cat.image;
            dbContext.SaveChanges();
        }

        public List<DTCategory> getCategoriesByGameId(int id)
        {
            try
            {
                dbContext = new AtlasConexion();
                List<TABCategory> results = dbContext.TABCategory.Where(n => n.ID_GAME_FK.Equals(id)).ToList();
                return results.Select(n => ConvertHelper.ConvertTABCategorytoCategory(n)).ToList();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTCategory> getCategoriesByGameName(string name)
        {
            try
            {
                dbContext = new AtlasConexion();
                List<TABCategory> results = dbContext.TABCategory.Where(n => n.TABGame.Name == name).ToList();
                List<DTCategory> categories = new List<DTCategory>();
                foreach (TABCategory TABCategory in results)
                {
                    categories.Add(ConvertHelper.ConvertTABCategorytoCategory(TABCategory));
                }
                return categories;
            }
            catch(Exception)
            {
                throw new Exception("error desconocido");;
            }
           
        }

        public List<DTCategory> getCategoriesByGameTenant(string tenantIdentity)
        {
            try
            {
                dbContext = new AtlasConexion();
                List<TABCategory> results = dbContext.TABCategory.Where(n => n.TABGame.Dominio.Trim().ToLower().Equals(tenantIdentity)).ToList();
                return results.Select(n => ConvertHelper.ConvertTABCategorytoCategory(n)).ToList();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }
    }
}
