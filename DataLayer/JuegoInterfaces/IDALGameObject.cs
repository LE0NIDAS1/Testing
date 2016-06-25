using DataLayer.Model;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALGameObject
    {
        void addGameObject(DTGameObject gob);
        void deleteGameObject(int id);
        List<DTGameObject> getAllGameObjects();
        TABGameObject getTABGameObject(int id);
        DTGameObject getGameObject(int id);
        void updateGameObject(DTGameObject gob);
        List<DTGameObject> getGameObjectsByGameID(int id);
        List<DTGameObject> getGameObjectsByGameAndCategory(int idGame, int idCategory);
        bool isValid(string Name, int id, int idGame, int idCategory);
        List<DTCost> getCostsForGameObject(int idGameObject);
        string getTimeConstructionOfGameObject(int idGameObject);       
    }
}