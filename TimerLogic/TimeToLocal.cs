using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLogic
{
    public class TimeToLocal
    {
        public TimeSpan ConvertToLocal(TimeSpan inSpan)
        {
            TimeSpan offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
            return inSpan.Add(offset);

        }



    }
}
