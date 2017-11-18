namespace RJB.BLL.Specializations.Contracts
{
    public interface ISpecializationService
    {
        void AddSpecialization(string name);

        void AddSubSpecialization(int parentId, string name);
    }
}
