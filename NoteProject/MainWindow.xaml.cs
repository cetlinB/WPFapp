using NoteClassLibrary.Model;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace NoteProject
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User thisUser = null;
        private int firstNoteOnPage;
        private int currentNote;
        private NoteClassLibrary.Model.Options options;
        private DateTime timeOffset = DateTime.Now;

        public MainWindow()
        {
            this.options = XMLOptions.Read(NoteClassLibrary.Model.Options.RootOptions);
            currentNote = -1;
            firstNoteOnPage = 0;
            InitializeComponent();
            NoteContent.Text = "";
            NoteTitle.Text = "";
            NoteDate.Text = "";
            thisUser = XMLActions.Read(options.Filename);
            RewindNotes();
        }

        private void RewindNotes()
        {
            if (thisUser.GetNote(firstNoteOnPage) != null)
            {
                Note0.Text = thisUser.GetNote(firstNoteOnPage).Title1;
                Date0.Text = thisUser.GetNote(firstNoteOnPage).Date1.ToLongDateString();
            }
            else
            {
                Note0.Text = "";
                Date0.Text = "";
            }
            if (thisUser.GetNote(firstNoteOnPage + 1) != null)
            {
                Note1.Text = thisUser.GetNote(firstNoteOnPage + 1).Title1;
                Date1.Text = thisUser.GetNote(firstNoteOnPage + 1).Date1.ToLongDateString();
            }
            else
            {
                Note1.Text = "";
                Date1.Text = "";
            }
            if (thisUser.GetNote(firstNoteOnPage + 2) != null)
            {
                Note2.Text = thisUser.GetNote(firstNoteOnPage + 2).Title1;
                Date2.Text = thisUser.GetNote(firstNoteOnPage + 2).Date1.ToLongDateString();
            }
            else
            {
                Note2.Text = "";
                Date2.Text = "";
            }
            if (thisUser.GetNote(firstNoteOnPage + 3) != null)
            {
                Note3.Text = thisUser.GetNote(firstNoteOnPage + 3).Title1;
                Date3.Text = thisUser.GetNote(firstNoteOnPage + 3).Date1.ToLongDateString();
            }
            else
            {
                Note3.Text = "";
                Date3.Text = "";
            }
        }

        public object User { get; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNote addNote = new AddNote(thisUser,options.Filename);
            addNote.Title = "Add new note.";
            addNote.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                AddNote addNote = new AddNote(thisUser, currentNote, options.Filename);
                addNote.Title = "Edit note.";
                addNote.newTitle.Text = NoteTitle.Text;
                addNote.newContent.Text = NoteContent.Text;
                addNote.Show();
            }
            catch
            {
                ;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CalendarWindow showCalendar = new CalendarWindow(this.thisUser);
            showCalendar.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (currentNote > -1)
            {
                NoteContent.Text = "";
                NoteTitle.Text = "";
                NoteDate.Text = "";
                thisUser.RemoveNote(currentNote);
                XMLActions.Save(options.Filename, this.thisUser);
                currentNote = -1;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //ReloadPage();
            try
            {
                NoteDate.Text = thisUser.GetNote(firstNoteOnPage + 3).Date1.ToString();
                NoteTitle.Text = Note3.Text;
                NoteContent.Text = thisUser.GetNote(firstNoteOnPage + 3).Content1;
                currentNote = firstNoteOnPage + 3;
            }
            catch
            {
                currentNote = -1;
                NoteDate.Text = "";
                NoteTitle.Text = "";
                NoteContent.Text = "";
            }
        }

        private void Grid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            //ReloadPage();
            try
            {
                NoteDate.Text = thisUser.GetNote(firstNoteOnPage + 2).Date1.ToString();
                NoteTitle.Text = Note2.Text;
                NoteContent.Text = thisUser.GetNote(firstNoteOnPage + 2).Content1;
                currentNote = firstNoteOnPage + 2;
            }
            catch
            {
                currentNote = -1;
                NoteDate.Text = "";
                NoteTitle.Text = "";
                NoteContent.Text = "";
            }
        }

        private void Grid_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            //ReloadPage();
            try
            {
                NoteDate.Text = thisUser.GetNote(firstNoteOnPage + 1).Date1.ToString();
                NoteTitle.Text = Note1.Text;
                NoteContent.Text = thisUser.GetNote(firstNoteOnPage + 1).Content1;
                currentNote = firstNoteOnPage + 1;
            }
            catch
            {
                currentNote = -1;
                NoteDate.Text = "";
                NoteTitle.Text = "";
                NoteContent.Text = "";
            }
        }

        private void Grid_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            //ReloadPage();
            try
            {
                NoteDate.Text = thisUser.GetNote(firstNoteOnPage).Date1.ToString();
                NoteTitle.Text = Note0.Text;
                NoteContent.Text = thisUser.GetNote(firstNoteOnPage).Content1;
                currentNote = firstNoteOnPage;
            }
            catch
            {
                currentNote = -1;
                NoteDate.Text = "";
                NoteTitle.Text = "";
                NoteContent.Text = "";
            }
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (firstNoteOnPage <= 0)
                {
                    ReloadPage();
                    RewindNotes();
                    return;
                }
                else
                {
                    firstNoteOnPage--;
                    RewindNotes();
                }
            }
            else if (e.Delta < 0)
            {
                firstNoteOnPage++;
                if(thisUser.GetNote(firstNoteOnPage + 3)!=null)
                {
                    Note3.Text = thisUser.GetNote(firstNoteOnPage + 3).Title1;
                    Date3.Text = thisUser.GetNote(firstNoteOnPage + 3).Date1.ToLongDateString();
                }
                else
                {
                    ReloadPage();
                    if (firstNoteOnPage <= 0)
                        return;
                    firstNoteOnPage--;
                    RewindNotes();
                }
                if (thisUser.GetNote(firstNoteOnPage + 2) != null)
                {
                    Note2.Text = thisUser.GetNote(firstNoteOnPage + 2).Title1;
                    Date2.Text = thisUser.GetNote(firstNoteOnPage + 2).Date1.ToLongDateString();
                }
                else
                {
                    if (firstNoteOnPage <= 0)
                        return;
                    firstNoteOnPage--;
                }
                if (thisUser.GetNote(firstNoteOnPage + 1) != null)
                {
                    Note1.Text = thisUser.GetNote(firstNoteOnPage + 1).Title1;
                    Date1.Text = thisUser.GetNote(firstNoteOnPage + 1).Date1.ToLongDateString();
                }
                else
                {
                    if (firstNoteOnPage <= 0)
                        return;
                    firstNoteOnPage--;
                }
                if (thisUser.GetNote(firstNoteOnPage + 3) != null)
                {
                    Note0.Text = thisUser.GetNote(firstNoteOnPage).Title1;
                    Date0.Text = thisUser.GetNote(firstNoteOnPage).Date1.ToLongDateString();
                }
                else
                {
                    if (firstNoteOnPage <= 0)
                        return;
                    firstNoteOnPage--;
                }
            }
        }

        private void ReloadPage()
        {
            if (timeOffset.AddTicks(300000) < DateTime.Now)
            {
                try
                {
                    thisUser = XMLActions.Read(options.Filename);
                    timeOffset = DateTime.Now;
                    this.options = XMLOptions.Read(NoteClassLibrary.Model.Options.RootOptions);
                }
                catch
                {
                    ;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Options options = new Options(this.options);
            options.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XMLActions.Save(options.Filename, thisUser);
        }
    }
}
