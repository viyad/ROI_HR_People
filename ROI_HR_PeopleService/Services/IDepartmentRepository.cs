using System.Collections.Generic;
using ROI_HR_PeopleService.Models;

namespace ROI_HR_PeopleService.Services
{
    public interface IDepartmentRepository
    {
        bool DoesDepartmentExist(string id);
        IEnumerable<DepartmentObj> All { get; }
        DepartmentObj Find(string id);
    }
}