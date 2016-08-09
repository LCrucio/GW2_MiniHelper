using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLogic
{
    public class TimeDB
    {
        public Dictionary<gw2Events, List<TimeSpan>> timeDictionaryDB;
        private TimeToLocal timeConverter;

        public TimeDB()
        {
            timeDictionaryDB = new Dictionary<gw2Events, List<TimeSpan>>();
            timeConverter=new TimeToLocal();
            PopulateDB(timeDictionaryDB);
        }


        private void PopulateDB(Dictionary<gw2Events, List<TimeSpan>> dict)
        {
            SetEvent(dict,gw2Events.Tarir);
            SetEvent(dict,gw2Events.Tequatl);
        }

        private void SetEvent(Dictionary<gw2Events, List<TimeSpan>> dict, gw2Events type)
        {
            List<TimeSpan> list = new List<TimeSpan>();

            switch (type)
            {
                case gw2Events.Tarir:
                    TarirAdd(dict, type, list);
                    break;

                case gw2Events.Tequatl:
                    TequatlAdd(dict, type, list);
                    break;

                default:
                    throw new ArgumentException();
                break;
            }
        }

        private static void TarirAdd(Dictionary<gw2Events, List<TimeSpan>> dict, gw2Events type, List<TimeSpan> list)
        {
            for (int i = 0; i < 13; i++)
            {
                TimeSpan temp = new TimeSpan(2*i, 45, 0);
                list.Add(temp);
            }
            dict.Add(type, list);
        }

        private static void TequatlAdd(Dictionary<gw2Events, List<TimeSpan>> dict, gw2Events type, List<TimeSpan> list)
        {
            TimeSpan spawn1 = new TimeSpan(24, 0, 0);
            list.Add(spawn1);
            TimeSpan spawn2 = new TimeSpan(3, 0, 0);
            list.Add(spawn2);
            TimeSpan spawn3 = new TimeSpan(7, 0, 0);
            list.Add(spawn3);
            TimeSpan spawn4 = new TimeSpan(11, 30, 0);
            list.Add(spawn4);
            TimeSpan spawn5 = new TimeSpan(16, 0, 0);
            list.Add(spawn5);
            TimeSpan spawn6 = new TimeSpan(19, 0, 0);
            list.Add(spawn6);
            dict.Add(type, list);
        }

        public TimeSpan GetTimeUntil(gw2Events type)
        {

                    TimeSpan now = new TimeSpan(DateTime.UtcNow.Hour, 
                        DateTime.UtcNow.Minute, 
                        DateTime.UtcNow.Second);
                    TimeSpan lowest = now.Add(new TimeSpan(9,0,0));
           // if(type==gw2Events.Tarir) Console.WriteLine("Now is:" + now);
           // if (type == gw2Events.Tarir) Console.WriteLine("Default is:" + lowest);
           // if (type == gw2Events.Tarir) Console.WriteLine("Next is:" + timeDictionaryDB[type][1]);
           // if (type == gw2Events.Tarir) Console.WriteLine("So:" + timeDictionaryDB[type][1].Subtract(now));
            foreach (var entry in timeDictionaryDB[type])
                    {
                        if ((entry.Subtract(now).TotalMilliseconds < Math.Abs(lowest.Subtract(now).TotalMilliseconds)) 
                        && (entry.Subtract(now) >= new TimeSpan(0, 0, 0) || Math.Abs(entry.Subtract(now).TotalMilliseconds) <= GetDuration(type).TotalMilliseconds))
                        {
                           //if(type==gw2Events.Tarir) Console.WriteLine("Lowest is:" + entry);
                            lowest = entry;
                        }
                    }
            return lowest.Subtract(now);
        }


        public TimeSpan GetDuration(gw2Events type)
        {
            switch (type)
            {
                case gw2Events.Tarir:
                        return new TimeSpan(0,45,0);
                case gw2Events.Tequatl:
                        return new TimeSpan(0,15,0);
            }

            return new TimeSpan(0,0,0);
        }

    }
}
