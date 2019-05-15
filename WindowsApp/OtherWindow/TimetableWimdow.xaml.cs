using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media;
using WindowsApp.Logic;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;

namespace WindowsApp.OtherWindow
{
    public partial class TimetableWindow : Window
    {
        private readonly string _nameFile;
        private readonly WorkFile _workFile = new WorkFile();
        public TimetableWindow(string nameFile)
        {
            InitializeComponent();
            _nameFile = nameFile;
            

        }

        private string GetFileText()
        {
            string newPatch = $"{_workFile.GetUserSavePath()}\\{_nameFile}.txt";
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

        private void TimetableWindow_OnClosing(object sender, CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

/*
 * <materialDesign:ColorZone Grid.Row="3" Grid.Column="2" Mode="Light" CornerRadius="2"
                                  materialDesign:ShadowAssist.ShadowDepth="Depth1" 
                                  Height="100" Width="100" Background="#2979ff">
        </materialDesign:ColorZone>
 */
