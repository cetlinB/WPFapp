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
    /// Logika interakcji dla klasy DailyView.xaml
    /// </summary>
    public partial class DailyView : Window
    {
        private List<Note> dailyNotes;
        public DailyView(string dateName, List<Note> notes)
        {
            this.dailyNotes = notes;
            InitializeComponent();
            DailyWindow.Title = dateName;
        }

        private void FillElements()
        {
            title.Text = "";
            note.Text = "";
            try
            {
                Title0.Text = dailyNotes.ElementAt(0).Title1;
            }
            catch
            {
                Title0.Text = "";
            }
            try
            {
                Title1.Text = dailyNotes.ElementAt(1).Title1;
            }
            catch
            {
                Title1.Text = "";
            }
            try
            {
                Title2.Text = dailyNotes.ElementAt(2).Title1;
            }
            catch
            {
                Title2.Text = "";
            }
            try
            {
                Title3.Text = dailyNotes.ElementAt(3).Title1;
            }
            catch
            {
                Title3.Text = "";
            }
            try
            {
                Title4.Text = dailyNotes.ElementAt(4).Title1;
            }
            catch
            {
                Title4.Text = "";
            }
            try
            {
                Title5.Text = dailyNotes.ElementAt(5).Title1;
            }
            catch
            {
                Title5.Text = "";
            }

        }

        private void Title0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                title.Text = dailyNotes.ElementAt(0).Title1;
            }
            catch
            {
                title.Text = "";
            }
        }

        private void Title1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                title.Text = dailyNotes.ElementAt(1).Title1;
            }
            catch
            {
                title.Text = "";
            }
        }

        private void Title2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                title.Text = dailyNotes.ElementAt(2).Title1;
            }
            catch
            {
                title.Text = "";
            }
        }

        private void Title3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                title.Text = dailyNotes.ElementAt(3).Title1;
            }
            catch
            {
                title.Text = "";
            }
        }

        private void Title4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                title.Text = dailyNotes.ElementAt(4).Title1;
            }
            catch
            {
                title.Text = "";
            }
        }

        private void Title5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                title.Text = dailyNotes.ElementAt(5).Title1;
            }
            catch
            {
                title.Text = "";
            }
        }
    }
}
