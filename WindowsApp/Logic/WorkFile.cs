using System.IO;

namespace WindowsApp.Logic
{
    public class WorkFile
    {
        private const string DirPath = "c:\\WindowsAppDir\\UserSave";
        private const string SourcePath = "c:\\WindowsAppDir\\Source";

        public void CheckStarted()
        {
            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
                Directory.CreateDirectory(SourcePath);
            }
        }
        public string GetDirPath()
        {
            return DirPath;
        }

        
        public void RenameFile()
        {
            
        }
    }
}