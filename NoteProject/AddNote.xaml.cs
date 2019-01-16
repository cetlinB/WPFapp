using NoteClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoteProject
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class AddNote : Window
    {
        private string filename;
        User user = null;
        private int current;
        public AddNote(User user, string filename)
        {
            this.filename = filename;
            this.user = user;
            InitializeComponent();
        }

        public AddNote(User user, int currentID, string filename)
        {
            if (currentID > -1)
            {
                this.filename = filename;
                this.user = user;
                InitializeComponent();
                newTitle.Text = user.GetNote(currentID).Title1;
                newContent.Text = user.GetNote(currentID).Content1;
                newDate.SelectedDate = user.GetNote(currentID).Date1;
                current = currentID;
            }
            else throw new IndexOutOfRangeException();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime value;
            try
            {
                value = newDate.SelectedDate.Value;
            }
            catch
            {
                value = DateTime.Now;
            }
            if (Title == "Add new note.")
            {
                user.AddNote(new Note(newTitle.Text, newContent.Text, value));
            } else
            {
                user.UpdateNote(current, new Note(newTitle.Text, newContent.Text, value));
            }
            XMLActions.Save(filename, user);
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
