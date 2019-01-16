using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteProject
{
    public static class XMLOptions
    {
        public static NoteClassLibrary.Model.Options Read(string filename)
        {
            NoteClassLibrary.Model.Options options;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(NoteClassLibrary.Model.User));
                FileStream fs = new FileStream(filename, FileMode.Open);
                options = (NoteClassLibrary.Model.Options)serializer.Deserialize(fs);
                fs.Close();
            }
            catch
            {
                options = new NoteClassLibrary.Model.Options();
            }
            
            return options;
        }

        public static void Save(string filename, NoteClassLibrary.Model.Options options)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NoteClassLibrary.Model.Options));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, options);
            writer.Close();
        }
    }
}
