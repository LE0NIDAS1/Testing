using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBLAttribute
    {
        void addAttribute(DTAttribute atr);
        void deleteAttribute(int id);
        List<DTAttribute> getAllAttributes();
        DTAttribute getAttribute(int id);
        void updateAttribute(DTAttribute atr);
        bool isValid(string Name, int id, int idGameObject);
    }
}
