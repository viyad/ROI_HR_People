using System.Collections.Generic;
using ROI_HR_PeopleService.Models;

namespace ROI_HR_PeopleService.Services
{
    public interface IDepartmentService
    {
        DepartmentObj Find(string id);
        IEnumerable<DepartmentObj> GetData();
    }
}