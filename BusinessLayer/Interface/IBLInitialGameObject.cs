using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBLInitialGameObject
    {
        void addInitialGameObject(DTInitialGameObject igob);
        void deleteInitialGameObject(int idGame, int idGameObject);
        List<DTInitialGameObject> getAllInitialGameObjects();
        DTInitialGameObject getInitialGameObject(int idGame, int idGameObject);
        void updateInitialGameObject(DTInitialGameObject igob);
    }
}
