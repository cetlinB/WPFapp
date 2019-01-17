using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using NoteClassLibrary.BaseClass;

namespace NoteClassLibrary.Model
{
    public class UserNotes : NotificationObject
    {
        [XmlElement(ElementName = "Notes")]
        private ObservableCollection<Note> notes;

        public UserNotes()
        {
            Notes = new ObservableCollection<Note>();
        }

        public ObservableCollection<Note> Notes { get => notes; set => notes = value; }

        internal void AddNote(Note note)
        {
            Notes.Add(note);
        }

        internal void RemoveNote(Note note)
        {
            Notes.Remove(note);
        }

        internal void RemoveNote(int index)
        {
            try
            {
                Notes.RemoveAt(index);
            }
            catch
            {
                ;
            }
        }

        internal Note GetNote(int index)
        {
            Note temp;
            try
            {
                temp = notes.ElementAt<Note>(index);
            }
            catch
            {
                temp = null;
            }
            return temp;
        }

        internal void UpdateNote(int index, Note note)
        {
            try
            {
                Notes.RemoveAt(index);
                Notes.Insert(index, note);
            }
            catch
            {
                ;
            }
        }

        internal List<Note> GetAllNotesFromMonth(int year ,int month)
        {
            List<Note> list = new List<Note>();
            foreach(Note a in notes)
            {
                if(a.Date1.Year == year && a.Date1.Month == month)
                {
                    list.Add(a);
                }
            }
            return list;
        }
    }
}
