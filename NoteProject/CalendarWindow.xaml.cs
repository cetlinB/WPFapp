using NoteClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
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
        private TextBlock[] days;
        private TextBlock[] daysOfTheMonth;
        private User user;
        private List<Note> notes;
        public CalendarWindow(User user)
        {
            daysOfTheMonth = new TextBlock[42];
            current = DateTime.Now;
            this.user = user;
            notes = user.GetAllNotesForMonthInYear(current.Year,current.Month);
            InitializeDaysTable();
            InitializeComponent();
            InitializeDaysOfWeek();
            InitializeWeeks();
            FillDayNames();
            FillDaysGrid();
            MonthName.FontFamily = new FontFamily("Curier New");
            MonthName.FontSize = 20;
            MonthName.FontWeight = FontWeights.Heavy;
            MonthName.Text = GetMonthName(current.Month) + " " + current.Year.ToString();
        }

        private void RewriteCalendar()
        {
            MonthName.Text = GetMonthName(current.Month) + " " + current.Year.ToString();
            notes = user.GetAllNotesForMonthInYear(current.Year, current.Month);
            UpdateDaysGrid();
            DaysOfTheMonth.UpdateLayout();
        }

        private void InitializeDaysTable()
        {
            month = new DataTable();
            for (int day = 0; day < 7; day++)
                month.Columns.Add(((DayOfWeek)day).ToString(),typeof(string));
        }

        private void InitializeDaysOfWeek()
        {
            DaysOfTheMonth.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
         }

        private void InitializeWeeks()
        {
            DaysOfTheMonth.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40, GridUnitType.Auto) });
            DaysOfTheMonth.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10, GridUnitType.Star) });
            DaysOfTheMonth.RowDefinitions.Add(new RowDefinition { Height = new GridLength(10, GridUnitType.Star) });
        }

        private void FillDayNames()
        {
            days = new TextBlock[7];
            for (int day = 1; day < 8; day++)
            {
            
                days[day%7] = new TextBlock();
                days[day % 7].Text = GetDayName((DayOfWeek)(day%7));
                days[day % 7].FontSize = 18;
                days[day % 7].FontWeight = FontWeights.Bold;
                Grid.SetColumn(days[day % 7], (day-1));
                Grid.SetRow(days[day % 7], 0);
                DaysOfTheMonth.Children.Add(days[day % 7]);
            }
        }
        
        private void FillDaysGrid()
        {
            List<DateTime> days = GetDates(current.Year, current.Month);
            int nextDay = 0;
            for (int i = daysOfTheMonth.Length - 1; i >= 0; i--)
            {
                daysOfTheMonth[i] = new TextBlock();
                daysOfTheMonth[i].FontSize = 18;
                daysOfTheMonth[i].FontWeight = FontWeights.Medium;
                daysOfTheMonth[i].AddHandler(MouseLeftButtonUpEvent, new RoutedEventHandler(myDelegate));
            }
            int firstDay;
            switch (GetFirstDayOfTheMonth(current.Year, current.Month))
            {
                case DayOfWeek.Sunday:
                    firstDay = 7;
                    break;
                case DayOfWeek.Saturday:
                    firstDay = 6;
                    break;
                case DayOfWeek.Friday:
                    firstDay = 5;
                    break;
                case DayOfWeek.Thursday:
                    firstDay = 4;
                    break;
                case DayOfWeek.Wednesday:
                    firstDay = 3;
                    break;
                case DayOfWeek.Tuesday:
                    firstDay = 2;
                    break;
                default:
                    firstDay = 1;
                    break;
            }
            for (int week = 0; week < 6; week++)
            {
                for (int day = 1; day < 8 ; day++)
                {
                    if (day == firstDay && nextDay == 0)
                        daysOfTheMonth[week * 7 + day - 1].Text = (++nextDay).ToString() + "\n Notatki:" + HowManyNotes(nextDay);
                    else if (nextDay > 0)
                    {
                        if (nextDay < days.Count)
                        {
                            daysOfTheMonth[week * 7 + day - 1].Text = (++nextDay).ToString() + "\n Notatki:" + HowManyNotes(nextDay);
                        }
                        else
                        {
                            daysOfTheMonth[week * 7 + day - 1].Text = "";
                        }
                    }
                    else
                    {
                        daysOfTheMonth[week * 7 + day - 1].Text = "";
                    }

                    Grid.SetColumn(daysOfTheMonth[week * 7 + day - 1], (day - 1));
                    Grid.SetRow(daysOfTheMonth[week * 7 + day - 1], week+1);
                    DaysOfTheMonth.Children.Add(daysOfTheMonth[week * 7 + day - 1]);
                }
            }
            
        }

        

        private void UpdateDaysGrid()
        {
            List<DateTime> days = GetDates(current.Year, current.Month);
            int nextDay = 0;
            int firstDay;
            switch (GetFirstDayOfTheMonth(current.Year, current.Month))
            {
                case DayOfWeek.Sunday:
                    firstDay = 7;
                    break;
                case DayOfWeek.Saturday:
                    firstDay = 6;
                    break;
                case DayOfWeek.Friday:
                    firstDay = 5;
                    break;
                case DayOfWeek.Thursday:
                    firstDay = 4;
                    break;
                case DayOfWeek.Wednesday:
                    firstDay = 3;
                    break;
                case DayOfWeek.Tuesday:
                    firstDay = 2;
                    break;
                default:
                    firstDay = 1;
                    break;
            }
            for (int week = 0; week < 6; week++)
            {
                for (int day = 1; day < 8; day++)
                {
                    if (day == firstDay && nextDay == 0)
                        daysOfTheMonth[week * 7 + day - 1].Text = (++nextDay).ToString() + "\n Notatki:" + HowManyNotes(nextDay);
                    else if (nextDay > 0)
                    {
                        if (nextDay < days.Count)
                        {
                            daysOfTheMonth[week * 7 + day - 1].Text = (++nextDay).ToString() + "\n Notatki:" + HowManyNotes(nextDay);
                        }
                        else
                        {
                            daysOfTheMonth[week * 7 + day - 1].Text = "";
                        }
                    }
                    else
                    {
                        daysOfTheMonth[week * 7 + day - 1].Text = "";
                    }
                }
            }

        }



        void myDelegate(object sender, RoutedEventArgs e)
        {
            if(((TextBlock)e.Source).Text != "")
            {
                List<Note> dailyNotes = new List<Note>();
                foreach(Note a in notes)
                {
                    if(a.Date1.Day.ToString() == ((TextBlock)e.Source).Text)
                    {
                        dailyNotes.Add(a);
                    }
                }
                DailyView day = new DailyView(((TextBlock)e.Source).Text + " " + GetMonthName(current.Month) +" " + current.Year.ToString(), dailyNotes);
                day.Show();
            }
        }
        

        private void NextMonth(object sender, RoutedEventArgs e)
        {
            current = current.AddMonths(1);
            RewriteCalendar();
        }

        private void PreviousMonth(object sender, RoutedEventArgs e)
        {
            current = current.AddMonths(-1);
            RewriteCalendar();
        }

        private void NextYear(object sender, RoutedEventArgs e)
        {
            current = current.AddYears(1);
            RewriteCalendar();
        }

        private void PreviousYear(object sender, RoutedEventArgs e)
        {
            current = current.AddYears(-1);
            RewriteCalendar();
        }

        private string GetMonthName(int i)
        {
            String temp = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
            return temp.ToUpperInvariant();
        }

        private string GetDayName(DayOfWeek day)
        {
            String temp = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(day);
            temp = temp[0].ToString().ToUpper() + temp.Substring(1);
            return temp;
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

        private void GotMouseClick()
        {
            for (int i = daysOfTheMonth.Length - 1; i >= 0; i--)
            {
                if (daysOfTheMonth[i].CaptureMouse())
                {
                    int day;
                    int.TryParse(daysOfTheMonth[i].Text,out day);
                    List<Note> dailyNotes = new List<Note>();
                    foreach(Note a in notes)
                    {
                        if(a.Date1.Day == day)
                            dailyNotes.Add(a);
                    }

                }
            }
        }

        private int HowManyNotes(int day)
        {
            int amount = 0;
            foreach (Note a in notes)
            {
                if (a.Date1.Day == day)
                    amount++;
            }
            return amount;
        }

    }
}
