using System.Data.Entity;
using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Robots;
using FJB.Domain.Entities.Specializations;
using FJB.Domain.Entities.Users;
using FJB.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FJB.DAL.Context
{
    public partial class RjbDbContext : IdentityDbContext<ApplicationUser>
    {
        //TODO Move connection string to app config
        public RjbDbContext()
            : base(@"data source=(LocalDb)\MSSQLLocalDB;
                        initial catalog=IdentityBlogEntities;
                        integrated security=True;MultipleActiveResultSets=True;
                        App=EntityFramework")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Lease> Lease { get; set; }

        public DbSet<RobotLease> RobotsLease { get; set; }

        public DbSet<Robot> Robots { get; set; }

        public DbSet<RobotFeedback> RobotFeedbacks { get; set; }

        public DbSet<RobotSkill> RobotSkills { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<SubSpecialization> SubSpecializations { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            MapRobot(modelBuilder);

            MapLeases(modelBuilder);

            MapSpecialization(modelBuilder);

            MapUser(modelBuilder);
        }
    }
}
