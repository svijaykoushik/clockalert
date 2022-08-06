using System;

namespace ClockAlert.Modules
{
    /// <summary>
    /// Performs time related operations
    /// </summary>
    internal class TimeKeeper
    {
        /// <summary>
        /// Checks wether it is time to ring the sound
        /// </summary>
        /// <returns>True if an hour is complete</returns>
        public bool IsItTime(DateTime now)
        {
            if (now.Minute.ToString() == "0" && now.Second.ToString() == "0")
                return true;
            else
                return false;
        }

        public bool IsBetween(DateTime now, DateTime start, DateTime end)
        {
            if (now.TimeOfDay == start.TimeOfDay)
                return true;
            if (now.TimeOfDay == end.TimeOfDay)
                return true;
            if (start.TimeOfDay <= end.TimeOfDay)
                return (now.TimeOfDay >= start.TimeOfDay && now.TimeOfDay <= end.TimeOfDay);
            else
                return !(now.TimeOfDay >= start.TimeOfDay && now.TimeOfDay <= end.TimeOfDay);
        }
    }
}
