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
    public class BLCategory : IBLCategory
    {
        private IDALCategory dalCat = new DALCategory();

        public BLCategory()
        {
            dalCat = new DALCategory();
        }

        public BLCategory(IDALCategory _dalCat)
        {
            dalCat = _dalCat;
        }

        public void addCategory(DTCategory cat)
        {
            try
            {
                dalCat.addCategory(cat);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void deleteCategory(int id)
        {
            try
            {
                dalCat.deleteCategory(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public List<DTCategory> getAllCategories()
        {
            try
            {
                return dalCat.getAllCategories();
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public DTCategory getCategory(int id)
        {
            try
            {
                return dalCat.getCategory(id);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }

        public void updateCategory(DTCategory cat)
        {
            try
            {
                dalCat.updateCategory(cat);
            }
            catch (Exception)
            {
                throw new Exception("error desconocido");;
            }
        }
        public List<DTCategory> getCategoriesByGameName(string name)
        {

            return dalCat.getCategoriesByGameName(name);    
        }

        public List<DTCategory> getCategoriesByGameId(int id)
        {

            return dalCat.getCategoriesByGameId(id);
        }

        public List<DTCategory> getCategoriesByGameTenant(string tenantIdentity)
        {
            return dalCat.getCategoriesByGameTenant(tenantIdentity);
        }
    }
}
