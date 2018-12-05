using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleProject.XML
{
    public static class XMLActions
    {
        public static SampleClassLibrary.Model.AddressBook Read(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SampleClassLibrary.Model.AddressBook));
            FileStream fs = new FileStream(filename, FileMode.Open);
            SampleClassLibrary.Model.AddressBook addressBook;
            addressBook = (SampleClassLibrary.Model.AddressBook)serializer.Deserialize(fs);
            return addressBook;
        }

        public static void Save(string filename, SampleClassLibrary.Model.AddressBook addressBook)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SampleClassLibrary.Model.AddressBook));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, addressBook);
            writer.Close();
        }
    }
}
