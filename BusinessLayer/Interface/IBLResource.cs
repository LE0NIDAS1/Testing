using Shared.JuegoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBLResource
    {
        void addResource(DTResource res);
        void deleteResource(int id);
        List<DTResource> getAllResources();
        DTResource getResource(int id);
        void updateResource(DTResource res);
        List<DTResource> getResourcesByGameId(int id);
        List<DTResource> getResourcesByGameName(string name);
        List<DTResource> getResourcesByGameTenant(string tenantIdentity);
    }
}
