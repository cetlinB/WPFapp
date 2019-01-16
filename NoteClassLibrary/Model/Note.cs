using System;
using System.Xml.Serialization;
using NoteClassLibrary.BaseClass;

namespace NoteClassLibrary.Model
{
    public class Note:NotificationObject
    {
        [XmlElement(ElementName = "Title")]
        private string Title;
        [XmlElement(ElementName = "Content")]
        private string Content;
        [XmlElement(ElementName = "Date")]
        private DateTime Date;

        public string Title1 { get => Title; set => Title = value; }
        public string Content1 { get => Content; set => Content = value; }
        public DateTime Date1 { get => Date; set => Date = value; }

        private Note( string Title, string Content)
        {
            this.Title1 = Title;
            this.Content = Content;
        }

        public Note()
        {
            this.Title1 = "";
            this.Content1 = "";
        }

        public Note(string Title, string Content, DateTime selectedDate)
        {
            this.Title1 = Title;
            this.Content1 = Content;
            this.Date = selectedDate;
        }

    }
}
