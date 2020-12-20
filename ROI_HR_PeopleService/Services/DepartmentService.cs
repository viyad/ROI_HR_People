using System;
using System.Collections.Generic;
using ROI_HR_PeopleService.Models;

namespace ROI_HR_PeopleService.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }
        public bool DoesDepartmentExist(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(id);
            }

            return _repository.DoesDepartmentExist(id);
        }

        public DepartmentObj Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id");
            }

            return _repository.Find(id);
        }

        public IEnumerable<DepartmentObj> GetData()
        {
            return _repository.All;
        }
    }
}