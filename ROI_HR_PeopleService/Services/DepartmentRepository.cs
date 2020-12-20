using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;
using ROI_HR_PeopleService.Models;

namespace ROI_HR_PeopleService.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private List<DepartmentObj> _departmentsList;

        public DepartmentRepository()
        {
            InitializeData();
        }
        public IEnumerable<DepartmentObj> All
        {
            get { return _departmentsList; }
        }
        public bool DoesDepartmentExist(string id)
        {
            return _departmentsList.Any(department => department.Id == id);
        }
        public DepartmentObj Find(string id)
        {
            return _departmentsList.Where(department => department.Id == id).FirstOrDefault();
        }

        private void InitializeData()
        {
            _departmentsList = new List<DepartmentObj>();
            // Load the xml document
            string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, "Department.xml");
            XDocument xmlDoc = XDocument.Load(filePath);
            //XDocument xmlDoc = XDocument.Load(HostingEnvironment.MapPath("/People.xml"));

            // Get all the descendents department node from the xml file and add and save the DepartmentObj to a list
            // Bind all the data
            // Sort it by its id
            _departmentsList = xmlDoc.Descendants("department").Select(p => new DepartmentObj
            {
                // Assign the values to the DepartmentObj's attibute
                Id = p.Attribute("id").Value,

                // Assign the values to the DepartmentObj's elements
                Name = p.Element("name").Value
            }).OrderBy(p => p.Id).ToList();
        }
    }
}