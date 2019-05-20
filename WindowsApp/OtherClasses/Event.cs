using System;

namespace WindowsApp.OtherClasses
{
    public  class Event
    {
        public string Name { get; set; }
        public DateTime StartEvent{ get; set; }
        public DateTime EndEvent { get; set; }
        public RepeatCategories RepeatEvent { get; set; }
        public string Details { get; set; }

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