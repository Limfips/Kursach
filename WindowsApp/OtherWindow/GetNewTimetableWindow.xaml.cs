using System;
using System.Windows;
using WindowsApp.OtherClasses;


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

//        private Lesson GetNewLesson()
//        {
//            return new Lesson("",new DateTime(),"");
//        }

    }
}
