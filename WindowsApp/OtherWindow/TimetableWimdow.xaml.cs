using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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
        private static readonly WorkFile WorkFile = new WorkFile();
        private readonly SchoolTimeTable _schoolTimeTable;
        public TimetableWindow(string nameFile)
        {
            InitializeComponent();
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
        }

        private  void GenericTimetable()
        {
            for (var i = 1; i < 24; i++)
            {
                var textBlock = new TextBlock();
                textBlock.Text = i<10 ? $"0{i}:00" : $"{i}:00";
                MainGrid.Children.Add(textBlock);
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.FontSize = 16;
                textBlock.Margin = new Thickness(3);
                Grid.SetColumn(textBlock, 0);
                Grid.SetRow(textBlock, i);
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
