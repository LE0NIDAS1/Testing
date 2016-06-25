using DataLayer.Model;
using Shared.ActionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALActionConfig /*: IDALGenericCRUD<TABActionConfig, DTActionConfig>*/
    {
        List<TABAttribute> getAllAttributesForGOB(int idGob);
    }
}
