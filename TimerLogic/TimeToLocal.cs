using System;

namespace TimerLogic
{
    public class TimeToLocal
    {
        public TimeSpan ConvertToLocal(TimeSpan inSpan)
        {
            var offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
            return inSpan.Add(offset);
        }
    }
}