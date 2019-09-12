using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq ;

namespace gui_involved
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            involved i = new involved();
            i.id = id.Text;
            i.location = location.Text;
            i.image = image.Text;
            i.age = age.Text;

            if (!File.Exists("involved.xml"))
            {

                XmlWriter writer = XmlWriter.Create("involved.xml");
                writer.WriteStartDocument();
                writer.WriteStartElement("Table");
                writer.WriteAttributeString("name", "involvedtable");

                writer.WriteStartElement("involved");

                writer.WriteStartElement("involvedID");
                writer.WriteString(i.id);
                writer.WriteEndElement();

                writer.WriteStartElement("location");
                writer.WriteString(i.location);
                writer.WriteEndElement();

                writer.WriteStartElement("image");
                writer.WriteString(i.image);
                writer.WriteEndElement();

                writer.WriteStartElement("age");
                writer.WriteString(i.age);
                writer.WriteEndElement();



                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                XmlElement involved = doc.CreateElement("involved");
                XmlElement node = doc.CreateElement("involvedID");
                node.InnerText = i.id;
                involved.AppendChild(node);
                node = doc.CreateElement("location");
                node.InnerText = i.location;
                involved.AppendChild(node);
                node = doc.CreateElement("image");
                node.InnerText = i.image;
                involved.AppendChild(node);
                node = doc.CreateElement("age");
                node.InnerText = i.age;
                involved.AppendChild(node);
                doc.Load("involved.xml");
                XmlElement root = doc.DocumentElement;
                root.AppendChild(involved);
                doc.Save("involved.xml");

            }
            MessageBox.Show("Successfully Added !!!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader("involved.xml");
            XmlNodeType type;
            while (reader.Read())
            {
                type = reader.NodeType;
                if (type == XmlNodeType.Element)
                {
                    if (reader.Name == "involvedID")
                    {
                        reader.Read();
                        listBox1.Items.Add(reader.Value);
                    }

                    if (reader.Name == "location")
                    {
                        reader.Read();
                        listBox1.Items.Add(reader.Value);
                    }


                    if (reader.Name == "image")
                    {
                        reader.Read();
                        listBox1.Items.Add(reader.Value);
                    }

                    if (reader.Name == "age")
                    {
                        reader.Read();
                        listBox1.Items.Add(reader.Value);
                        listBox1.Items.Add("*********");
                    }




                }



            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {



            string id = txt.Text;
            XmlDocument doc = new XmlDocument();
            doc.Load("involved.xml");
            XmlNode player = doc.SelectNodes("/Table/involved").OfType<XmlNode>().FirstOrDefault(n => n["involvedID"].InnerText == id);


                player["location"].InnerText = "avdo";

            

            doc.Save("involved.xml");
            
          
        }

        private void txt_TextChanged(object sender, System.EventArgs e)
        {

        }
    }

}
