using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WindowsApp.Logic;
using WindowsApp.OterWindow;
using MaterialDesignThemes.Wpf;

namespace WindowsApp
{
    public partial class MainWindow
    {
        private readonly WorkFile _workFile = new WorkFile();
        public MainWindow()
        {
            InitializeComponent();
            _workFile.CheckStarted();
            ListBox.ItemsSource = GetFileNames();
//            Timetable timetable = new Timetable();
//            timetable.Show();
//            Close();
        }

        /// <summary>
        /// Выполняется выход из программы
        /// </summary>
        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Создание нового расписания
        /// </summary>
        private void MenuItemCreateTimetable_OnClick(object sender, RoutedEventArgs e)
        {
            GetText getText = new GetText("");
            getText.GetTextButton.Click += (senderSlave, eSlave) =>
            {
                string nameFile = getText.TextBox.Text;
                string patch = $"{_workFile.GetDirPath()}\\{nameFile}.txt";
                StreamWriter file = new StreamWriter(patch);
                file.Write("текст");
                file.Close();
                getText.Close();
                GetFiles_OnClick(sender,e);
            };
            getText.Show();
            
        }
        /// <summary>
        /// Вернуться к главному меню
        /// </summary>
        private void MenuItemReturnMainGrid_OnClick(object sender, RoutedEventArgs e)
        {
            OpenUserTimetableGrid.Visibility = Visibility.Collapsed;
            MainGrid.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Запрос по выбору из выплывающего меню
        /// </summary>
        private void MenuItemOpenTimetable_OnClick(object sender, RoutedEventArgs e)
        {
            OpenTimetable();
        }
        /// <summary>
        /// Запрос по 2-му клику мыши
        /// </summary>
        private void MouseButtonOpenTimetable_OnClick(object sender, MouseButtonEventArgs e)
        {
            OpenTimetable();
        }

        /// <summary>
        /// Открытие файла данных
        /// </summary>
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
        /// <summary>
        /// Изменение имени файла
        /// </summary>
        private void MenuItemRenameTimetable_OnClick(object sender, RoutedEventArgs e)
        {
            GetText getText = new GetText((string) ListBox.SelectedItems[0]);
            getText.GetTextButton.Click += (senderSlave, eSlave) =>
            {
                string newNameFile = getText.TextBox.Text;
                string newPatch = $"c:\\WindowsAppDir\\{(string) ListBox.SelectedItems[0]}.txt";
                File.Move(newPatch, $"c:\\WindowsAppDir\\{newNameFile}.txt");
                getText.Close();
                GetFiles_OnClick(sender,e);
            };
            getText.Show();
        }
        /// <summary>
        /// Удаление файла
        /// </summary>
        private void MenuItemDeleteTimetable_OnClick(object sender, RoutedEventArgs e)
        {
            string newPatch = $"c:\\WindowsAppDir\\{(string) ListBox.SelectedItems[0]}.txt";
            File.Delete(newPatch);
            GetFiles_OnClick(sender,e);
        }
    }
    
    
}