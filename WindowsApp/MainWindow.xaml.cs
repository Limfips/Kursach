using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using WindowsApp.configs;
using MaterialDesignThemes.Wpf;

namespace WindowsApp
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBox.ItemsSource = GetFileNames();
        }

        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        
        private void MenuItemCreateTimetable_OnClick(object sender, RoutedEventArgs e)
        {
            MainGrid.Visibility = Visibility.Collapsed;
            UserNewTimetableGrid.Visibility = Visibility.Visible;
        }
        
        private void MenuItemReturnMainGrid_OnClick(object sender, RoutedEventArgs e)
        {
            UserNewTimetableGrid.Visibility = Visibility.Collapsed;
            OpenUserTimetableGrid.Visibility = Visibility.Collapsed;
            MainGrid.Visibility = Visibility.Visible;
        }
        private void MenuItemOpenTimetable_OnClick(object sender, RoutedEventArgs e)
        {
            OpenTimetable();
        }
        private void MouseButtonOpenTimetable_OnClick(object sender, MouseButtonEventArgs e)
        {
            OpenTimetable();
        }

        private void OpenTimetable()
        {
            MainGrid.Visibility = Visibility.Collapsed;
            OpenUserTimetableGrid.Visibility = Visibility.Visible;
            UserTimetableTextBlock.Text = (string) ListBox.SelectedItems[0];

            string newPatch = $"c:\\WindowsAppDir\\{(string) ListBox.SelectedItems[0]}.txt";
            var fileR = new StreamReader(newPatch);
            string fileText = "";
            string line;
            while ((line = fileR.ReadLine()) != null)
            {
                fileText += line;
            }
            fileR.Close();
            Card asd = new Card
            {
                Content = fileText,
                Margin = new Thickness(0,1,0,0),
                Padding = new Thickness(5)
                
            };
            Grid.Children.Add(asd);
        }

        private List<string> GetFileNames()
        {
            var dirPath = "c:\\WindowsAppDir";
            var filePaths = Directory.GetFiles(dirPath);
            return filePaths.Select(Path.GetFileNameWithoutExtension).ToList();
        }

        private void GetFiles_OnClick(object sender, RoutedEventArgs e)
        {
            ListBox.ItemsSource = GetFileNames();
            //<ListBox  x:Name="ListBox" MouseDoubleClick="GetSelectedItem"/>
        }

        private void MenuItemRenameTimetable_OnClick(object sender, RoutedEventArgs e)
        {
            string newPatch = $"c:\\WindowsAppDir\\{(string) ListBox.SelectedItems[0]}.txt";
            File.Move(newPatch, "c:\\WindowsAppDir\\newfilename.txt");
            GetFiles_OnClick(sender,e);
        }

        private void MenuItemDeleteTimetable_OnClick(object sender, RoutedEventArgs e)
        {
            string newPatch = $"c:\\WindowsAppDir\\{(string) ListBox.SelectedItems[0]}.txt";
            File.Delete(newPatch);
            GetFiles_OnClick(sender,e);
        }
    }
    
    
}