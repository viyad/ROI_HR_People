using System.Collections.Generic;
using ROI_HR_PeopleService.Models;

namespace ROI_HR_PeopleService.Services
{
    public interface IPersonRepository
    {
        bool DoesPersonExist(string id);
        IEnumerable<Person> All { get; }
        Person Find(string id);
        void Insert(Person person);
        void Update(Person person);
        void Delete(string id);
    }
}