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


        public MainWindow()
        {
            InitializeComponent();
            User = XMLActions.Read("library.xml");
        }

        public object User { get; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNote addNote = new AddNote();
            addNote.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddCalendarNote addCalendarNote = new AddCalendarNote();
            addCalendarNote.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CalendarWindow showCalendar = new CalendarWindow();
            showCalendar.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
