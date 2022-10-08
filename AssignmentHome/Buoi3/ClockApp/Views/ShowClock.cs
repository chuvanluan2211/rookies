using Buoi3.Events;

namespace Buoi3.Views
{
    public class ShowClock
    {
        public void Subcribe(Clock clock)
        {
            clock.tiktok += new Clock.ClockTickHandler(DisplayClock);
        }

        public void DisplayClock(object clock, ClockEventArgs clockEventArgs)
        {
            System.Console.WriteLine($"{clockEventArgs.hour} : {clockEventArgs.minute} : {clockEventArgs.second}");
        }
    }
}