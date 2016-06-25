using DataLayer.Model;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALAttribute
    {
        void addAttribute(DTAttribute atr);
        void deleteAttribute(int id);
        List<DTAttribute> getAllAttributes();
        TABAttribute getTABAttribute(int id);
        DTAttribute getAttribute(int id);
        void updateAttribute(DTAttribute atr);
        bool isValid(string Name, int id, int idGameObject);
        bool gameObjectAttack(int idGameObject);
        bool gameObjectDefend(int idGameObject);
        int valueAttack(int idGameObject);
        int valueDefense(int idGameObject);
    }
}
