using System;

namespace WindowsApp.OtherClasses
{
    public  class Event
    {
        public string Name { get; }
        public DateTime StartEvent;
        public DateTime EndEvent { get; }
        public RepeatCategories RepeatEvent { get; }
        public string Details { get; }

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

        public enum Categories
        {
            SchoolTimetable,
            OtherEvents
        }

        public enum RepeatCategories
        {
            Everyday,
            EveryWeek
        }
        
    }
}