using System;
using System.Xml.Serialization;

namespace XO
{
    [XmlType("statistics")]
    public class Statistics
    {
        [XmlElement("date")]
        public DateTime Date { get; set; }

        [XmlElement("result")]
        public GameStatus Result { get; set; }

        [XmlElement("name")]
        public string UserName { get; set; }

        [XmlElement("step")]
        public int StepCounter { get; set; }
    }
}
