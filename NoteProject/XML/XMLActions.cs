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
        public static NoteClassLibrary.Model.AddressBook Read(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NoteClassLibrary.Model.AddressBook));
            FileStream fs = new FileStream(filename, FileMode.Open);
            NoteClassLibrary.Model.AddressBook addressBook;
            addressBook = (NoteClassLibrary.Model.AddressBook)serializer.Deserialize(fs);
            return addressBook;
        }

        public static void Save(string filename, NoteClassLibrary.Model.AddressBook addressBook)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NoteClassLibrary.Model.AddressBook));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, addressBook);
            writer.Close();
        }
    }
}
