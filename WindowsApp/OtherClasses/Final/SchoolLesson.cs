using System;

namespace WindowsApp.OtherClasses.Final
{
    public class SchoolLesson : Event
    {
        private int _schoolRoom;
        private string _schoolTeacher;
        private const Categories Category = Categories.SchoolTimetable;

        internal SchoolLesson(string name, DateTime startEvent, 
                        RepeatCategories repeatEvent, string details, int schoolRoom, string schoolTeacher) 
                    : base(name, startEvent, startEvent.AddMinutes(40), repeatEvent, details)
        {
            _schoolRoom = schoolRoom;
            _schoolTeacher = schoolTeacher;
        }
    }
}