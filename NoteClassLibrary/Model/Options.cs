using System.IO;
using System.Xml.Serialization;
using NoteClassLibrary.BaseClass;

namespace NoteClassLibrary.Model
{
    [XmlRoot(ElementName = "Options")]
    public class Options:NotificationObject
    {
        [XmlElement(ElementName = "Database")]
        private string filename = "";
        private static int counter = 0;
        Options single;

        public Options()
        {

        }
        public Options(string filename)
        {
            this.filename = filename;
        }

        private Options(bool IsDefault)
        {
            counter++;
            filename = "library.xml";
        }

        public Options getDefault()
        {
            if(counter == 0){
                counter++;
                single = new Options(true);
            }
            return single;
        }


        public static string RootOptions { get; } = "rootLibrary.xml";
        public string Filename { get => filename; set => filename = value; }
    }
}
