using System.Collections.Generic;
using System.Xml.Serialization;
using NoteClassLibrary.BaseClass;

namespace NoteClassLibrary.Model
{
    [XmlRoot(ElementName = "User")]
    public class User : NotificationObject
    {
        private static int id = 1;
        [XmlElement(ElementName = "UserNotes")]
        private UserNotes notes;
        [XmlElement(ElementName = "UID")]
        private readonly int user_id;

        public UserNotes Notes { get => notes; set => notes = value; }

        public int User_id => user_id;

        public User()
        {
            user_id = id++;
            Notes = new UserNotes();
        }

        public void AddNote(Note note)
        {
            Notes.AddNote(note);
        }

        public Note GetNote(int index)
        {
            return this.Notes.GetNote(index);
        }

        public void UpdateNote(int index, Note note)
        {
            this.notes.UpdateNote(index, note);
        }

        public List<Note> GetAllNotesForMonthInYear(int year, int month)
        {
            return notes.GetAllNotesFromMonth(year, month);
        }

        public int getID()
        {
            return User_id;
        }

        public void RemoveNote(int currentNote)
        {
            notes.RemoveNote(currentNote);
        }
    }
}
