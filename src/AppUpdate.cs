/***********************************************************************************
This file is part of Clock Alert.

    Clock Alert is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License version 3 as published by
    the Free Software Foundation.

    Clock Alert is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Clock Alert.  If not, see <http://www.gnu.org/licenses/>.
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Clock_Alert
{
    class AppUpdate
    {
        private Version newVersion, currentVersion;
        private XmlTextReader reader;
        private string url, elementName,xmlUrl;
        public AppUpdate()
        {
            newVersion = null;
            currentVersion = null;
            reader = null;
            url = string.Empty;
            elementName = string.Empty;
            xmlUrl = string.Empty;
        }

        private void getVersion()
        {
            xmlUrl="http://clockalert.sourceforge.net/version.xml";
            try
            {
                reader=new XmlTextReader(xmlUrl);
                reader.MoveToContent();
                if(reader.NodeType==XmlNodeType.Element && reader.Name=="clockalert")
                {
                    while(reader.Read())
                    {
                        if(reader.NodeType==XmlNodeType.Element)
                            elementName=reader.Name;
                        else
                        {
                            if(reader.NodeType==XmlNodeType.Text &&reader.HasValue)
                            {
                                switch(elementName)
                                {
                                    case "version":
                                        newVersion=new Version(reader.Value);
                                        break;
                                    case "url":
                                        url=reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                CrashReporterUI reporter=new CrashReporterUI(ex);
                reporter.ShowDialog();
            }
        }

        public void checkForUpdate()
        {
            getVersion();
            currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (currentVersion.CompareTo(newVersion) < 0)
            {
                if (System.Windows.Forms.DialogResult.Yes == System.Windows.Forms.MessageBox.Show("A new version of Clock alert is available do you want to download the new version?", "New Update available", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question))
                {
                    System.Diagnostics.Process.Start(url);
                }
            }
            else
                System.Windows.Forms.MessageBox.Show("This is already the latest version", "No new update", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
    }
}
