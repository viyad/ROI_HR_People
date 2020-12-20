using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ROI_HR_People.Models;

namespace ROI_HR_People.Data
{
	public class PersonManager
    {
        ISoapService soapService;

		public PersonManager(ISoapService service)
		{
			soapService = service;
		}

		public Task<List<Person>> GetPeopleAsync()
		{
			return soapService.RefreshDataAsync();
		}

		public Task SavePersonAsync(Person person, bool isNewPerson = false)
		{
			return soapService.SavePersonAsync(person, isNewPerson);
		}

		public Task DeletePersonAsync(Person person)
		{
			return soapService.DeletePersonAsync(person.Id);
		}
	}
}
