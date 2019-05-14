using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WindowsApp.Experiment
{
    public partial class Timetable : Window
    {
        private DateTime _fromDate;
        private DateTime _toDate;
        private const string SoursFile = "c:\\WindowsAppDir\\FirstTimetable.txt";
        public Timetable()
        {
            InitializeComponent();
            DateTime dateTime = DateTime.Now;
            TextBlockData.Text = dateTime.DayOfWeek.ToString();
            while (dateTime.DayOfWeek != DayOfWeek.Monday)
            {
                dateTime = dateTime.AddDays(-1);
            }
            _fromDate = dateTime;
            _toDate = dateTime.AddDays(6);
            TextBlockData.Text = $"{_fromDate:dd MMMM} - {_toDate:dd MMMM yyyy}";
            TextBlockData.FontSize = 20;
            GenericTimetable();
        }

        private void BackToThePast_OnClick(object sender, RoutedEventArgs e)
        {
            _fromDate = _fromDate.AddDays(-7);
            _toDate = _toDate.AddDays(-7);
            TextBlockData.Text = $"{_fromDate:dd MMMM} - {_toDate:dd MMMM yyyy}";
            GenericTimetable();
        }
        private void ForwardToTheFuture_OnClick(object sender, RoutedEventArgs e)
        {
            _fromDate = _fromDate.AddDays(7);
            _toDate = _toDate.AddDays(7);
            TextBlockData.Text = $"{_fromDate:dd MMMM} - {_toDate:dd MMMM yyyy}";
            GenericTimetable();
        }

        private void GenericTimetable()
        {
            TextBlockMonday.Text = GetTextData(0);
            TextBlockTuesday.Text = GetTextData(1);
            TextBlockWednesday.Text = GetTextData(2);
            TextBlockThursday.Text = GetTextData(3);
            TextBlockFriday.Text = GetTextData(4);
            TextBlockSaturday.Text = GetTextData(5);
            TextBlockSunday.Text = GetTextData(6);
            
            StreamReader streamReader = new StreamReader(SoursFile);
            Events events = new Events(streamReader.ReadLine());
            streamReader.Close();
            ListBoxMonday.Items.Clear();
            ListBoxTuesday.Items.Clear();
            ListBoxWednesday.Items.Clear();
            ListBoxThursday.Items.Clear();
            ListBoxFriday.Items.Clear();
            ListBoxSaturday.Items.Clear();
            ListBoxSunday.Items.Clear();
            ArrangementOfEventsByDates(events);
        }

        private string GetTextData(int day)
        {
            return $"{_fromDate.AddDays(day).DayOfWeek}\n{_fromDate.AddDays(day):dd MMMM}";
        }

        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItemAddEvent_OnClick(object sender, RoutedEventArgs e)
        {
            NewWindow newWindow = new NewWindow();
            newWindow.Show();
        }
        
        private void ArrangementOfEventsByDates(Events events)
        {
            if (events.DateTimeEvent.Equals(Convert.ToDateTime(TextBlockMonday.Text)))
            {
                ListBoxMonday.Items.Add(events.NameEvent);
            }
            if (events.DateTimeEvent.Equals(Convert.ToDateTime(TextBlockTuesday.Text)))
            {
                ListBoxTuesday.Items.Add(events.NameEvent);
            }
            if (events.DateTimeEvent.Equals(Convert.ToDateTime(TextBlockWednesday.Text)))
            {
                ListBoxWednesday.Items.Add(events.NameEvent);
            }
            if (events.DateTimeEvent.Equals(Convert.ToDateTime(TextBlockThursday.Text)))
            {
                ListBoxThursday.Items.Add(events.NameEvent);
            }
            if (events.DateTimeEvent.Equals(Convert.ToDateTime(TextBlockFriday.Text)))
            {
                ListBoxFriday.Items.Add(events.NameEvent);
            }
            if (events.DateTimeEvent.Equals(Convert.ToDateTime(TextBlockSaturday.Text)))
            {
                ListBoxSaturday.Items.Add(events.NameEvent);
            }
            if (events.DateTimeEvent.Equals(Convert.ToDateTime(TextBlockSunday.Text)))
            {
                ListBoxSunday.Items.Add(events.NameEvent);
            }
        }
    }
}
