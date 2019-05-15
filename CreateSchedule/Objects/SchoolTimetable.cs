using System;

namespace CreateSchedule.Objects
{
    public class SchoolTimetable : Event
    {
        private string _teacherName;
        private string _schoolGroup;
        private int _classNumber;
        public SchoolTimetable(TypeTimetable typeEvent,DateTime timeBeginEvent, DateTime timeEndEvent, 
            string descriptionEvent,string teacherName, string schoolGroup, int classNumber)
        {
            if (typeEvent != TypeTimetable.School)
            {
                throw new Exception("Системная ошибка типа события");
            }
            TypeEvent = typeEvent;
            TimeBeginEvent = timeBeginEvent;
            TimeEndEvent = timeEndEvent;
            DescriptionEvent = descriptionEvent;
            _teacherName = teacherName;
            _schoolGroup = schoolGroup;
            _classNumber = classNumber;
        }
    }
}