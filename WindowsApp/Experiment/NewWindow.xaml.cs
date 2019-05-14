using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace WindowsApp.Experiment
{
    public partial class NewWindow : Window
    {
        public NewWindow()
        {
            InitializeComponent();
        }

        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItemCreateEvent_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы создали ивент!");
            const string soursFile = "c:\\WindowsAppDir\\FirstTimetable.txt";
            
//            StreamReader fileReader = new StreamReader(soursFile);
//            fileReader.Close();
                
            StreamWriter fileWriter = new StreamWriter(soursFile);
            fileWriter.WriteLine($"{TextBoxNameEvent.Text}_{DatePickerEvent}");
            fileWriter.Close();
            
            Close();
        }

        
    }
}
