using System.IO;

namespace WindowsApp.configs
{
    public class CheckProgram
    {
        private const string DirPath = "c:\\WindowsAppDir";

        public void CheckStarted()
        {
            if (!Directory.Exists(DirPath)) Directory.CreateDirectory(DirPath);
        }
    }
}