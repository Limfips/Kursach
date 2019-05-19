using System;
using System.Collections.Generic;

namespace WindowsApp.OtherClasses.School
{
    public class SchoolTimeTable
    {
        private List<Lesson> _lessons;
        public SchoolTimeTable() : this(new List<Lesson>()){}
        public SchoolTimeTable(List<Lesson> lessons)
        {
            _lessons = lessons;
        }
        public void Add(Lesson lesson)
        {
            _lessons.Add(lesson);
        }
        public void Remove(Lesson lesson)
        {
            _lessons.Remove(lesson);
        }

        public List<Lesson> Lessons
        {
            get { return _lessons; }
            set { _lessons = value; }
        }
    }
}