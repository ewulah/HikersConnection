using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HikersConnection.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Hike> Hikes { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<Hiker> Hikers { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
    }
}