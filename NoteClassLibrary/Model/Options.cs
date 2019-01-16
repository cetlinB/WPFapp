using System.IO;
using System.Xml.Serialization;
using NoteClassLibrary.BaseClass;

namespace NoteClassLibrary.Model
{
    [XmlRoot(ElementName = "Options")]
    public class Options:NotificationObject
    {
        private static string rootOptions = "rootLibrary.xml";
        [XmlElement(ElementName = "Database")]
        private string filename;
        public Options()
        {
            if (!File.Exists(RootOptions))
            {
                File.WriteAllText(RootOptions,"");
            }
            Filename = "library.xml";
        }

        public static string RootOptions { get => rootOptions; }
        public string Filename { get => filename; set => filename = value; }
    }
}
