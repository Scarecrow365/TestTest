using System;

namespace _clone.Scripts.Data.User.Reminder
{
    [Serializable]
    public class SerializeReminderData
    {
        public int minutes;
        public int hours;
        public TimePeriod period;
        public Days[] days = Array.Empty<Days>();

        public enum Days
        {
            su = 0,
            mo = 1,
            tu = 2,
            we = 3,
            th = 4,
            fr = 5,
            sa = 6
        }

        public enum TimePeriod
        {
            am,
            pm
        }
    }
}