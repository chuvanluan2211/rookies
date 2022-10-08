using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi3.Events
{
    public class Clock
    {
        private readonly int _second;

        public delegate void ClockTickHandler(object clock , ClockEventArgs clockEventArgs ) ;

        public event ClockTickHandler? tiktok;

        protected void OnTime(object clock ,ClockEventArgs clockEventArgs)
        {
            if(tiktok != null)
            {
                tiktok(clock,clockEventArgs);
            }
        }

        public void Run()
        {
            while(!Console.KeyAvailable)
            {
                Thread.Sleep(1000);

                var time = DateTime.Now;

                if(time.Second != _second)
                {
                    var clockEventArgs = new ClockEventArgs(time.Hour , time.Minute , time.Second ) ; 
                    
                    OnTime(this , clockEventArgs );
                }
            }
        }
    }
}