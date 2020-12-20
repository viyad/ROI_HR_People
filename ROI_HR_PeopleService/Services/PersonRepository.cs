using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;
using System.Xml.Serialization;
using ROI_HR_PeopleService.Models;

namespace ROI_HR_PeopleService.Services
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _peopleList;

        public PersonRepository()
        {
            InitializeData();
        }
        public IEnumerable<Person> All
        {
            get { return _peopleList; }
        }
        public bool DoesPersonExist(string id)
        {
            return _peopleList.Any(person => person.Id == id);
        }
        public Person Find(string id)
        {
            return _peopleList.Where(person => person.Id == id).FirstOrDefault();
        }
        public void Insert(Person person)
        {
            _peopleList.Add(person);
            string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, "People.xml");
            Serializer("People.xml");
        }
        public void Update(Person person)
        {     
            var foundPerson = Find(person.Id);
            var index = _peopleList.IndexOf(foundPerson);

            if (foundPerson != null)
            { 
                _peopleList.RemoveAt(index);
                _peopleList.Insert(index, person);
                Serializer("People.xml");
            }
        }
        public void Delete(string id)
        {
            _peopleList.Remove(Find(id));
            Serializer("People.xml");
        }
        private void InitializeData()
        {
            _peopleList = new List<Person>();
            // Load the xml document
            string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, "People.xml");
            XDocument xmlDoc = XDocument.Load(filePath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>), new XmlRootAttribute("People"));
            StringReader reader = new StringReader(xmlDoc.ToString());
            _peopleList = (List<Person>)serializer.Deserialize(reader);
        }

        private void Serializer(string fileName)
        {
            string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, "People.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>), new XmlRootAttribute("People"));
            using (var xmlContent = new StreamWriter(filePath))
            {
                serializer.Serialize(xmlContent, _peopleList);
            }
        }
    }
}