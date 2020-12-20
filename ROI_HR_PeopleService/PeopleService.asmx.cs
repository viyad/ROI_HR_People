using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using ROI_HR_PeopleService.Models;
using ROI_HR_PeopleService.Services;

namespace ROI_HR_PeopleService
{
    /// <summary>
    /// Summary description for PeopleService
    /// </summary>
    [WebService(Namespace = "http://www.xamarin.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PeopleService : System.Web.Services.WebService
    {

        static readonly IPersonService personService = new Services.PersonService(new PersonRepository());
        static readonly IDepartmentService departmentService = new Services.DepartmentService(new DepartmentRepository());

        [WebMethod]
        public List<DepartmentObj> GetDepartments()
        {
            return departmentService.GetData().ToList();
        }

        [WebMethod]
        public List<Person> GetPeople()
        {
            return personService.GetData().ToList();
        }

        [WebMethod]
        public void CreatePerson(Person person)
        {
            try
            {
                if (person == null ||
                    string.IsNullOrWhiteSpace(person.Name) ||
                    string.IsNullOrWhiteSpace(person.Phone) ||
                    string.IsNullOrWhiteSpace(person.Department) ||
                    string.IsNullOrWhiteSpace(person.Street) ||
                    string.IsNullOrWhiteSpace(person.City) ||
                    string.IsNullOrWhiteSpace(person.State) ||
                    string.IsNullOrWhiteSpace(person.Zip) ||
                    string.IsNullOrWhiteSpace(person.Country))
                {
                    throw new SoapException("Person details are required", SoapException.ClientFaultCode);
                }

                // Determine if the Id already exists
                var personExists = personService.DoesPersonExist(person.Id);
                if (personExists)
                {
                    throw new SoapException("Person Id is in use", SoapException.ClientFaultCode);
                }
                personService.InsertData(person);
            }
            catch (Exception ex)
            {
                throw new SoapException("Error - person details are required or person Id is in use", SoapException.ServerFaultCode, ex);
            }
        }

        [WebMethod]
        public void EditPerson(Person person)
        {
            try
            {
                if (person == null ||
                    string.IsNullOrWhiteSpace(person.Name) ||
                    string.IsNullOrWhiteSpace(person.Phone) ||
                    string.IsNullOrWhiteSpace(person.Department) ||
                    string.IsNullOrWhiteSpace(person.Street) ||
                    string.IsNullOrWhiteSpace(person.City) ||
                    string.IsNullOrWhiteSpace(person.State) ||
                    string.IsNullOrWhiteSpace(person.Zip) ||
                    string.IsNullOrWhiteSpace(person.Country))
                {
                    throw new SoapException("Person details are required", SoapException.ClientFaultCode);
                }

                var foundPerson = personService.Find(person.Id);
                if (foundPerson != null)
                {
                    personService.UpdateData(person);
                }
                else
                {
                    throw new SoapException("Person not found", SoapException.ClientFaultCode);
                }
            }
            catch (Exception ex)
            {
                throw new SoapException("Error - person details are required or person is not found", SoapException.ServerFaultCode, ex);
            }
        }

        [WebMethod]
        public void DeletePerson(string id)
        {
            try
            {
                var foundPerson = personService.Find(id);
                if (foundPerson != null)
                {
                    personService.DeleteData(id);
                }
                else
                {
                    throw new SoapException("Person not found", SoapException.ClientFaultCode);
                }
            }
            catch (Exception ex)
            {
                throw new SoapException("Error - person is not found", SoapException.ServerFaultCode, ex);
            }
        }

    }
}
