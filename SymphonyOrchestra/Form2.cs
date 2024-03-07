using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SymphonyOrchestra.Model;

namespace SymphonyOrchestra
{
    public partial class Form2 : Form
    {
        private string key;

        public Form2(string name, string key)
        {
            InitializeComponent();
            this.key = key;

            DeserializeFiles(key);
            this.Text = name;
        }

        private void DeserializeFiles(string key)
        {
            string xmlFilePath = Path.Combine("files", $"{key}.xml");
            string jsonFilePath = Path.Combine("files", $"{key}.json");

            if (File.Exists(xmlFilePath))
            {
                if (key == "instrument")
                    DeserializeXml<Instrument>(xmlFilePath);
                else if (key == "musician")
                    DeserializeXml<Musician>(xmlFilePath);
                else
                    DeserializeXml<Symphony>(xmlFilePath);

            }

            if (File.Exists(jsonFilePath))
            {
                if (key == "instrument")
                    DeserializeJson<Instrument>(jsonFilePath);
                else if (key == "musician")
                    DeserializeJson<Musician>(jsonFilePath);
                else
                    DeserializeJson<Symphony>(jsonFilePath);
            }
        }

        private void DeserializeXml<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                T item = (T)serializer.Deserialize(fs);
                DisplayProperties(item);
            }
        }

        private void DeserializeJson<T>(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            T item = JsonConvert.DeserializeObject<T>(jsonContent);
            DisplayProperties(item);
        }

        private void DisplayProperties<T>(T item)
        {
            dataGridViewXml.Rows.Clear();
            dataGridViewJson.Rows.Clear();

            foreach (var prop in typeof(T).GetProperties())
            {
                dataGridViewXml.Rows.Add(prop.Name, prop.GetValue(item));
                dataGridViewJson.Rows.Add(prop.Name, prop.GetValue(item));
            }
        }
    }
}
