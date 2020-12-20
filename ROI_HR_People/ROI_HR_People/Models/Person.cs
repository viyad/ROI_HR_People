using System;
using System.Xml.Serialization;

namespace ROI_HR_People.Models
{
    [Serializable]
    public class Person
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Phone")]
        public string Phone { get; set; }
        [XmlElement("Department")]
        public string Department { get; set; }
        [XmlElement("Street")]
        public string Street { get; set; }
        [XmlElement("City")]
        public string City { get; set; }
        [XmlElement("State")]
        public string State { get; set; }
        [XmlElement("Zip")]
        public string Zip { get; set; }
        [XmlElement("Country")]
        public string Country { get; set; }
    }
}