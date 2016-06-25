using Shared.ActionEntities;
using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBLCreate : IBLGenericCRUD<DTCrearConfig>
    {
        List<DTGameObject> GetAllGOBTime(int idGame);
    }
}
