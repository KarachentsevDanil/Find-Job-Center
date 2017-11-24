using System;
using System.Collections.Generic;
using System.Linq;
using FJB.DAL.UnitOfWork.Contracts;
using FJB.Domain.Entities.Params;
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
            var filterParams = new FilterParams<Specialization>(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
            return _unitOfWork.Specializations.GetItemsByExpression(filterParams);
        }

        public Specialization GetSpecializationById(int id)
        {
            return _unitOfWork.Specializations.GetItemByExpression(x => x.SpecializationId == id);
        }

        public IEnumerable<Specialization> GetChildSpecializationsByParentId(int id)
        {
            var filterParams = new FilterParams<Specialization>(x => x.ParentSpecializationId == id);
            return _unitOfWork.Specializations.GetItemsByExpression(filterParams);
        }

        public IEnumerable<Specialization> GetSpecializationsByIds(int[] ids)
        {
            var filterParams = new FilterParams<Specialization>(x => ids.Contains(x.SpecializationId));
            return _unitOfWork.Specializations.GetItemsByExpression(filterParams);
        }

        public IEnumerable<Specialization> GetRootSpecializations()
        {
            var filterParams = new FilterParams<Specialization>(x => !x.ParentSpecializationId.HasValue);
            return _unitOfWork.Specializations.GetItemsByExpression(filterParams);
        }
    }
}
