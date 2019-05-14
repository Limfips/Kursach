using System;
using System.Windows;

namespace WindowsApp.OterWindow
{
    public partial class GetText : Window
    {
        public GetText(string nameFile)
        {
            InitializeComponent();
            TextBox.Text = nameFile;
        }
    }
}
