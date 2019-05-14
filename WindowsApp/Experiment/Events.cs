using System;

namespace WindowsApp.Experiment
{
    public class Events
    {
        private string _nameEvent;
        private DateTime _dateTimeEvent;
        public Events(string readLine)
        {
            GetNewStudent(readLine);
        }
        private  void GetNewStudent(string readLine)
        {
            var simSent = readLine.Split('_');
            _nameEvent = simSent[0];
            _dateTimeEvent = Convert.ToDateTime(simSent[1]);
        }

        public string NameEvent
        {
            get => _nameEvent;
            set => _nameEvent = value;
        }

        public DateTime DateTimeEvent
        {
            get => _dateTimeEvent;
            set => _dateTimeEvent = value;
        }
    }
}