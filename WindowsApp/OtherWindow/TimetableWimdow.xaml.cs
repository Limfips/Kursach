using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WindowsApp.Logic;

namespace WindowsApp.OtherWindow
{
    public partial class TimetableWindow : Window
    {
        private static string _nameFile;
        private List<TextBlock> _daysWeek = new List<TextBlock>();
        private List<DateTime> _dateTimesWeek = new List<DateTime>();

        private static readonly WorkFile WorkFile = new WorkFile();

        //private readonly SchoolTimeTable _schoolTimeTable;
        public TimetableWindow(string nameFile)
        {
            InitializeComponent();
            _nameFile = nameFile;
            //_schoolTimeTable = WorkFile.GetDataUser(_nameFile);
            GenericTimetable();

            //ToDo Закончить работу с последовательной генирацией
            //ToDo CardView в календарь

        }

        /// <summary>
        /// Отрисовка таблицы, базовое
        /// </summary>
        private void GenericTimetable()
        {
            for (int i = 1, k = 0; k < 24; i += 2, k++)
            {
                var textBlock = new TextBlock();
                textBlock.Text = k < 10 ? $"0{k}:00" : $"{k}:00";
                MainGrid.Children.Add(textBlock);
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.FontSize = 16;
                textBlock.Margin = new Thickness(3);
                Grid.SetColumn(textBlock, 1);
                Grid.SetRow(textBlock, i + 1);
            }

            DateTime dateTime = DateTime.Now;
            while (dateTime.DayOfWeek != DayOfWeek.Monday)
            {
                dateTime = dateTime.AddDays(-1);
            }

            for (int i = 3, k = 0; k < 8; i += 2, k++)
            {
                _dateTimesWeek.Add(dateTime);
                TextBlock textBlock = new TextBlock {Text = dateTime.DayOfWeek + "\n" + dateTime.Day};
                MainGrid.Children.Add(textBlock);
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                textBlock.FontSize = 16;
                textBlock.Margin = new Thickness(3);
                Grid.SetColumn(textBlock, i);
                Grid.SetRow(textBlock, 0);
                _daysWeek.Add(textBlock);
                dateTime = dateTime.AddDays(1);
            }
        }

        /// <summary>
        /// При закрытии приложения, сохраняемся
        /// </summary>
        private void TimetableWindow_OnClosing(object sender, CancelEventArgs e)
        {
            //WorkFile.SaveDate(_schoolTimeTable.Lessons,_nameFile);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }


        //ToDo Подредачить
        /// <summary>
        /// Создание нового Event
        /// </summary>
//        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                var getLesson = new GetNewTimetableWindow();
//                getLesson.Button.Click += (senderSlave, eSlave) =>
//                {
//                    Lesson lesson = new Lesson(getLesson.NameTextBox.Text, 
//                        Convert.ToDateTime(getLesson.StartDatePicker.ToString()),
//                        Convert.ToDateTime(getLesson.EndDatePicker.ToString()),
//                        (Event.RepeatCategories)Enum.Parse(typeof(Event.RepeatCategories),
//                            getLesson.RepeatComboBox.SelectedItem.ToString()),
//                        getLesson.DetailsTextBox.Text);
//                    
//                    lesson.StartEvent = lesson.StartEvent.AddHours(
//                        Convert.ToDouble(getLesson.StartTimeHourTextBox.Text));
//                    lesson.StartEvent = lesson.StartEvent.AddMinutes(
//                        Convert.ToDouble(getLesson.StartTimeMinutesTextBox.Text));
//                    
//                    lesson.EndEvent = lesson.EndEvent.AddHours(
//                        Convert.ToDouble(getLesson.EndTimeHourTextBox.Text));
//                    lesson.EndEvent = lesson.EndEvent.AddMinutes(
//                        Convert.ToDouble(getLesson.EndTimeMinutesTextBox.Text));
//                    
//                    _schoolTimeTable.Add(lesson);
//                    CreateCard(lesson, Brushes.LightSlateGray);
//                    MessageBox.Show("Вы создали EVENT");
//                    getLesson.Close();
//                };
//                getLesson.Show();
//            }
//            catch (Exception exception)
//            {
//                MessageBox.Show(exception.ToString());
//            }
//        }

        /// <summary>
        /// При нажатии на дату в календаре, меняет значения таблицы
        /// </summary>
        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? dateTimeCalendar = Calendar.SelectedDate;
            if (dateTimeCalendar != null)
            {
                DateTime dateTime = (DateTime) dateTimeCalendar;
                DateTime secondDateTime = dateTime;
                while (secondDateTime.DayOfWeek != DayOfWeek.Monday)
                {
                    secondDateTime = secondDateTime.AddDays(-1);
                }

                for (int k = 0; k < 8; k++)
                {
                    _dateTimesWeek[k] = secondDateTime;
                    _daysWeek[k].Text = secondDateTime.DayOfWeek + "\n" + secondDateTime.Day;
                    if (dateTime.Equals(secondDateTime))
                    {
                        _daysWeek[k].Foreground = Brushes.DodgerBlue;
                    }
                    else
                    {
                        _daysWeek[k].Foreground = Brushes.Black;
                    }

                    secondDateTime = secondDateTime.AddDays(1);
                }
            }
        }

//        /// <summary>
//        /// Создание CardView
//        /// </summary>
//        private void CreateCard(Lesson lesson, Brush color)
//        {
//            Card card = new Card();
//            Grid grid = new Grid();
//            DateTime q = new DateTime( lesson.EndEvent.Subtract(lesson.StartEvent).Ticks);
//            TextBlock textBlock = new TextBlock();
//            textBlock.Text = $"{lesson.Name}\n" +
//                             $"{lesson.StartEvent:d}\n" +
//                             $"{lesson.EndEvent:d}\n" +
//                             $"{lesson.Details}\n";
//            card.Margin = new Thickness(0,lesson.StartEvent.Minute,0,0);
//            
//            grid.Children.Add(textBlock);
//            card.Content = grid;
//            card.MinHeight = 100;
//            card.Height = q.Hour * 64 + q.Minute;
//            card.Padding = new Thickness(5);
//            card.MinWidth = 100;
//            card.Background = color;
//            MainGrid.Children.Add(card);
//            switch (lesson.StartEvent.DayOfWeek)
//            {
//                case DayOfWeek.Monday:
//                    Grid.SetColumn(card, 3);
//                    break;
//                case DayOfWeek.Tuesday:
//                    Grid.SetColumn(card, 5);
//                    break;
//                case DayOfWeek.Wednesday:
//                    Grid.SetColumn(card, 7);
//                    break;
//                case DayOfWeek.Thursday:
//                    Grid.SetColumn(card, 9);
//                    break;
//                case DayOfWeek.Friday:
//                    Grid.SetColumn(card, 11);
//                    break;
//                case DayOfWeek.Saturday:
//                    Grid.SetColumn(card, 13);
//                    break;
//                case DayOfWeek.Sunday:
//                    Grid.SetColumn(card, 15);
//                    break;
//            }
//            Grid.SetRow(card, lesson.StartEvent.Hour*2+1);
//            Grid.SetRowSpan(card, (int) Math.Ceiling((decimal) card.Height / 64 +1)*2);
//            
//            ContextMenu contextMenu = new ContextMenu();
//            MenuItem menuItem = new MenuItem();
//            menuItem.Header = "Delete";
//            menuItem.Click += (senderSlave, eSlave) =>
//            {
//                MainGrid.Children.Remove(card);
//                _schoolTimeTable.Remove(lesson);
//            };
//            contextMenu.Items.Add(menuItem);
//            card.ContextMenu = contextMenu;
//        }
    }
}

