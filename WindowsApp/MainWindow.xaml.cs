using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WindowsApp.Logic;
using WindowsApp.OterWindow;
using WindowsApp.OtherWindow;
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
                string patch = $"{_workFile.GetUserSavePath()}\\{nameFile}.txt";
                StreamWriter file = new StreamWriter(patch);
                file.Close();
                getText.Close();
                GetFiles_OnClick(sender,e);
            };
            getText.Show();
            
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
            TimetableWindow timetableWindow = new TimetableWindow((string) ListBox.SelectedItems[0]);
            timetableWindow.Title = ListBox.SelectedItems[0].ToString();
            timetableWindow.Show();
            Close();
        }

        private List<string> GetFileNames()
        {
            var dirPath = _workFile.GetUserSavePath();
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
                string newPatch = $"{_workFile.GetUserSavePath()}\\{(string) ListBox.SelectedItems[0]}.txt";
                File.Move(newPatch, $"{_workFile.GetUserSavePath()}\\{newNameFile}.txt");
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
            string newPatch = $"{_workFile.GetUserSavePath()}\\{(string) ListBox.SelectedItems[0]}.txt";
            File.Delete(newPatch);
            GetFiles_OnClick(sender,e);
        }
    }
    
    
}