namespace CreateSchedule
{
    public class UniversityTimetable : Event
    {
        private readonly TypePair _typePair;
        
        public UniversityTimetable(TypePair typePair)
        {
            TypeEvent = TypeTimetable.University;
            _typePair = typePair;

            if (_typePair == TypePair.Lecture)
            {
                
            }
        }
        public enum TypePair 
        {
            Lecture,
            Practice
        }
    }
}