using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NoteClassLibrary.BaseClass;

namespace NoteClassLibrary.Model
{
    public class UserNotes : NotificationObject
    {
        [XmlElement(ElementName = "Notes")]
        private ObservableCollection<Note> notes;
        private int amount;

        public UserNotes()
        {
            Notes = new ObservableCollection<Note>();
            amount = 0;
        }

        public ObservableCollection<Note> Notes { get => notes; set => notes = value; }

        internal void AddNote(Note note)
        {
            Notes.Add(note);
            amount++;
        }

        internal void RemoveNote(Note note)
        {
            if (amount > 0)
            {
                Notes.Remove(note);
                amount--;
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
    }
}
