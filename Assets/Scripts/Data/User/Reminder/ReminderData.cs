using System;
using System.Collections.Generic;

namespace _clone.Scripts.Data.User.Reminder
{
    public class ReminderData : IData
    {
        public DateTime Time { get; private set; }
        public List<DayOfWeek> Days { get; private set; }

        public bool GetDay(DayOfWeek day)
        {
            return Days.Contains(day);
        }

        public void Set(SerializeReminderData data)
        {
        }
    }
}