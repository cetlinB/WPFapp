using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClassLibrary.Model
{
    class Note
    {
        private static int id_counter; 
        private int id;
        private int uid;
        private string Title;
        private string Content;
        public Note(int user_id , string Title, string Content)
        {
            this.id = id_counter;
            id_counter++;
            this.uid = user_id;
            this.Title = Title;
            this.Content = Content;
        }

        int getID()
        {
            return this.id;
        }

        int getUID()
        {
            return this.uid;
        }

        string getTitle()
        {
            return this.Title;
        }

        string getContent()
        {
            return this.Title;
        }

        void updateTitle(string Title)
        {
            this.Title = Title;
        }

        void updateContent(string Content)
        {
            this.Content = Content;
        }
    }
}
