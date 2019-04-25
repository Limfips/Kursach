using System;

namespace CreateSchedule
{
    /// <summary>
    ///     Общий класс для любого ивента рассписания.
    /// </summary>
    public abstract class Event
    {
        protected TypeTimetable TypeEvent;
        protected DateTime TimeEvent;
        protected string SpecificationEvent;

        protected enum TypeTimetable
        {
            University,
            School
        }
    }
}