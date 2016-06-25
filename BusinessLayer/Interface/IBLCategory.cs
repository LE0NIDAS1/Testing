using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBLCategory
    {
        void addCategory(DTCategory cat);
        void deleteCategory(int id);
        List<DTCategory> getAllCategories();
        DTCategory getCategory(int id);
        void updateCategory(DTCategory cat);

        List<DTCategory> getCategoriesByGameId(int id);
        List<DTCategory> getCategoriesByGameName(string name);
        List<DTCategory> getCategoriesByGameTenant(string tenantIdentity);
    }
}
