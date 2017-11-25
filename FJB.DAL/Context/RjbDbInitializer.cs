using System.Collections.Generic;
using System.Data.Entity;
using FJB.Domain.Entities.Specializations;

namespace FJB.DAL.Context
{
    public class RjbDbInitializer : DropCreateDatabaseIfModelChanges<RjbDbContext>
    {
        protected override void Seed(RjbDbContext context)
        {
            IList<Specialization> defaultSpecializations = new List<Specialization>();

            defaultSpecializations.Add(new Specialization { Name = "Builder"});
            defaultSpecializations.Add(new Specialization { Name = "Engeneir" });
            defaultSpecializations.Add(new Specialization { Name = "Repairer" });
            defaultSpecializations.Add(new Specialization { Name = "Heavier" });

            foreach (var specialization in defaultSpecializations)
                context.Specializations.Add(specialization);

            base.Seed(context);
        }
    }
}
