using System.IO;
using System.Windows;

namespace WindowsApp.OtherWindow
{
    public partial class NewTimetable : Window
    {
        public NewTimetable()
        {
            InitializeComponent();
        }

        private void GetTextButton_OnClick(object sender, RoutedEventArgs e)
        {
            string nameFile = TextBox.Text;
            
            Close();
        }
    }
}