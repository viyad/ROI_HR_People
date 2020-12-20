using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ROI_HR_PeopleService
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xmlContent = File.ReadAllText(Server.MapPath("Department.xml"));
            Xml1.DocumentContent = xmlContent;
            Xml1.TransformSource = Server.MapPath("DepartmentStyle.xslt");

        }
    }
}