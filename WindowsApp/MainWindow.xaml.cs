using System;
using System.IO;
using System.Windows;
using WindowsApp.configs;

namespace WindowsApp
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void GetFiles_OnClick(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
            var dirPath = "c:\\WindowsAppDir";
            var filePaths = Directory.GetFiles(dirPath);
            foreach (var filePath in filePaths)
            {
                ListBox.Items.Add(Path.GetFileNameWithoutExtension(filePath));
            }
            //<ListBox  x:Name="ListBox" MouseDoubleClick="GetSelectedItem"/>
        }
//        private void GetSelectedItem(object sender, MouseButtonEventArgs e)
//        {
//            string book = (string) ListBox.SelectedItems[0];
//            string newPatch = $"c:\\WindowsAppDir\\{book}.txt";
//            StreamWriter fileW = new StreamWriter(newPatch);
//            fileW.WriteLine("А я тыкал по нему)))\n");
//            fileW.Close();
//            var fileR = new StreamReader(newPatch);
//            TextBlock.Text = fileR.ReadLine();
//        }
    }
}