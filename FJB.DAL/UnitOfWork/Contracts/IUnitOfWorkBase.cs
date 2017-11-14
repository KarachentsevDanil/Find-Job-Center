using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJB.DAL.UnitOfWork.Contracts
{
    public interface IUnitOfWorkBase
    {
        void Commit();

        void DisableAutoDetectChanges();

        void EnableAutoDetectChanges();
    }
}
