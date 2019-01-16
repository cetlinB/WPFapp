using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteProject
{
    public static class XMLActions
    {
        public static NoteClassLibrary.Model.User Read(string filename)
        {
            if (!File.Exists(filename))
            {
                File.WriteAllText(filename,"");
            }
            XmlSerializer serializer = new XmlSerializer(typeof(NoteClassLibrary.Model.User));
            FileStream fs = new FileStream(filename, FileMode.Open);
            NoteClassLibrary.Model.User user;
            try
            {
                user = (NoteClassLibrary.Model.User)serializer.Deserialize(fs);
            }
            catch
            {
                user = new NoteClassLibrary.Model.User();
            }
            fs.Close();
            return user; 
        }

        public static void Save(string filename, NoteClassLibrary.Model.User user)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NoteClassLibrary.Model.User));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, user);
            writer.Close();
        }
    }
}
