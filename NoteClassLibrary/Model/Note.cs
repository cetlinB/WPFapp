using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteClassLibrary.Model
{
    public class Note
    {
        [XmlElement(ElementName = "Title")]
        private string Title;
        [XmlElement(ElementName = "Content")]
        private string Content;

        public string Title1 { get => Title; set => Title = value; }
        public string Content1 { get => Content; set => Content = value; }

        internal Note( string Title, string Content)
        {
            this.Title1 = Title;
            this.Content = Content;
        }



    }
}
