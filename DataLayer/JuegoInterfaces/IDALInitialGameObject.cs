using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Shared.JuegoEntities;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALInitialGameObject
    {
        void addInitialGameObject(DTInitialGameObject gob);
        void deleteInitialGameObject(int idGameObject, int idGame);
        List<DTInitialGameObject> getAllInitialGameObjects();
        TABInitialGameObject getTABInitialGameObject(int idGameObject, int idGame);
        DTInitialGameObject getInitialGameObject(int idGameObject, int idGame);
        void updateGameObject(DTInitialGameObject igob);
    }
}