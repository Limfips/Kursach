using System;

namespace WindowsApp.OtherClasses
{
    public abstract class Event
    {
        public string Name { get; set;}
        public DateTime Time { get; set;}
        public string Details { get; set;}
    }
}