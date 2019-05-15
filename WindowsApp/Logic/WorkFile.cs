using System.IO;

namespace WindowsApp.Logic
{
    public class WorkFile
    {
        private const string UserSavePath = "c:\\WindowsAppDir\\UserSave";
        private const string SourcePath = "c:\\WindowsAppDir\\Source";

        public void CheckStarted()
        {
            if (!Directory.Exists(UserSavePath))
            {
                Directory.CreateDirectory(UserSavePath);
                Directory.CreateDirectory(SourcePath);
            }
        }
        public string GetUserSavePath()
        {
            return UserSavePath;
        }
        public string GetSourcePath()
        {
            return SourcePath;
        }
        public void RenameFile()
        {
            
        }
    }
}