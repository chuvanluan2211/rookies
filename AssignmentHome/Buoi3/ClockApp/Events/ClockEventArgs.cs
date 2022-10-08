using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi3.Events
{
    public class ClockEventArgs : EventArgs
    {
        public readonly int hour;
        public readonly int minute;
        public readonly int second;

        public ClockEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
    }
}