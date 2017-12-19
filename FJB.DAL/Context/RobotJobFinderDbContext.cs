using System.Data.Entity;
using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Robots;
using FJB.Domain.Entities.Specializations;
using FJB.Domain.Entities.Users;

namespace FJB.DAL.Context
{
    public partial class RobotJobFinderDbContext : DbContext
    {
        public RobotJobFinderDbContext()
            : base(@"data source=.\SQLEXPRESS;
                        initial catalog=RobotJobFinderDataBase;
                        integrated security=True;MultipleActiveResultSets=True;
                        App=EntityFramework")
        {
        }

        public DbSet<Lease> Lease { get; set; }

        public DbSet<RobotLease> RobotsLease { get; set; }

        public DbSet<Robot> Robots { get; set; }

        public DbSet<RobotModel> RobotModels { get; set; }

        public DbSet<RobotModelSpecialization> RobotModelSpecializations { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new RobotJobFinderDbInitializer());

            base.OnModelCreating(modelBuilder);

            MapRobot(modelBuilder);

            MapLeases(modelBuilder);

            MapSpecialization(modelBuilder);

            MapUser(modelBuilder);
        }
    }
}
