using System.Data.Entity;
using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Robots;
using FJB.Domain.Entities.Specializations;
using FJB.Domain.Entities.Users;

namespace FJB.DAL.Context
{
    public partial class RobotJobFinderDbContext
    {
        public void MapRobot(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Robot>()
                .HasKey(x => x.RobotId);

            modelBuilder.Entity<Robot>()
                .HasRequired(x => x.Company)
                .WithMany(x=> x.Robots)
                .HasForeignKey(x=> x.CompanyId);

            modelBuilder.Entity<Robot>()
                .HasRequired(x => x.RobotModel)
                .WithMany(x => x.Robots)
                .HasForeignKey(x => x.RobotModelId);

            modelBuilder.Entity<RobotModelSpecialization>()
                .HasKey(t => new { t.RobotModelId, t.SpecializationId });

            modelBuilder.Entity<RobotModelSpecialization>()
                .HasRequired(x => x.RobotModel)
                .WithMany(x => x.RobotModelSpecializations)
                .HasForeignKey(x => x.RobotModelId);

            modelBuilder.Entity<RobotModelSpecialization>()
                .HasRequired(x => x.Specialization)
                .WithMany(x=> x.RobotModelSpecializations)
                .HasForeignKey(x => x.SpecializationId);
        }

        public void MapLeases(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lease>()
                .HasKey(t => t.LeaseId);

            modelBuilder.Entity<Lease>()
                .HasRequired(t => t.Client)
                .WithMany(t => t.Leases)
                .HasForeignKey(t => t.ClientId);

            modelBuilder.Entity<RobotLease>()
                .HasKey(t => t.RobotLeaseId);

            modelBuilder.Entity<RobotLease>()
                .HasRequired(t => t.Robot)
                .WithMany(t=> t.RobotLeases)
                .HasForeignKey(t=> t.RobotId);

            modelBuilder.Entity<RobotLease>()
                .HasRequired(t => t.Lease)
                .WithMany(t => t.RobotLeases)
                .HasForeignKey(t => t.LeaseId);
        }

        public void MapSpecialization(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>()
                .HasKey(x => x.SpecializationId);
        }

        public void MapUser(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(x => x.ClientId);

            modelBuilder.Entity<Company>()
                .HasKey(x => x.CompanyId);
        }
    }
}
