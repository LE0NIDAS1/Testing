using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Shared.JuegoEntities;

namespace DataLayer.JuegoInterfaces
{
    public interface IDALInitialResource
    {
        void addInitialResource(DTInitialResource ires);
        void deleteInitialResource(int idResource, int idGame);
        List<DTInitialResource> getAllInitialResource();
        TABInitialResource getTABInitialResource(int idResource, int idGame);
        DTInitialResource getInitialResource(int idResource, int idGame);
        void updateInitialResource(DTInitialResource ires);
    }
}
