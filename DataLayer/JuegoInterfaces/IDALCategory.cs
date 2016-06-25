using DataLayer.Model;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALCategory
    {
        void addCategory(DTCategory cat);
        void deleteCategory(int id);
        List<DTCategory> getAllCategories();
        TABCategory getTABCategory(int id);
        DTCategory getCategory(int id);
        void updateCategory(DTCategory cat);
        List<DTCategory> getCategoriesByGameName(string name);
        List<DTCategory> getCategoriesByGameId(int id);
        List<DTCategory> getCategoriesByGameTenant(string tenantIdentity);
    }
}
