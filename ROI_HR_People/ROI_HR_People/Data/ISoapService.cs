using System.Collections.Generic;
using System.Threading.Tasks;
using ROI_HR_People.Models;

namespace ROI_HR_People.Data
{
    public interface ISoapService
    {
        Task<List<Person>> RefreshDataAsync();

        Task SavePersonAsync(Person person, bool isNewPerson);

        Task DeletePersonAsync(string id);
    }
}
