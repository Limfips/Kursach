using CreateSchedule;
using CreateSchedule.Logic;

namespace WindowsApp.HandlerDir
{
    /// <summary>
    ///     Обработчик между графикой и логикой. Главный класс при вызове других
    /// </summary>
    public class Handler
    {
        public void Main()
        {
            var createSchedule = new Creation();
        }
    }
}