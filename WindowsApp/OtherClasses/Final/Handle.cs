using System;
using System.Collections.Generic;
using System.Diagnostics;
using CreateSchedule.Objects;

namespace WindowsApp.OtherClasses.Final
{
    public class Handle 
    {
        public readonly DataSource DataSource = new DataSource();
        public Handle(){}

        /// <summary>
        /// Создание нового предмета
        /// </summary>
        public void AddSchoolLesson(string name, DateTime startEvent, DateTime endEvent, 
            Event.RepeatCategories repeatEvent, string details, int schoolRoom, string schoolTeacher)
        {
            SchoolLesson lesson = new SchoolLesson(name, startEvent, repeatEvent,
                                                        details, schoolRoom,schoolTeacher);
            DataSource.AddSchoolTimetable(lesson);
        }
        //Получаем данные из DS------------------------------------------------------
        public List<int> GetDataSchoolRooms()
        {
            return DataSource.SchoolRooms;
        }
        public List<int> GetUniversityRooms()
        {
            return DataSource.UniversityRooms;
        }
        public List<string> GetSchoolTeachers()
        {
            return DataSource.SchoolTeachers;
        }
        public List<string> GetUniversityTeachers()
        {
            return DataSource.UniversityTeachers;
        }
        public List<SchoolLesson> GetSchoolTimetable()
        {
            return DataSource.SchoolTimetable;
        }
        //---------------------------------------------------------------------------
        
    }
}