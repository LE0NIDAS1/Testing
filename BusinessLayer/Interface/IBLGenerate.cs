using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBLGenerate
    {
        void addGenerate(DTGenerate generate);
        void deleteGenerate(int id);
        List<DTGenerate> getAllGenerates();
        DTGenerate getGenerate(int id);
        void updateGenerate(DTGenerate generate);
    }
}
