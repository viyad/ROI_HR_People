using System;
using System.Collections.Generic;
using ROI_HR_PeopleService.Models;

namespace ROI_HR_PeopleService.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }

        public bool DoesPersonExist(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(id);
            }

            return _repository.DoesPersonExist(id);
        }

        public Person Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Id");
            }

            return _repository.Find(id);
        }

        public IEnumerable<Person> GetData()
        {
            return _repository.All;
        }

        public void InsertData(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("Person");
            }

            _repository.Insert(person);
        }

        public void UpdateData(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("Person");
            }

            _repository.Update(person);
        }

        public void DeleteData(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("Id");
            }

            _repository.Delete(id);
        }
    }
}