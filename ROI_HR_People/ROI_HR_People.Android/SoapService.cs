using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using ROI_HR_People.Data;
using ROI_HR_People.Models;

namespace ROI_HR_People.Droid
{
    public class SoapService : ISoapService
    {
        ROI_HR_PeopleService.PeopleService peopleService;
        TaskCompletionSource<bool> getRequestComplete = null;
        TaskCompletionSource<bool> saveRequestComplete = null;
        TaskCompletionSource<bool> deleteRequestComplete = null;

        public List<Person> People { get; private set; } = new List<Person>();

        public SoapService()
        {
            peopleService = new ROI_HR_PeopleService.PeopleService();
            peopleService.Url = Constants.SoapUrl;

            peopleService.GetPeopleCompleted += PeopleService_GetPeopleCompleted;
            peopleService.CreatePersonCompleted += PeopleService_SavePersonCompleted;
            peopleService.EditPersonCompleted += PeopleService_SavePersonCompleted;
            peopleService.DeletePersonCompleted += PeopleService_DeletePersonCompleted;
        }

        ROI_HR_PeopleService.Person ToROI_HR_PeopleServicePerson(Person person)
        {
            return new ROI_HR_PeopleService.Person
            {
                Id = person.Id,
                Name = person.Name,
                Phone = person.Phone,
                Department = person.Department,
                Street = person.Street,
                City = person.City,
                State = person.State,
                Zip = person.Zip,
                Country = person.Country
    };
        }

        static Person FromROI_HR_PeopleServicePerson(ROI_HR_PeopleService.Person person)
        {
            Person p = new Person();
            p.Id = person.Id;
            p.Name = person.Name;
            p.Phone = person.Phone;
            p.Department = person.Department;

            p.Street = person.Street;
            p.City = person.City;
            p.State = person.State;
            p.Zip = person.Zip;
            p.Country = person.Country;

            return p;
        }

        private void PeopleService_GetPeopleCompleted(object sender, ROI_HR_PeopleService.GetPeopleCompletedEventArgs e)
        {
            try
            {
                getRequestComplete = getRequestComplete ?? new TaskCompletionSource<bool>();

                People = new List<Person>();
                foreach (var person in e.Result)
                {
                    People.Add(FromROI_HR_PeopleServicePerson(person));
                }
                getRequestComplete?.TrySetResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }

        private void PeopleService_SavePersonCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            saveRequestComplete?.TrySetResult(true);
        }

        private void PeopleService_DeletePersonCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            deleteRequestComplete?.TrySetResult(true);
        }

        public async Task<List<Person>> RefreshDataAsync()
        {
            getRequestComplete = new TaskCompletionSource<bool>();
            peopleService.GetPeopleAsync();
            await getRequestComplete.Task;
            return People;
        }

        public async Task SavePersonAsync(Person person, bool isNewPerson = false)
        {
            try
            {
                var human = ToROI_HR_PeopleServicePerson(person);
                saveRequestComplete = new TaskCompletionSource<bool>();
                if (isNewPerson)
                {
                    peopleService.CreatePersonAsync(human);
                }
                else
                {
                    peopleService.EditPersonAsync(human);
                }
                await saveRequestComplete.Task;
            }
            catch (SoapException se)
            {
                Debug.WriteLine("\t\t{0}", se.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }

        public async Task DeletePersonAsync(string id)
        {
            try
            {
                deleteRequestComplete = new TaskCompletionSource<bool>();
                peopleService.DeletePersonAsync(id);
                await deleteRequestComplete.Task;
            }
            catch (SoapException se)
            {
                Debug.WriteLine("\t\t{0}", se.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }
    }
}