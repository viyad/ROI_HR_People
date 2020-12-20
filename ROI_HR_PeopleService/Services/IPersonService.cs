using System.Collections.Generic;
using ROI_HR_PeopleService.Models;

namespace ROI_HR_PeopleService.Services
{
    public interface IPersonService
    {
        bool DoesPersonExist(string id);
        Person Find(string id);
        IEnumerable<Person> GetData();
        void InsertData(Person person);
        void UpdateData(Person person);
        void DeleteData(string id);
    }
}