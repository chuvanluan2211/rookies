using Buoi3.Events;
using Buoi3.Views;

Clock clock = new Clock();
ShowClock showClock = new ShowClock();

showClock.Subcribe(clock);

clock.Run();