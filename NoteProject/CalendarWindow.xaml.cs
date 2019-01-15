using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// Logika interakcji dla klasy CalendarWindow.xaml
    /// </summary>
    public partial class CalendarWindow : Window
    {
        private DateTime current;
        private DataTable month;
        public CalendarWindow()
        {
            current = DateTime.Now;
            InitializeDaysTable();
            InitializeComponent();
            FillDaysGrid();
            MonthName.Text = GetMonthName(current.Month) + " " + current.Year.ToString();
        }

        private void InitializeDaysTable()
        {
            month = new DataTable();
            for (int day = 0; day < 7; day++)
                month.Columns.Add(((DayOfWeek)day).ToString(),typeof(string));
        }

        private void FillDaysGrid()
        {
            int dayOfMonth = 0;
            for(int week = 0; week < 5; week++)
            {
                DataRow temp = month.NewRow();
                for(int day = 0; day < 7; day++)
                {
                    if(week*7+day <= DateTime.DaysInMonth(current.Year,current.Month))
                        temp[day] = ++dayOfMonth;
                }
                month.Rows.Add(temp);
            }
            //TODO wstawienie tabeli do widoku

            DaysOfTheMonth.CurrentItem = month;

        }

        private void NextMonth(object sender, RoutedEventArgs e)
        {
            current = current.AddMonths(1);
            MonthName.Text = GetMonthName(current.Month) + " " + current.Year.ToString();
        }

        private void PreviousMonth(object sender, RoutedEventArgs e)
        {
            current = current.AddMonths(-1);
            MonthName.Text = GetMonthName(current.Month) + " " + current.Year.ToString();
        }

        private void NextYear(object sender, RoutedEventArgs e)
        {
            current = current.AddYears(1);
            MonthName.Text = GetMonthName(current.Month) + " " + current.Year.ToString();
        }

        private void PreviousYear(object sender, RoutedEventArgs e)
        {
            current = current.AddYears(-1);
            MonthName.Text = GetMonthName(current.Month) + " " + current.Year.ToString();
        }

        private string GetMonthName(int i)
        {
            String temp = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
            return temp.ToUpperInvariant();
        }
        
        private DayOfWeek GetFirstDayOfTheMonth(int year, int month)
        {
            return new DateTime(year, month, 1).DayOfWeek;
        }

        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                             .Select(day => new DateTime(year, month, day))
                             .ToList();
        }

    }
}