/*
 * <materialDesign:ColorZone Grid.Row="3" Grid.Column="2" Mode="Light" CornerRadius="2"
                                  materialDesign:ShadowAssist.ShadowDepth="Depth1" 
                                  Height="100" Width="100" Background="#2979ff">
        </materialDesign:ColorZone>
        
        private string GetFileText()
                {
                    string newPatch = $"{WorkFile.GetUserSavePath()}\\{_nameFile}.txt";
                    var fileR = new StreamReader(newPatch);
                    string fileText = "";
                    string line;
                    while ((line = fileR.ReadLine()) != null)
                    {
                        fileText += line;
                    }
                    fileR.Close();
                    return fileText;
                }
 */

/*
 * <Window x:Class="WindowsApp.OtherWindow.TimetableWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        mc:Ignorable="d"
        xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
        FontFamily="{DynamicResource MaterialDesignFont}"
        Closing="TimetableWindow_OnClosing"
        Title="TimetableWindow" Height="450" Width="800" MinWidth="800" MinHeight="450">
    <Grid ShowGridLines="True" x:Name="MainGrid">
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <TextBlock Margin="5" Text="Время"/>
        <TextBlock Grid.Row="1" Grid.Column="0" Text="10:00" Margin="5"/>
        <TextBlock Grid.Row="2" Grid.Column="0" Text="10:30" Margin="5"/>
        <TextBlock Grid.Row="3" Grid.Column="0" Text="11:00" Margin="5"/>
        <TextBlock Grid.Row="4" Grid.Column="0" Text="11:30" Margin="5"/>
        <TextBlock Grid.Row="5" Grid.Column="0" Text="12:00" Margin="5"/>
        <TextBlock Grid.Row="6" Grid.Column="0" Text="12:30" Margin="5"/>
        <TextBlock Grid.Row="7" Grid.Column="0" Text="13:00" Margin="5"/>
        <TextBlock Grid.Row="8" Grid.Column="0" Text="13:30" Margin="5"/>
        <TextBlock Grid.Row="9" Grid.Column="0" Text="14:00" Margin="5"/>
        <TextBlock Grid.Row="10" Grid.Column="0" Text="14:30" Margin="5"/>
        <TextBlock Grid.Row="11" Grid.Column="0" Text="15:00" Margin="5"/>
        <TextBlock Grid.Row="12" Grid.Column="0" Text="15:30" Margin="5"/>
        <TextBlock Grid.Row="13" Grid.Column="0" Text="16:00" Margin="5"/>
        <TextBlock Grid.Row="14" Grid.Column="0" Text="16:30" Margin="5"/>
        <TextBlock Grid.Row="15" Grid.Column="0" Text="17:00" Margin="5"/>
    </Grid>
</Window>
 */
