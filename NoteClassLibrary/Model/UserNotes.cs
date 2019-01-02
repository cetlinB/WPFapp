using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleClassLibrary.BaseClass;

namespace SampleClassLibrary.Model
{
    class UserNotes : NotificationObject
    {
        private Note[] notes;
        private int amount;

        UserNotes()
        {
            notes = new Note[5];
            amount = 0;
        }

        internal void addNote(Note note)
        {
            if( this.amount >= this.notes.Length)
            {
                resizeNotes();
            }

            notes[amount] = note;
            amount++;
        }

        internal void removeNote(int index)
        {
            if (index == amount) {
                this.notes[index] = null;
                this.amount--;
            }
            else if (index > amount)
            {
                Console.Write("Index out of range.");
            }
            else if( index < amount)
            {
                while(index < amount)
                {
                    this.notes[index] = this.notes[index++];
                }
                this.amount--;
            }
        }

        internal void resizeNotes()
        {
            Note[] temp = new Note[this.notes.Length * 2];
            Array.Copy(this.notes, temp, amount);
            this.notes = temp;
        }
    }
}
