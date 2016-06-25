using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBLGameObject
    {
        void addGameObject(DTGameObject gob);
        void deleteGameObject(int id);
        List<DTGameObject> getAllGameObjects();
        DTGameObject getGameObject(int id);
        void updateGameObject(DTGameObject gob);
        List<DTGameObject> getGameObjectsByGameID(int id);
        List<DTGameObject> getGameObjectsByGameAndCategory(int id, int category);
        bool isValid(string Name, int id, int idGame, int idCategory);
        List<DTCost> getCostsOfGameObject(int idGameObject);
        string getTimeConstructionOfGameObject(int idGameObject);
    }
}
