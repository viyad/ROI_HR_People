using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using ROI_HR_PeopleService.Models;

namespace ROI_HR_PeopleService
{
    public partial class People : System.Web.UI.Page
    {
        private List<Person> _people;
        protected void Page_Load(object sender, EventArgs e)
        {
            ROI_HR_PeopleService.PeopleService peopleService = new ROI_HR_PeopleService.PeopleService();
            _people = peopleService.GetPeople();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>), new XmlRootAttribute("People"));
            var xmlContent = new StringWriter();
            serializer.Serialize(xmlContent, _people);
            Xml1.DocumentContent = xmlContent.ToString();
            Xml1.TransformSource = Server.MapPath("PeopleStyle.xslt");
        }

        // Find
        protected void btnFind_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtId.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Id must be a number!');", true);
                txtId.Focus();
            }
            else
            {
                Person person = _people.FirstOrDefault(p => p.Id == txtId.Text);
                if (person != null)
                {
                    txtName.Text = person.Name;
                    txtPhone.Text = person.Phone;
                    txtDepartment.Text = person.Department;
                    txtStreet.Text = person.Street;
                    txtCity.Text = person.City;
                    txtState.Text = person.State;
                    txtZip.Text = person.Zip;
                    txtCountry.Text = person.Country;
                }
            }
        }

        // Add
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Person person = getPersonObjInput();
            try
            {
                //if (validInput(person))
                {
                    ROI_HR_PeopleService.PeopleService peopleService = new ROI_HR_PeopleService.PeopleService();
                    peopleService.CreatePerson(person);
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
            catch (SoapException exp)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.Message + "');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.ToString() + "');", true);
            }
        }

        // Update
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Connect to MovieWS Web Service
            Person person = getPersonObjInput();
            try
            {
                //if (validInput(person))
                {
                    ROI_HR_PeopleService.PeopleService peopleService = new ROI_HR_PeopleService.PeopleService();
                    peopleService.EditPerson(person);
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
            catch (SoapException exp)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.Message + "');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.ToString() + "');", true);
            }
        }

        // Delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate id input if it is not empty and exist
                //if (!String.IsNullOrEmpty(txtId.Text))
                {
                    ROI_HR_PeopleService.PeopleService peopleService = new ROI_HR_PeopleService.PeopleService();
                    // Call DeletePerson method of MovieWS web service and passing ID to the method
                    peopleService.DeletePerson(txtId.Text);
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);

                }
            }
            catch (SoapException exp)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + exp.Message + "');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.ToString() + "');", true);
            }
        }

        private bool validInput(Person person)
        {
            bool valid = !(person == null ||
                    string.IsNullOrWhiteSpace(person.Name) ||
                    string.IsNullOrWhiteSpace(person.Phone) ||
                    string.IsNullOrWhiteSpace(person.Department) ||
                    string.IsNullOrWhiteSpace(person.Street) ||
                    string.IsNullOrWhiteSpace(person.City) ||
                    string.IsNullOrWhiteSpace(person.State) ||
                    string.IsNullOrWhiteSpace(person.Zip) ||
                    string.IsNullOrWhiteSpace(person.Country));

                return valid;
        }

        private Person getPersonObjInput()
        {
            Person person = new Person();
            person.Id = txtId.Text;
            person.Name = txtName.Text;
            person.Phone = txtPhone.Text;
            person.Department = txtDepartment.Text;
            person.Street = txtStreet.Text;
            person.City = txtCity.Text;
            person.State = txtState.Text;
            person.Zip = txtZip.Text;
            person.Country = txtCountry.Text;

            return person;
        }
    }
}