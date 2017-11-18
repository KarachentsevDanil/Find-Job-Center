namespace FJB.DAL.UnitOfWork.Contracts
{
    public interface IUnitOfWorkBase
    {
        void Commit();

        void DisableAutoDetectChanges();

        void EnableAutoDetectChanges();
    }
}
