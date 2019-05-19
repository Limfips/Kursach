using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using WindowsApp.OtherClasses;
using WindowsApp.OtherClasses.School;

namespace WindowsApp.Logic
{
    public class WorkFile
    {
        private const string UserSavePath = "c:\\WindowsAppDir\\UserSave";
        private const string SourcePath = "c:\\WindowsAppDir\\Source";
        private SchoolTimeTable _schoolTimeTable;

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

        public void SaveDate(List<Lesson> lessons, string nameFile)
        {
            var file = new StreamWriter(UserSavePath+"\\"+nameFile+".txt");
            foreach (var lesson in lessons)
            {
                file.WriteLine($"{lesson.Name}_{lesson.StartEvent}_{lesson.EndEvent}" +
                               $"_{lesson.RepeatEvent}_{lesson.Details}");
            }
            file.Close();
        }

        public SchoolTimeTable GetDataUser(string nameFile)
        {
            _schoolTimeTable = new SchoolTimeTable();
            StreamReader file = StreamReader.Null;

            try
            {
                file = new StreamReader(UserSavePath + "\\" + nameFile + ".txt");
                string fileLine;
                while ((fileLine = file.ReadLine()) != null)
                {
                    if (fileLine != "")
                    {
                        var simSent = fileLine.Split('_');
                        var lesson = new Lesson(simSent[0], Convert.ToDateTime(simSent[1]),
                            Convert.ToDateTime(simSent[2]),
                            (Event.RepeatCategories)Enum.Parse(typeof(Event.RepeatCategories),
                                simSent[3]) ,simSent[4]);
                        _schoolTimeTable.Add(lesson);
                    }
                }
            }
            finally
            {
                file.Close();
            }
            
            return _schoolTimeTable;
        }
    }
}