using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PresentationLayer.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AtlasAspNet", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PresentationLayer.Models.ResourceModel> ResourceModels { get; set; }

        public System.Data.Entity.DbSet<PresentationLayer.Models.CategoryModel> CategoryModels { get; set; }

        public System.Data.Entity.DbSet<PresentationLayer.Models.GameObjectModel> GameObjectModels { get; set; }

        public System.Data.Entity.DbSet<PresentationLayer.Models.AttributeModel> AttributeModels { get; set; }

        public System.Data.Entity.DbSet<PresentationLayer.Models.CostModel> CostModels { get; set; }

        public System.Data.Entity.DbSet<PresentationLayer.Models.InitialGameObjectModel> InitialGameObjectModels { get; set; }

        public System.Data.Entity.DbSet<PresentationLayer.Models.InitialResourceModel> InitialResourceModels { get; set; }

        public System.Data.Entity.DbSet<PresentationLayer.Models.ActionModels.SimpleAttackModel> SimpleAttackModels { get; set; }
    }
}