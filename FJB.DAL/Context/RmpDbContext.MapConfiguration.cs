using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FJB.Domain.Entities.Leases;
using FJB.Domain.Entities.Robots;
using FJB.Domain.Entities.Specializations;
using FJB.Domain.Entities.Users;

namespace FJB.DAL.Context
{
    public partial class RjbDbContext
    {
        public void MapRobot(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Robot>()
                .HasKey(x => x.RobotId);

            modelBuilder.Entity<Robot>()
                .HasRequired(x => x.Company)
                .WithMany(x=> x.Robots)
                .HasForeignKey(x=> x.CompanyId);

            modelBuilder.Entity<RobotSkill>()
                .HasKey(t => new { t.RobotId, t.SubSpecializationId });

            modelBuilder.Entity<RobotSkill>()
                .HasRequired(x => x.Robot)
                .WithMany(x => x.RobotSkills)
                .HasForeignKey(x => x.RobotId);

            modelBuilder.Entity<RobotSkill>()
                .HasRequired(x => x.SubSpecialization)
                .WithMany(t=> t.Robots)
                .HasForeignKey(x => x.SubSpecializationId);

            modelBuilder.Entity<RobotFeedback>()
                .HasKey(x => x.RobotFeedbackId);

            modelBuilder.Entity<RobotFeedback>()
                .HasRequired(x => x.Robot)
                .WithMany(x => x.RobotFeedbacks)
                .HasForeignKey(x => x.RobotId);

            modelBuilder.Entity<RobotFeedback>()
                .HasRequired(x => x.Client)
                .WithMany()
                .HasForeignKey(x => x.ClientId);
        }

        public void MapLeases(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lease>()
                .HasKey(t => t.LeaseId);

            modelBuilder.Entity<Lease>()
                .HasRequired(t => t.Client)
                .WithMany(t => t.Leases)
                .HasForeignKey(t => t.Client);

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

            modelBuilder.Entity<SubSpecialization>()
                .HasKey(x => x.SubSpecializationId);

            modelBuilder.Entity<SubSpecialization>()
                .HasRequired(t => t.Specialization)
                .WithMany(t=> t.SubSpecializations)
                .HasForeignKey(t => t.SubSpecializationId);
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
