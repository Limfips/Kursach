using System;

namespace CreateSchedule.Objects
{
    /// <summary>
    ///     Общий класс для любого ивента рассписания.
    /// </summary>
    public abstract class Event
    {
        protected TypeTimetable TypeEvent;         //Тип ивента
        protected DateTime TimeBeginEvent;         //Врем начала ивента
        protected DateTime TimeEndEvent;           //Врем начала ивента
        protected string  DescriptionEvent;        //Описание ивента
    }
    public enum TypeTimetable
    {
        University,
        School
    }
}