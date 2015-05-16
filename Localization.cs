using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Globalization; 

namespace Clock_Alert
{
    class Localization
    {
        string path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Localizaion.xml";
        public void configure()
        {
            if (!File.Exists(path))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = Encoding.UTF8;
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(path, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Localization");
                    /*writer.WriteStartElement("languagepack");
                    writer.WriteAttributeString("code", "en");
                    writer.WriteElementString("name", "English");
                    writer.WriteElementString("path", Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "en" + Path.DirectorySeparatorChar + "Clock Alert.resources.dll");
                    writer.WriteEndElement();*/
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                addLanguagePack("en", "English");
            }
        }
        public void addLanguagePack(String languageCode, String languageName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement languagePack = doc.CreateElement("languagepack");
            languagePack.SetAttribute("code", languageCode);
            XmlElement name = doc.CreateElement("name");
            name.InnerText = languageName;
            XmlElement langPath = doc.CreateElement("path");
            langPath.InnerText = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + languageCode + Path.DirectorySeparatorChar + "Clock Alert.resources.dll";
            languagePack.AppendChild(name);
            languagePack.AppendChild(langPath);
            doc.DocumentElement.AppendChild(languagePack);
            doc.Save(path);
        }
        
        public static bool CultureExists(string name)
        {
            CultureInfo[] availableCultures =
                CultureInfo.GetCultures(CultureTypes.AllCultures);

            foreach (CultureInfo culture in availableCultures)
            {
                if (culture.Name.Equals(name))
                    return true;
            }

            return false;
        }
    }
}
