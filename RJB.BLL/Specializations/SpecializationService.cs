using System;
using System.Collections.Generic;
using System.Linq;
using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Specializations;
using RJB.BLL.Specializations.Contracts;

namespace RJB.BLL.Specializations
{
    public class SpecializationService : ISpecializationService
    {
        private readonly IRjbUnitOfWorkBase _unitOfWork;

        public SpecializationService(IRjbUnitOfWorkBase unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddSpecialization(string name)
        {
            _unitOfWork.Specializations.Add(new Specialization { Name = name });
            _unitOfWork.Commit();
        }

        public void AddSubSpecialization(int parentId, string name)
        {
            _unitOfWork.Specializations.Add(new Specialization { Name = name, ParentSpecializationId = parentId});
            _unitOfWork.Commit();
        }

        public IEnumerable<Specialization> GetSpecializationsByName(string name)
        {
            return _unitOfWork.Specializations.GetItemsByExpression(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }

        public Specialization GetSpecializationById(int id)
        {
            return _unitOfWork.Specializations.GetItemByExpression(x => x.SpecializationId == id);
        }

        public IEnumerable<Specialization> GetChildSpecializationsByParentId(int id)
        {
            return _unitOfWork.Specializations.GetItemsByExpression(x => x.ParentSpecializationId == id);
        }

        public IEnumerable<Specialization> GetSpecializationsByIds(int[] ids)
        {
            return _unitOfWork.Specializations.GetItemsByExpression(x => ids.Contains(x.SpecializationId));
        }

        public IEnumerable<Specialization> GetRootSpecializations()
        {
            return _unitOfWork.Specializations.GetItemsByExpression(x => !x.ParentSpecializationId.HasValue);
        }
    }
}
