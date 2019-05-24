using System;
using System.Windows;
using WindowsApp.OtherClasses;
using WindowsApp.OtherClasses.Final;


namespace WindowsApp.OtherWindow
{
    public partial class GetNewTimetableWindow : Window
    {
        public GetNewTimetableWindow()
        {
            InitializeComponent();
            var valuesAsList = Enum.GetNames(typeof(Event.RepeatCategories));
            foreach (var item in valuesAsList)
            {
                RepeatComboBox.Items.Add(item);
            }
        }

    }
}
