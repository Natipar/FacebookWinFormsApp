using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;

namespace BasicFacebookFeatures
{

    public class AppSettings
    {

        public Point RecentWindowLocation { get; set; }
        public Size RecentWindowSize { get; set; }
        public bool RememberUser { get; set; }
        public string RecentAccessToken { get; set; }

        public AppSettings()
        {

            RecentWindowLocation = new Point(20, 50);
            RecentWindowSize = new Size(800, 400);
            RememberUser = false;
            RecentAccessToken = "";

        }

        public void SaveToFile()
        {

            if (File.Exists("AppSettings.xml")) //inorder to create a new file every time without overwrite the existing one
            {

                File.Delete("AppSettings.xml");

            }

            using (Stream stream = new FileStream("AppSettings.xml", FileMode.Create))
            {

                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                serializer.Serialize(stream, this);

            }

        }

        public static AppSettings LoadFromFile()
        {

            AppSettings loadedFile = null;

            try
            {

                using (Stream stream = new FileStream("AppSettings.xml", FileMode.Open))
                {

                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    loadedFile = serializer.Deserialize(stream) as AppSettings;

                }

                return loadedFile;

            }
            catch
            {

                return loadedFile = new AppSettings();

            }

        }

    }

}
