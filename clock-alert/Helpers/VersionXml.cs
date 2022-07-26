using System;
using System.Xml.Serialization;

namespace ClockAlert.Helpers
{
    [Serializable, XmlRoot("clockalert",Namespace = "https://clockalert.sourceforge.io/")]
    public class VersionXml
    {
        [XmlElement(DataType = "string", ElementName = "version")]
        public string version;

        [XmlElement(DataType ="string",ElementName ="url")]
        public string url;

        [XmlIgnore]
        public Version Version
        {
            get => Version.Parse(version);
            set => version = value.ToString();
        }

        [XmlIgnore]
        public Uri Url
        {
            get => new Uri(url);
            set =>url = value.ToString();
        }
    }
}
