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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoteProject
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User thisUser = null;
        List<Note> mainNotes = new List<Note>();
        private int firstNoteOnPage;
        Note currentNote = new Note("","", new DateTime?());

        public MainWindow()
        {
            firstNoteOnPage = 0;
            InitializeComponent();
            thisUser = XMLActions.Read("library.xml");
            int i = 0;
            do mainNotes.Add(thisUser.GetNote(i++)); while (mainNotes.Last() != null);
            ReweindNotes();
        }

        private void ReweindNotes()
        {
            try
            {
                Note0.Text = mainNotes.ElementAt(firstNoteOnPage).Title1;
            }
            catch
            {
                Note0.Text = "";
            }
            try
            {
                Note1.Text = mainNotes.ElementAt(firstNoteOnPage + 1).Title1;
            }
            catch
            {
                Note1.Text = "";
            }
            try
            {
                Note2.Text = mainNotes.ElementAt(firstNoteOnPage + 2).Title1;
            }
            catch
            {
                Note2.Text = "";
            }
            try
            {
                Note3.Text = mainNotes.ElementAt(firstNoteOnPage + 3).Title1;
            }
            catch
            {
                Note3.Text = "";
            }
        }

        public object User { get; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNote addNote = new AddNote();
            addNote.Title = "Add new note.";
            addNote.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddNote addNote = new AddNote();
            addNote.Title = "Edit note.";
            addNote.newTitle.Text = NoteTitle.Text;
            addNote.newContent.Text = NoteContent.Text;
            addNote.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CalendarWindow showCalendar = new CalendarWindow();
            showCalendar.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            currentNote = thisUser.GetNote(firstNoteOnPage + 3);
            NoteTitle.Text = Note3.Text;
            NoteContent.Text = thisUser.GetNote(firstNoteOnPage + 3).Content1;
        }

        private void Grid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            currentNote = thisUser.GetNote(firstNoteOnPage + 2);
            NoteTitle.Text = Note2.Text;
            NoteContent.Text = thisUser.GetNote(firstNoteOnPage + 2).Content1;
        }

        private void Grid_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            currentNote = thisUser.GetNote(firstNoteOnPage + 1);
            NoteTitle.Text = Note1.Text;
            NoteContent.Text = thisUser.GetNote(firstNoteOnPage + 1).Content1;
        }

        private void Grid_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            currentNote = thisUser.GetNote(firstNoteOnPage);
            NoteTitle.Text = Note0.Text;
            NoteContent.Text = thisUser.GetNote(firstNoteOnPage + 0).Content1;
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if(e.Delta > 0)
            {
                if (firstNoteOnPage <= 0)
                    return;
                firstNoteOnPage--;
                ReweindNotes();
            }
            else if (e.Delta < 0)
            {
                firstNoteOnPage++;
                try
                {
                    Note3.Text = mainNotes.ElementAt(firstNoteOnPage + 3).Title1;
                }
                catch
                {
                    firstNoteOnPage--;
                }
                try
                {
                    Note2.Text = mainNotes.ElementAt(firstNoteOnPage + 2).Title1;
                }
                catch
                {
                    firstNoteOnPage--;
                }
                try
                {
                    Note1.Text = mainNotes.ElementAt(firstNoteOnPage + 1).Title1;
                }
                catch
                {
                    firstNoteOnPage--;
                }
                try
                {
                    Note0.Text = mainNotes.ElementAt(firstNoteOnPage).Title1;
                }
                catch
                {
                    firstNoteOnPage--;
                }
            }
        }
    }
}
