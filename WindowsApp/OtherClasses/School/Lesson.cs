using System;

namespace WindowsApp.OtherClasses.School
{
    public class Lesson : Event
    {
        private const Categories Category = Categories.SchoolTimetable;

        public Lesson(
            string name,
            DateTime startEvent, 
            DateTime endEvent, 
            RepeatCategories repeatEvent, 
            string details) : base(name,startEvent,endEvent,repeatEvent,details){}

        public Categories GetCategory()
        {
            return Category;
        }
    }
}