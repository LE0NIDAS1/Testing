using DataLayer.Model;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALGenerate
    {
        void addGenerate(DTGenerate generate);
        void deleteGenerate(int id);
        List<DTGenerate> getAllGenerates();
        TABGenerate getTABGenerate(int id);
        DTGenerate getGenerate(int id);
        void updateGenerate(DTGenerate generate);
    }
}
