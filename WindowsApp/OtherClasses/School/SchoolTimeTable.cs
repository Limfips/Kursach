using System;
using System.Collections.Generic;

namespace WindowsApp.OtherClasses.School
{
    public class SchoolTimeTable
    {
        private List<Lesson> _lessons;
        public SchoolTimeTable(List<Lesson> lessons)
        {
            _lessons = lessons;
        }
    }
}