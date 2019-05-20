using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WindowsApp.Logic;
using WindowsApp.OtherClasses;
using WindowsApp.OtherClasses.School;
using MaterialDesignThemes.Wpf;

namespace WindowsApp.OtherWindow
{
    public partial class TimetableWindow : Window
    {
        private static string _nameFile;
        private TextBlock _textBlock = new TextBlock();
        private static readonly WorkFile WorkFile = new WorkFile();
        private readonly SchoolTimeTable _schoolTimeTable;
        public TimetableWindow(string nameFile)
        {
            InitializeComponent();
            
            MainGrid.Children.Add(_textBlock);
            Grid.SetColumn(_textBlock, 0);
            Grid.SetRow(_textBlock, 0);
            
           //MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
//            _nameFile = nameFile;
//
//            _schoolTimeTable = WorkFile.GetDataUser(_nameFile);
//            //ToDo List
//            //ListBox.Items.Clear();
//            foreach (var lesson in _schoolTimeTable.Lessons)
//            {
//                Print(lesson);
//            }
            GenericTimetable();
//            for (int i = 2; i < 5; i++)
//            {
//                Button button = new Button();
//                button.Width = 500;
//                button.Height = 200;
//                button.VerticalAlignment = VerticalAlignment.Top;
//                button.Margin = new Thickness(3);
//                MainGrid.Children.Add(button);
//                Grid.SetColumn(button, i);
//                var x = button.Height;
//                int k = 1;
//                while (x > 60)
//                {
//                    x -= 60;
//                    k++;
//                }
//                Grid.SetRow(button, 3);
//                Grid.SetRowSpan(button, k);
//            }

        }

        private  void GenericTimetable()
        {
            for (int i = 1, k = 0; k < 24; i+=2, k++)
            {
                var textBlock = new TextBlock();
                textBlock.Text = k<10 ? $"0{k}:00" : $"{k}:00";
                MainGrid.Children.Add(textBlock);
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.FontSize = 16;
                textBlock.Margin = new Thickness(3);
                Grid.SetColumn(textBlock, 1);
                Grid.SetRow(textBlock, i+1);
            }
        }
        private void TimetableWindow_OnClosing(object sender, CancelEventArgs e)
        {
            WorkFile.SaveDate(_schoolTimeTable.Lessons,_nameFile);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var getLesson = new GetNewTimetableWindow();
                getLesson.Button.Click += (senderSlave, eSlave) =>
                {
                    Lesson lesson = new Lesson(getLesson.NameTextBox.Text, 
                        Convert.ToDateTime(getLesson.StartDatePicker.ToString()),
                        Convert.ToDateTime(getLesson.EndDatePicker.ToString()),
                        (Event.RepeatCategories)Enum.Parse(typeof(Event.RepeatCategories),
                            getLesson.RepeatComboBox.SelectedItem.ToString()),
                        getLesson.DetailsTextBox.Text);
                    _schoolTimeTable.Add(lesson);
                    Print(lesson);
                    MessageBox.Show("Вы создали EVENT");
                    getLesson.Close();
                };
                getLesson.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
        private void Print(Lesson lesson)
        {
            Card card = new Card();
            card.Height = 65    ;
            card.Width = Width;
            card.Background = Brushes.Tan;
            card.Padding = new Thickness(3);
            TextBlock textBlock = new TextBlock();
            textBlock.Text = $"{lesson.Name}\n" +
                             $"{lesson.StartEvent:d}\n" +
                             $"{lesson.EndEvent:d}\n" +
                             $"{lesson.Details}\n";
            Grid grid = new Grid();
            grid.Children.Add(textBlock);
            card.Content = grid;
            //ToDo List
            // ListBox.Items.Add(card);
        }

        //ToDo Метод обработки данных с калдендаря
        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? dateTime = Calendar.SelectedDate;
            if (dateTime != null) _textBlock.Text = ((DateTime) dateTime).DayOfWeek.ToString();
        }
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
