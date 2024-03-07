using Newtonsoft.Json;
using SymphonyOrchestra.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SymphonyOrchestra
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Type> dictionary = new Dictionary<string, Type>
        {
            { "Инструменты", typeof(Instrument) },
            { "Музыканты", typeof(Musician) },
            { "Симфонии", typeof(Symphony) }
        };

        private List<object> allObjects = new List<object>();

        public Form1()
        {
            InitializeComponent();
            InitializeTreeView();
        }

        private void InitializeTreeView()
        {
            treeView.Nodes.Clear();

            TreeNode mainNode = new TreeNode("Симофонический оркестр");
            treeView.Nodes.Add(mainNode);

            foreach (var kvp in dictionary)
            {
                TreeNode keyNode = new TreeNode(kvp.Key);
                mainNode.Nodes.Add(keyNode);

                Type type = kvp.Value;
                foreach (var property in type.GetProperties())
                {
                    TreeNode propertyNode = new TreeNode(property.Name);
                    keyNode.Nodes.Add(propertyNode);
                }
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if (!(selectedNode.Parent == null) && selectedNode.Parent.Parent == null)
            {
                string key = selectedNode.Text;
                string propertyName = selectedNode.Text;
                if (dictionary.TryGetValue(key, out Type objectType))
                {
                    new Form2(key, objectType.Name.ToLower()).ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeserializeFiles();
            DisplayAllObjects();
        }

        private void DeserializeFiles()
        {
            allObjects.Clear();

            foreach (var kvp in dictionary)
            {
                string key = kvp.Key;
                string xmlFilePath = Path.Combine("files", $"{dictionary[key].Name.ToLower()}.xml");

                if (File.Exists(xmlFilePath))
                {
                    DeserializeXml(xmlFilePath, kvp.Value);
                }
            }
        }

        private void DeserializeXml(string filePath, Type objectType)
        {
            XmlSerializer serializer = new XmlSerializer(objectType);
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                object item = serializer.Deserialize(fs);
                allObjects.Add(item);
            }
        }

        private void DisplayAllObjects()
        {
            dataGridView.Rows.Clear();

            foreach (var obj in allObjects)
            {
                Type objectType = obj.GetType();
                var myKey = dictionary.FirstOrDefault(x => x.Value == objectType).Key;
                dataGridView.Rows.Add($"{myKey}: ");

                foreach (var prop in objectType.GetProperties())
                {
                    dataGridView.Rows.Add($"    {prop.Name}", prop.GetValue(obj));
                }
            }
        }
    }
}
