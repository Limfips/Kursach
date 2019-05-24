using System;

namespace WindowsApp.OtherClasses.Final
{
    public class Event
    {
        internal string Name { get; set; }
        internal DateTime StartEvent{ get; set; }
        internal DateTime EndEvent { get; set; }
        internal RepeatCategories RepeatEvent { get; set; }
        internal string Details { get; set; }

        protected Event(
            string name,
            DateTime startEvent, 
            DateTime endEvent, 
            RepeatCategories repeatEvent, 
            string details)
        {
            Name = name;
            StartEvent = startEvent;
            EndEvent = endEvent;
            RepeatEvent = repeatEvent;
            Details = details;
        }

        protected enum Categories
        {
            SchoolTimetable,
            UniversityTimetable,
            OtherEvents
        }

        public enum RepeatCategories
        {
            Once,
            Everyday,
            EveryWeek,
            EveryMonth,
            EveryYear
        }
        
    }
}